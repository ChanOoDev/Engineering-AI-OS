# Guide: Bug Fix

Use this guide to fix defects without widening scope or introducing regressions.

## Use When

- A confirmed defect exists.
- Actual behavior differs from expected behavior.
- A production incident has a code or configuration follow-up.
- A regression test is needed for a known failure.

## Use These AI OS Assets

- Workflow: `.ai/workflows/bug-fix.md`
- Command: `.ai/commands/fix-bug.md`
- Standards: `docs/standards/testing.md`, `error-handling.md`, `logging.md`, `security.md`
- Relevant feature or module SPEC

## How To Ask

```text
Use the Engineering AI OS bug-fix workflow and /fix-bug.
Bug summary: [summary]
Expected behavior: [expected]
Actual behavior: [actual]
Evidence or reproduction steps: [steps/logs/tests]
Read relevant SPECs and standards first.
First reproduce or bound the issue, identify likely root cause, propose a fix plan and regression tests.
Do not modify files until I approve the plan.
```

## Approval Gate

Approve the fix only when the agent has:

- Reproduction steps or a bounded explanation of why reproduction is not possible
- Root cause or likely failure area
- Smallest safe fix scope
- Regression test plan
- Security, data, and contract risk assessment
- Rollback or release note impact

## Expected Final Output

- Bug summary
- Root cause
- Fix implemented
- Regression tests
- Verification
- Risks and release notes

## Effective Practice

- Prefer a failing test before or with the fix.
- Keep the patch focused on the defect.
- Ask the agent to explain why the fix prevents recurrence.
- Update known issues or lessons learned when the bug reveals a process gap.

## Common Mistakes

- Combining bug fixes with unrelated cleanup.
- Fixing symptoms without identifying cause.
- Skipping regression tests.
- Changing expected behavior without updating the SPEC.
