# /implement-feature

Implement an approved feature using the SPEC-first golden path.

## Required Input

- Feature SPEC path, for example `docs/specs/features/LOGIN.md`
- Relevant module SPEC path
- User request or ticket summary
- Explicit approval to implement after the plan is reviewed

## Read First

1. `AI_OS.md`
2. `.ai/workflows/feature-development.md`
3. `docs/specs/project/PROJECT_SPEC.md`
4. Relevant module SPEC
5. Relevant feature SPEC
6. Applicable standards:
   - `docs/standards/coding.md`
   - `docs/standards/api.md`
   - `docs/standards/error-handling.md`
   - `docs/standards/security.md`
   - `docs/standards/testing.md`
   - `docs/standards/logging.md`

## Execution Steps

1. SPEC Check
   - Confirm objective, workflow, acceptance criteria, tests, security, logging, rollback, and monitoring are present.
   - If high-risk information is missing, stop and request clarification.

2. Plan
   - Summarize scope and non-scope.
   - List assumptions, risks, affected files, implementation tasks, and verification steps.
   - Assign tasks to relevant agents: Planner, Backend, Frontend, QA, Security, Reviewer.
   - Wait for human approval before modifying implementation files.

3. Implement
   - Change only approved files and behavior.
   - Keep contracts backward compatible unless the SPEC authorizes a breaking change.
   - Add tests alongside behavior changes.
   - Update docs, SPECs, runbooks, or examples when durable behavior changes.

4. Verify
   - Run targeted tests first.
   - Run broader checks when shared code, API contracts, auth, data, or deployment behavior changed.
   - Capture commands run and results.

5. Review
   - Compare final changes against SPEC, plan, standards, and tests.
   - Classify unresolved issues as blocker, follow-up, or accepted risk.

6. Summarize
   - Report changed files, behavior implemented, tests run, known risks, and release notes.

## Output Format

- Scope
- Plan
- Changes
- Verification
- Risks and follow-ups

## Stop Conditions

- No relevant SPEC exists
- Approval has not been granted
- Required secret, credential, or production access is missing
- Security or data-loss risk cannot be bounded
- Tests reveal a blocker that is outside approved scope
