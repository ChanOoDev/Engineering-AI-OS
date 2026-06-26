# /deployment-check

Assess whether a release candidate is ready for deployment.

## Required Input

- Target environment
- Artifact version, commit SHA, or build number
- Release notes or list of included changes
- CI/test evidence
- Deployment and rollback method

## Read First

1. `.ai/workflows/deployment.md`
2. `.ai/checklists/deployment.md`
3. `docs/runbooks/deployment.md`
4. Relevant SPECs, release notes, and migration notes

## Execution Steps

1. Confirm release scope and artifact identity.
2. Verify CI, tests, security checks, and review status.
3. Validate environment config, secrets references, permissions, and infrastructure readiness.
4. Review database migration and data-impact risk.
5. Confirm rollback path and owner.
6. Confirm monitoring, alerts, logs, and smoke tests.
7. Produce deployment recommendation: ready, ready with accepted risk, or blocked.

## Output Format

- Scope
- Validation evidence
- Risks
- Rollback readiness
- Monitoring readiness
- Recommendation
