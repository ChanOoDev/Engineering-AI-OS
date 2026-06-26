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
