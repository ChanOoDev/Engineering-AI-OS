# Guide: Code Review

Use this guide to review a pull request, patch, or local diff against approved scope and engineering standards.

## Use When

- Reviewing a PR.
- Doing pre-merge self-review.
- Checking AI-generated code.
- Reviewing a local diff before commit.

## Use These AI OS Assets

- Workflow: `.ai/workflows/code-review.md`
- Command: `.ai/commands/review-pr.md`
- Checklist: `.ai/checklists/pr.md`
- Relevant SPEC, bug report, or approved plan
- Standards: `docs/standards/`

## How To Ask

```text
Use the Engineering AI OS code-review workflow and /review-pr.
Review this diff against [SPEC/bug/plan path].
Read the relevant standards and checklist first.
Lead with findings ordered by severity.
Include file references, impact, and suggested fix.
Do not make code changes unless I ask.
```

## Review Focus

- Behavior matches acceptance criteria.
- Tests cover important paths.
- Security and data handling are safe.
- API contracts remain compatible.
- Errors and logs follow standards.
- Deployment, rollback, and monitoring risks are addressed.
- Documentation was updated when behavior changed.

## Expected Output

- Findings
- Open questions
- Test gaps
- Approval recommendation

## Severity Guide

- Blocker: must fix before merge.
- High: likely bug, security risk, data risk, or contract regression.
- Medium: maintainability, missing coverage, or operational risk.
- Low: polish or small clarity improvement.
- Follow-up: valid work that should not block this change.

## Common Mistakes

- Starting with a summary before findings.
- Reviewing style while missing behavior.
- Ignoring test evidence.
- Approving unbounded scope drift.
