# Golden Path Example: LOGIN Reference API

This example records the first completed Engineering AI OS golden-path implementation in this repository.

## Purpose

Prove that the framework can guide a feature from SPEC to plan, approval, implementation, tests, review, and knowledge capture.

## Source Of Truth

- Project SPEC: `docs/specs/project/PROJECT_SPEC.md`
- Feature SPEC: `docs/specs/features/LOGIN.md`
- Module SPECs:
  - `docs/specs/modules/AUTH_SPEC.md`
  - `docs/specs/modules/AUDIT_LOG_SPEC.md`
- Workflow: `.ai/workflows/feature-development.md`
- Command: `.ai/commands/implement-feature.md`

## Implementation

- API project: `src/reference-api`
- Test project: `tests/reference-api-tests`
- Solution: `EngineeringAIOS.slnx`
- CI workflow: `.github/workflows/validate-framework.yml`

The reference API implements `POST /api/auth/login` with in-memory users, standard error envelopes, generic authentication failures, safe user response data, and in-memory audit events.

## Golden Path Evidence

1. SPEC
   - `LOGIN.md`, `AUTH_SPEC.md`, and `AUDIT_LOG_SPEC.md` defined behavior, API expectations, security rules, audit events, acceptance criteria, and tests.

2. Plan
   - The implementation plan explicitly listed scope, non-scope, assumptions, risks, affected files, tests, and verification commands.

3. Approval
   - Implementation started only after explicit approval.

4. Implementation
   - The app was implemented under `src/reference-api` using a minimal ASP.NET Core API.
   - Business logic was kept in services rather than in the route handler.

5. Test
   - Integration tests were added under `tests/reference-api-tests`.
   - Tests cover success, validation failures, invalid credentials, locked and disabled users, error envelope behavior, and audit safety.

6. Review
   - Self-review found no blockers.
   - Follow-ups were documented separately from the approved reference scope.

7. CI/CD
   - The GitHub Actions workflow validates the AI OS markdown contracts and runs `dotnet test`.

8. Knowledge Update
   - This example and `docs/knowledge/lessons-learned.md` capture the reusable process learning.

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

- Add a small abuse-prevention or rate-limit reference example.
- Add a dedicated security review example using `.ai/commands/review-security.md`.
