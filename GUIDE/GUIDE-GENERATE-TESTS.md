# Guide: Generate Tests

Use this guide when you need stronger verification for a feature, bug fix, module, or risky change.

## Use When

- A feature SPEC has acceptance criteria but no tests.
- A bug needs regression coverage.
- A review finds missing edge cases.
- You need to decide which test layer is appropriate.

## Use These AI OS Assets

- Command: `.ai/commands/generate-tests.md`
- Standard: `docs/standards/testing.md`
- Relevant feature and module SPECs
- Existing test helpers, fixtures, and test conventions

## How To Ask

```text
Use the Engineering AI OS /generate-tests command.
Target: [feature/module/files]
Read the relevant SPEC, acceptance criteria, and testing standard.
Map expected behavior to unit, integration, UI, regression, security, and performance tests where appropriate.
First provide a test plan before editing files.
```

## Test Planning Checklist

- Happy path
- Validation failure
- Negative path
- Authorization boundary
- Edge cases
- Regression cases
- Sensitive logging or data exposure
- Performance-sensitive path when relevant

## Expected Output

- Test scope
- Tests added or updated
- Commands run
- Results
- Remaining gaps or intentionally untested areas

## Effective Practice

- Use the smallest test layer that proves the behavior.
- Prefer deterministic test data.
- Avoid production data.
- Keep assertions meaningful.
- Explain skipped or infeasible tests.

## Common Mistakes

- Measuring quality only by line coverage.
- Writing tests that duplicate implementation details.
- Creating fragile timing-dependent tests.
- Ignoring negative and authorization paths.
