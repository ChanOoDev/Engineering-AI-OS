# Feature Development Workflow

Use this workflow for any user-facing or service-facing feature work. The workflow is SPEC-first and approval-gated: implementation starts only after the scope, risks, tests, and verification plan are explicit.

## Inputs

- Requirement, issue, ticket, or stakeholder request
- Project SPEC: `docs/specs/project/PROJECT_SPEC.md`
- Relevant module SPEC, such as `docs/specs/modules/AUTH_SPEC.md`
- Feature SPEC, such as `docs/specs/features/LOGIN.md`
- Applicable standards in `docs/standards/`

## Agents

- Planner: converts the requirement and SPEC into approved implementation tasks
- Backend: implements API, service, validation, persistence, logging, and backend tests
- Frontend: implements UI, state, API integration, validation, accessibility, and UI tests
- QA: defines and verifies test coverage, including regression and negative paths
- Security: reviews auth, authorization, secrets, sensitive data, and abuse cases
- Reviewer: compares the final change against SPEC, standards, and risk controls

## Flow

1. Intake
   - Capture the requirement, requester, business outcome, and desired release window.
   - Identify affected modules, APIs, data, UI, security controls, and operational surfaces.
   - If no feature SPEC exists, create or update one before planning.

2. SPEC Readiness Gate
   - Confirm objective, actors, workflow, business rules, acceptance criteria, test cases, security, logging, rollback, and monitoring are documented.
   - Mark open questions as assumptions only when they are low risk and reversible.
   - Stop and request clarification for missing security, data, API contract, or release-impact details.

3. Planning
   - Planner produces scope, non-scope, tasks by agent, dependencies, risks, and verification steps.
   - Include affected files, expected tests, migration needs, feature flag needs, and rollback approach.
   - Human approval is required before implementation.

4. Implementation
   - Backend and Frontend implement only the approved scope.
   - Keep API contracts backward compatible unless the SPEC explicitly approves a breaking change.
   - Add or update tests with the implementation, not after the fact.
   - Update docs when behavior, operations, or usage changes.

5. Validation
   - Run the smallest useful test set first, then broader regression checks.
   - QA verifies happy path, negative path, authorization boundaries, validation, and edge cases.
   - Security reviews auth, sensitive logging, dependency risk, data exposure, and abuse cases.

6. Review
   - Reviewer checks implementation against the SPEC, standards, and approved plan.
   - Any gap is classified as blocker, follow-up, or accepted risk.
   - Blockers return to implementation; accepted risks must be recorded.

7. Release Readiness
   - Confirm CI status, deployment notes, rollback steps, monitoring signals, and owner.
   - Production deployment requires explicit human approval.

8. Knowledge Update
   - Update SPECs, ADRs, runbooks, known issues, or lessons learned when the feature creates durable knowledge.

## Failure Branches

- SPEC missing or incomplete: pause implementation and update the SPEC.
- Tests fail: fix the issue or revise the plan; do not proceed to review.
- Security blocker found: contain scope, fix before release, and document residual risk.
- API contract risk found: add compatibility strategy or obtain explicit approval.
- Deployment validation fails: roll back, capture evidence, and update deployment notes.

## Done Criteria

- Feature behavior satisfies acceptance criteria
- Tests cover agreed happy, negative, regression, and security-sensitive paths
- Logs and monitoring can identify success, failure, and operational impact
- Documentation and SPECs reflect the final behavior
- Reviewer has no unresolved blockers
