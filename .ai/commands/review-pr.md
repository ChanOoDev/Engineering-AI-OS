# /review-pr

Review a pull request or local diff against the approved SPEC, standards, tests, security expectations, and operational risk.

## Required Input

- PR link, branch, or local diff
- Relevant SPEC, bug report, or approved plan
- Test and CI evidence when available

## Read First

1. `.ai/workflows/code-review.md`
2. `.ai/checklists/pr.md`
3. Relevant SPEC or bug report
4. Applicable standards in `docs/standards/`

## Execution Steps

1. Confirm review context and approved scope.
2. Inspect changed files.
3. Review behavior against acceptance criteria or expected fix.
4. Review tests and verification evidence.
5. Review security, data, API, logging, and deployment risk.
6. Report findings first, ordered by severity.
7. Provide approval recommendation and remaining risk.

## Output Format

- Findings
- Open questions
- Test gaps
- Approval recommendation
