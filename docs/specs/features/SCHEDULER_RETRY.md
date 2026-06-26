# SCHEDULER RETRY

## Objective

Retry failed scheduled jobs using bounded, observable, and idempotent retry behavior so transient failures recover without creating duplicate side effects or retry storms.

## Background

Scheduled jobs often fail because of transient dependency, timeout, network, or capacity issues. Retry behavior must be explicit so failures are recoverable while still protecting downstream systems and preserving data correctness.

## Actors

- Scheduler service
- Worker or job handler
- Downstream dependency
- Operations staff
- Alerting system

## Workflow

1. Scheduler starts a job execution.
2. Worker completes successfully or reports failure with a failure class.
3. Retry policy determines whether the failure is retryable.
4. Retryable failures are rescheduled with backoff and attempt count.
5. Non-retryable or exhausted jobs move to a failed state.
6. Operators are alerted for exhausted or business-critical failures.

## Business Rules

- Retry policy must define max attempts, backoff, jitter, and retryable failure classes.
- Jobs must be idempotent or guarded by idempotency keys before retry is enabled.
- Exhausted retries must be visible in monitoring.
- Manual requeue must require authorization and audit logging.
- Retry attempts must not run concurrently for the same logical job unless explicitly allowed.

## API Changes

No public API is required. Optional internal admin endpoints for manual retry or requeue must require authorization and audit logging.

## Database Changes

Add or confirm job execution fields:

- job id
- status
- attempt count
- next retry at
- last error class
- idempotency key
- started at and completed at

## UI Changes

No end-user UI change is required. Operations UI may show status, attempt count, next retry time, and last safe error summary.

## Non-Functional Requirements

- Retry behavior must not overload downstream dependencies.
- Job status updates must be concurrency-safe.
- Retry metrics and alerts must be available for critical jobs.

## Security

- Manual retry and requeue actions must be restricted to authorized operators.
- Do not log sensitive job payloads or dependency credentials.
- Ensure retries do not bypass authorization or tenant boundaries.

## Logging

Emit structured events:

- `scheduler.job.started`
- `scheduler.job.succeeded`
- `scheduler.job.failed`
- `scheduler.job.retry_scheduled`
- `scheduler.job.retry_exhausted`

Include correlation id, job id, attempt count, failure class, and next retry time when available.

## Acceptance Criteria

- Retryable failure schedules another attempt with configured backoff.
- Non-retryable failure does not retry.
- Retry attempts stop after max attempts.
- Exhausted retries produce monitoring signal or alert.
- Retry does not create duplicate side effects for idempotent jobs.
- Manual requeue is authorized and audited when implemented.

## Test Cases

- Unit: retry policy classifies retryable and non-retryable failures.
- Unit: backoff and max attempts are calculated correctly.
- Unit: exhausted retries move job to failed state.
- Integration: transient failure succeeds on retry.
- Integration: concurrent workers do not run duplicate attempts for the same job.
- Security: unauthorized manual retry is forbidden.
- Regression: sensitive payload values are not logged.

## Risks

- Retry storm against degraded dependencies.
- Duplicate side effects when jobs are not idempotent.
- Silent retry exhaustion without alerting.
- Long backoff delaying business-critical work.

## Rollback Plan

- Disable retry policy through configuration or feature flag.
- Roll back scheduler version if retry state handling is incorrect.
- Manually review in-flight jobs before requeueing or marking failed.

## Deployment Notes

- Confirm retry policy per job type.
- Confirm dashboards for retry count, exhausted retries, job duration, and failure class.
- Deploy to non-production and simulate transient and permanent failures before production approval.
