# Code Review Workflow

Use this workflow for pull requests, patch review, or pre-merge self-review. The review should protect behavior, security, contracts, operability, and maintainability without drifting into unrelated refactors.

## Inputs

- Diff or pull request
- Approved SPEC, bug report, or incident context
- Implementation plan when available
- Test results and CI status
- Applicable standards and checklists

## Agents

- Reviewer: leads review findings and approval recommendation
- QA: checks test adequacy and verification evidence
- Security: reviews security-sensitive changes
- Backend, Frontend, Database, or DevOps: reviews domain-specific risks when touched
- Documentation: checks docs, runbooks, and examples when behavior changes

## Flow

1. Context Check
   - Identify approved scope and intended behavior.
   - Read relevant SPECs, standards, and workflow outputs.
   - Confirm the diff does not include unrelated changes.

2. Behavioral Review
   - Check whether implementation satisfies acceptance criteria.
   - Look for regressions, edge cases, invalid state transitions, and contract mismatches.
   - Confirm expected errors and failure modes are handled.

3. Security and Data Review
   - Check authentication, authorization, input validation, secrets, sensitive logging, and data exposure.
   - Confirm no credentials, tokens, private keys, or production data are committed.
   - Escalate unclear privilege or data-loss behavior as a blocker.

4. Test Review
   - Map tests to acceptance criteria or bug reproduction.
   - Check happy path, negative path, validation, regression, and security-sensitive cases.
   - Require explanation for skipped, flaky, or infeasible tests.

5. Operational Review
   - Check logging, metrics, tracing, migrations, config, rollback, and deployment notes.
   - Confirm runbooks or release notes were updated when operations changed.

6. Maintainability Review
   - Check readability, naming, dependency boundaries, duplication, and complexity.
   - Keep suggestions scoped to the changed behavior.

7. Recommendation
   - Findings lead the review, ordered by severity.
   - Classify each item as blocker, high, medium, low, or follow-up.
   - Provide approve/request changes/comment-only recommendation.

## Finding Format

- Severity
- File and line when available
- Issue
- Impact
- Suggested fix

## Failure Branches

- Missing SPEC or context: pause and request context before deep review.
- Tests absent for risky behavior: request tests or documented verification.
- Security blocker: request changes and require security re-review.
- Contract break found: require SPEC approval and migration/deprecation plan.
- Unrelated churn: request scope reduction or separate PR.

## Done Criteria

- Review findings are severity-ranked.
- Blockers are resolved or explicitly accepted by the right owner.
- Tests and verification evidence are adequate for risk.
- Scope matches approved work.
- Approval recommendation is clear.
