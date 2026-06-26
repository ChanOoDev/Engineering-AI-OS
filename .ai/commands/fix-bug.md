# /fix-bug

Fix a confirmed defect using the bug-fix workflow.

## Required Input

- Bug summary
- Expected behavior
- Actual behavior
- Reproduction steps or evidence
- Affected environment/version when known

## Read First

1. `.ai/workflows/bug-fix.md`
2. Relevant feature or module SPEC
3. Relevant standards
4. Related logs, tests, or issue context

## Execution Steps

1. Reproduce or bound the issue.
2. Identify root cause.
3. Propose fix plan, tests, risks, and rollback.
4. Wait for approval before patching unless approval is already explicit.
5. Patch the smallest approved scope.
6. Add or update regression tests.
7. Verify reproduction and targeted tests.
8. Summarize fix, verification, residual risk, and release notes.

## Output Format

- Bug summary
- Root cause
- Fix implemented
- Regression tests
- Verification
- Risks and release notes

## Stop Conditions

- Expected behavior is unknown.
- Root cause requires scope outside approval.
- Fix risks data loss, security exposure, or contract break without explicit approval.
