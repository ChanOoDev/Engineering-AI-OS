# /refactor

Identify refactor scope, preserve behavior, add safety tests, refactor incrementally.

## Required Input

- Refactor target: files, module, component, or code smell
- Reason for refactor
- Expected behavior that must be preserved
- Relevant tests or verification method

## Read First

1. Relevant SPECs and architecture docs
2. `docs/standards/coding.md`
3. `docs/standards/testing.md`
4. Nearby implementation and tests

## Execution Steps

1. Bound Scope
   - State the refactor objective and non-goals.
   - Identify public contracts, data shape, side effects, and behavior that must not change.

2. Safety Net
   - Locate existing tests that protect the behavior.
   - Add characterization or regression tests first when coverage is weak.

3. Plan
   - Break the refactor into small reversible steps.
   - Call out risks around API contracts, persistence, security, performance, and deployment.
   - Wait for approval before editing when the refactor is not already approved.

4. Refactor
   - Preserve behavior unless a SPEC or approved plan explicitly changes it.
   - Keep names, boundaries, and abstractions consistent with local patterns.
   - Avoid unrelated cleanup.

5. Verify
   - Run targeted tests after each meaningful step.
   - Run broader checks when shared code or contracts changed.
   - Compare before and after behavior when possible.

## Output Format

- Scope and non-scope
- Safety tests
- Refactor changes
- Verification
- Residual risk and follow-ups

## Stop Conditions

- Current behavior is unclear and cannot be characterized.
- Refactor requires a breaking contract change without approval.
- Tests reveal behavior changes outside approved scope.
