# Lessons Learned

Capture reusable learning after every feature, bug, incident, and release.

## LOGIN Reference API Golden Path

Date: 2026-06-26

### Context

The repository needed a runnable proof that the Engineering AI OS can guide real implementation, not only documentation. The `LOGIN` feature was selected because it touches API behavior, security, audit logging, testing, and review.

### What Worked

- Starting from `LOGIN.md`, `AUTH_SPEC.md`, and `AUDIT_LOG_SPEC.md` produced a clear implementation boundary.
- The approval gate prevented scope creep into production JWT, real persistence, refresh tokens, MFA, and frontend UI.
- Integration tests provided better proof than documentation alone.
- The framework validator and `dotnet test` together created a useful CI signal.

### What To Repeat

- Keep reference implementations small and tied to one feature SPEC.
- Record scope and non-scope before implementation.
- Add tests during implementation, not afterward.
- Capture follow-ups separately when they are valid but outside approved scope.

### Follow-Ups

- Add an abuse-prevention reference example for repeated failed login attempts.
- Add a dedicated security review example for the reference API.

## SCHEDULER_RETRY Reference Golden Path

Date: 2026-06-26

### Context

The repository needed a second golden-path proof outside authentication. `SCHEDULER_RETRY` was selected because it exercises operational behavior: retries, failure classification, idempotency, duplicate execution prevention, and observability.

### What Worked

- Keeping the scheduler implementation in memory made retry rules easy to test without pretending to have production infrastructure.
- Modeling job state transitions directly gave clearer tests than adding an early fake background worker.
- Safe structured scheduler events proved the logging expectations without storing sensitive payloads.

### What To Repeat

- Start operational examples with pure domain/service behavior before adding queues or hosted services.
- Keep real infrastructure explicitly out of scope until the retry semantics are correct.
- Test state transitions and event output together.

### Follow-Ups

- Add an authorized manual requeue endpoint.
- Add a hosted-service or queue-backed scheduler reference.
- Add metrics and alert examples for retry exhaustion.
