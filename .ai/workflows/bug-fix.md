# Bug Fix Workflow

Use this workflow for defects, regressions, production issues that require code changes, and behavior that conflicts with an approved SPEC.

## Inputs

- Bug report, incident, support ticket, failed test, or user report
- Expected behavior from SPEC, standard, contract, or prior release
- Actual behavior with evidence
- Reproduction steps, logs, screenshots, traces, or failing test output
- Affected environment and version when known

## Agents

- Planner: scopes the fix and separates root cause from symptoms
- Backend or Frontend: implements the approved fix in the affected surface
- QA: verifies reproduction, regression coverage, and edge cases
- Security: reviews security-sensitive bugs or fixes touching auth, data, secrets, or logging
- Reviewer: checks the patch against root cause, SPEC, tests, and risk
- DevOps: supports environment, deployment, rollback, and monitoring impact

## Flow

1. Intake
   - Capture summary, severity, affected users, environment, version, frequency, and workaround.
   - Link the relevant SPEC, API contract, standard, or prior expected behavior.
   - Classify urgency: blocker, high, medium, or low.

2. Reproduce
   - Reproduce locally or in a safe non-production environment when possible.
   - Preserve the failing command, request, input, or user path.
   - If not reproducible, gather enough evidence to form a bounded hypothesis.

3. Root Cause
   - Identify the smallest code, config, data, or infrastructure cause.
   - Distinguish root cause from visible symptom.
   - Check whether the bug is caused by a missing SPEC, ambiguous requirement, or contract drift.

4. Fix Plan
   - Define scope and non-scope.
   - List files likely to change, tests to add, risks, and rollback path.
   - Require approval before patching unless the user already granted implementation approval.

5. Patch
   - Make the smallest behavior-preserving change that fixes the root cause.
   - Avoid unrelated cleanup.
   - Add a failing regression test when feasible, then make it pass.
   - Update SPECs or docs if expected behavior was unclear or changed.

6. Verify
   - Run the reproduction path.
   - Run targeted regression tests.
   - Run broader tests when shared code, auth, data, API contracts, or deployment behavior changed.
   - Confirm logs and error messages remain safe.

7. Review
   - Reviewer verifies the patch fixes the root cause, not only the symptom.
   - QA confirms regression coverage.
   - Security reviews if the bug touches auth, secrets, sensitive data, logging, or abuse behavior.

8. Release Notes
   - Document user impact, fix summary, verification evidence, rollback notes, and any follow-up.
   - Update known issues or lessons learned when the bug reveals durable knowledge.

## Failure Branches

- Cannot reproduce: document evidence, hypothesis, additional instrumentation, and next diagnostic step.
- Root cause outside approved scope: stop and request approval for expanded scope.
- Regression test cannot be added: document why and define alternate verification.
- Fix changes public contract: update SPEC and obtain explicit approval.
- Deployment risk is high: use deployment workflow and rollback checklist before release.

## Done Criteria

- Root cause is understood or explicitly bounded.
- Reproduction path now passes.
- Regression coverage exists or a documented alternate verification exists.
- Patch is limited to approved scope.
- Tests and review evidence are recorded.
- Release notes, SPECs, or docs are updated when behavior changed.
