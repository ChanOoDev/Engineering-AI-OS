# Testing Standard

Every feature must define how it will be verified before implementation starts.

## Test Layers

- Unit tests: pure business logic, validation, mapping, and error handling.
- Integration tests: API, database, identity, messaging, or external boundary behavior.
- UI tests: important user workflows, validation, and accessibility-sensitive interactions.
- Regression tests: behavior that previously failed or is business critical.
- Security tests: authorization boundaries, sensitive logging, and abuse-sensitive paths.

## Coverage Expectations

- Cover acceptance criteria from the feature SPEC.
- Include happy path, validation failure, negative path, and relevant edge cases.
- Add tests for bug fixes before or with the fix.
- Prefer meaningful assertions over shallow line coverage.
- Document any intentionally untested area and why.

## Test Data

- Do not use production data in tests.
- Keep test data deterministic.
- Mask or synthesize sensitive data.
- Clean up state created by integration or E2E tests.

## Verification Report

Summaries should include:

- Commands run
- Test result
- Any skipped tests and reason
- Remaining risk
