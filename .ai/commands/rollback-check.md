# /rollback-check

Assess whether a change can be safely rolled back.

## Required Input

- Artifact or change being deployed
- Target environment
- Config changes
- Database or data changes
- Feature flags
- Known rollback trigger conditions

## Read First

1. `.ai/workflows/deployment.md`
2. `.ai/commands/deployment-check.md`
3. `docs/runbooks/deployment.md`
4. Relevant release notes, migration notes, and deployment plan

## Execution Steps

1. Identify rollback units: artifact, config, feature flag, infrastructure, and data.
2. Confirm which rollback steps are automated and which are manual.
3. Check database migration reversibility and data compatibility.
4. Define validation after rollback.
5. Identify owner, estimated recovery time, and communication path.
6. Document risks that require explicit acceptance.

## Output Format

- Rollback path
- Data impact
- Config impact
- Validation steps
- Owner
- Risks and decision
