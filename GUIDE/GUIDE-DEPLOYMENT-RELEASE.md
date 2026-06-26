# Guide: Deployment And Release

Use this guide to assess whether a release candidate is ready, whether rollback is safe, and whether production deployment should proceed.

## Use When

- Preparing a release.
- Running deployment readiness checks.
- Reviewing rollback risk.
- Deploying to non-production or production.
- Handling release approval.

## Use These AI OS Assets

- Workflow: `.ai/workflows/deployment.md`
- Workflow: `.ai/workflows/release.md`
- Command: `.ai/commands/deployment-check.md`
- Command: `.ai/commands/rollback-check.md`
- Runbook: `docs/runbooks/deployment.md`
- Checklist: `.ai/checklists/deployment.md`

## How To Ask For Deployment Check

```text
Use the Engineering AI OS deployment workflow and /deployment-check.
Target environment: [environment]
Artifact version or commit: [version]
Release scope: [summary]
CI/test evidence: [links or results]
Deployment method: [pipeline/command]
Rollback method: [method]
Assess readiness and return ready, ready with accepted risk, or blocked.
```

## How To Ask For Rollback Check

```text
Use /rollback-check.
Change: [artifact/config/migration/feature flag]
Target environment: [environment]
Known rollback triggers: [triggers]
Assess artifact, config, data, feature flag, validation, owner, recovery time, and risks.
```

## Readiness Checklist

- Artifact identity is clear.
- CI and tests passed.
- Security checks passed or risk is accepted.
- Config and secrets references are ready.
- Migrations are reviewed.
- Rollback path is documented.
- Smoke tests are defined.
- Monitoring and alerting are ready.
- Production approval is explicit.

## Expected Output

- Scope
- Validation evidence
- Risks
- Rollback readiness
- Monitoring readiness
- Recommendation

## Common Mistakes

- Deploying without artifact identity.
- Treating rollback as automatic when data changed.
- Skipping smoke tests.
- Missing monitoring signals for the changed behavior.
