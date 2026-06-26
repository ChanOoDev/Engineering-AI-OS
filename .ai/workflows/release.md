# Release Workflow

Use this workflow to package approved changes into a release candidate, validate readiness, communicate scope, and hand off to deployment.

## Inputs

- Release branch, tag, artifact version, or commit range
- Approved features, fixes, incidents, and documentation changes
- CI/test/security evidence
- Known issues and accepted risks
- Target environment and release window

## Agents

- Project Manager: coordinates scope, schedule, approvals, and communication
- Reviewer: verifies release scope and unresolved risks
- QA: validates test coverage and release candidate quality
- DevOps: prepares artifact, environment readiness, and deployment handoff
- Security: reviews security-sensitive changes and release blockers
- Documentation: prepares release notes and user/operator docs

## Flow

1. Scope Freeze
   - Identify included commits, features, fixes, migrations, and config changes.
   - Exclude unapproved or incomplete work.
   - Record known issues and accepted risks.

2. Release Candidate
   - Build or identify the release artifact.
   - Record artifact version, commit SHA, build number, and environment assumptions.
   - Confirm the artifact can be deployed and rolled back.

3. Validation
   - Confirm CI passed.
   - Confirm required tests, security checks, migration checks, and smoke tests are complete.
   - Resolve or explicitly accept release blockers.

4. Release Notes
   - Summarize user-visible changes, operational changes, migrations, known issues, and rollback notes.
   - Include upgrade or configuration steps when needed.
   - Update docs, SPECs, runbooks, and examples when behavior changed.

5. Approval
   - Present scope, validation evidence, known risks, rollback readiness, and deployment plan.
   - Obtain release approval before deployment workflow begins.

6. Deployment Handoff
   - Provide artifact identity, release notes, smoke tests, monitoring signals, rollback plan, and owners.
   - Start `.ai/workflows/deployment.md` for environment deployment.

7. Post-Release
   - Confirm release outcome after deployment.
   - Capture issues, follow-ups, and lessons learned.
   - Update changelog or release record.

## Failure Branches

- Scope includes unapproved work: remove from release or obtain approval.
- CI or required tests fail: block release until fixed or risk is formally accepted.
- Artifact cannot be reproduced: rebuild and record provenance.
- Rollback path unclear: block release until rollback-check is complete.
- Release notes incomplete: delay handoff until customer and operator impact are documented.

## Done Criteria

- Release scope and artifact identity are recorded.
- Validation evidence is complete.
- Known risks and issues are documented.
- Release notes are ready.
- Deployment handoff includes rollback and monitoring details.
- Approval is recorded before deployment.
