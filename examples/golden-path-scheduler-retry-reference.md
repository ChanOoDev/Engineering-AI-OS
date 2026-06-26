# Golden Path Example: SCHEDULER_RETRY Reference

This example records the second completed Engineering AI OS golden-path implementation in this repository.

## Purpose

Prove that the framework can guide operational/background behavior, not only request/response authentication.

## Source Of Truth

- Project SPEC: `docs/specs/project/PROJECT_SPEC.md`
- Feature SPEC: `docs/specs/features/SCHEDULER_RETRY.md`
- Module SPEC: `docs/specs/modules/SCHEDULER_SPEC.md`
- Workflow: `.ai/workflows/feature-development.md`
- Command: `.ai/commands/implement-feature.md`

## Implementation

- Scheduler code: `src/reference-api/Scheduler`
- Tests: `tests/reference-api-tests/SchedulerRetryTests.cs`

The reference implementation models retry policy and execution state in memory. It does not run a real background worker, queue, database, distributed lock, or admin API.

## Golden Path Evidence

1. SPEC
   - `SCHEDULER_RETRY.md` and `SCHEDULER_SPEC.md` defined retry policy, observability, idempotency, concurrency, and security expectations.

2. Plan
   - Scope was limited to in-memory retry policy, state transitions, event capture, and tests.

3. Approval
   - Implementation started only after explicit approval.

4. Implementation
   - `SchedulerService` handles job start, success, failure, retry scheduling, retry exhaustion, and duplicate suppression.

5. Test
   - Tests cover retryable failure, non-retryable failure, max attempts, retry success, duplicate execution suppression, non-idempotent jobs, and safe event content.

6. Knowledge Update
   - This example and `docs/knowledge/lessons-learned.md` record what to repeat for operational features.

## Verification

Run from the repository root:

```powershell
dotnet test
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\validate-framework.ps1
```

Expected result:

- Reference API tests pass.
- Framework validation passes.

## Follow-Ups

- Add an authorized manual requeue endpoint.
- Add a hosted-service or queue-backed scheduler proof.
- Add metrics/alert examples for retry exhaustion.
