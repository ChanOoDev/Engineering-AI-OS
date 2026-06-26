# Sample Feature Workflow

Feature: LOGIN

1. Read `AI_OS.md`.
2. Read `.ai/workflows/feature-development.md`.
3. Read `docs/specs/project/PROJECT_SPEC.md`.
4. Read `docs/specs/modules/AUTH_SPEC.md`.
5. Read `docs/specs/features/LOGIN.md`.
6. Planner Agent creates scope, risks, task plan, rollback, monitoring, and test plan.
7. Human approves the implementation scope.
8. Backend Agent implements login API behavior, validation, errors, logs, and backend tests.
9. Frontend Agent implements login form behavior, API integration, validation states, and UI tests.
10. QA Agent maps acceptance criteria to verification results.
11. Security Agent reviews authentication, sensitive logging, account enumeration, and token handling.
12. Reviewer Agent checks implementation against SPEC, standards, and approved scope.
13. PR is created with verification evidence.
14. CI/CD validates the change.
15. Deployment checklist is completed before production approval.
16. Knowledge base, SPECs, or runbooks are updated if behavior changed.

Reference files:

- `docs/specs/features/LOGIN.md`
- `docs/specs/modules/AUTH_SPEC.md`
- `.ai/commands/implement-feature.md`
