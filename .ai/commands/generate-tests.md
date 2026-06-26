# /generate-tests

Generate unit, integration, regression, and E2E tests from acceptance criteria.

## Required Input

- Feature SPEC, bug report, or approved implementation plan
- Target component, module, endpoint, workflow, or changed files
- Existing test framework and test location
- Known risks or edge cases

## Read First

1. `.ai/workflows/feature-development.md` or `.ai/workflows/bug-fix.md`
2. `docs/standards/testing.md`
3. Relevant feature and module SPECs
4. Existing nearby tests and test helpers

## Execution Steps

1. Test Scope
   - Map acceptance criteria, business rules, and known defects to test cases.
   - Identify happy path, validation failures, negative paths, authorization boundaries, edge cases, and regression paths.

2. Test Strategy
   - Choose the smallest useful layer for each behavior: unit, integration, UI, E2E, security, or performance.
   - Reuse existing fixtures, builders, mocks, and test naming conventions.

3. Plan
   - List tests to add or update, expected assertions, required data, and any setup or cleanup.
   - Wait for approval when the test work changes scope or requires non-trivial infrastructure.

4. Implement
   - Add deterministic tests with meaningful assertions.
   - Avoid production data and fragile timing dependencies.
   - Keep tests close to the behavior under test.

5. Verify
   - Run targeted tests first.
   - Run broader suites when shared behavior, contracts, auth, data, or UI flows changed.
   - Record skipped tests and reasons.

## Output Format

- Test scope
- Tests added or updated
- Commands run
- Results
- Remaining gaps or intentionally untested areas

## Stop Conditions

- Expected behavior is undefined.
- Test data would require production or sensitive data.
- Required test infrastructure is missing and cannot be reasonably scaffolded.
