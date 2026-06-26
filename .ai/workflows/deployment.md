# Deployment Workflow

Use this workflow for non-production and production deployments. Production deployment requires explicit human approval after validation, rollback readiness, and monitoring readiness are confirmed.

## Inputs

- Release candidate, commit SHA, build number, or artifact version
- Approved SPECs, bug fixes, or release notes included in the deployment
- CI results and test evidence
- Environment target
- Deployment runbook
- Rollback plan

## Agents

- DevOps: owns deployment plan, environment readiness, CI/CD, config, rollback, and monitoring
- QA: validates test evidence and smoke/regression results
- Security: reviews secrets, permissions, sensitive config, and security-sensitive release risk
- Backend/Frontend/Database: supports service-specific deployment and migration risk
- Reviewer: checks release readiness evidence and unresolved blockers

## Flow

1. Release Scope
   - Identify artifact version, commits, features, fixes, migrations, and config changes.
   - Confirm every included change has approved context and review status.
   - Identify customer impact and release window.

2. Pre-Deployment Validation
   - Confirm CI passed.
   - Confirm required tests passed or skipped tests have accepted rationale.
   - Confirm environment variables, secrets references, permissions, and infrastructure config are ready.
   - Confirm database migrations are reviewed and reversible or otherwise risk-accepted.

3. Rollback Readiness
   - Define rollback trigger conditions.
   - Identify artifact rollback, config rollback, feature flag rollback, and database rollback steps.
   - Confirm rollback owner and expected recovery time.

4. Non-Production Deployment
   - Deploy to the safest relevant non-production environment.
   - Run smoke tests, migration checks, auth checks, and business-critical workflows.
   - Validate logs, dashboards, alerts, and error rates.

5. Production Approval Gate
   - Summarize release scope, validation evidence, risks, rollback plan, and monitoring plan.
   - Obtain explicit human approval for production deployment.
   - Stop if unresolved blockers remain.

6. Production Deployment
   - Deploy using the approved method.
   - Watch logs, metrics, traces, health checks, and user-impact signals.
   - Keep rollback path ready until the monitoring window completes.

7. Post-Deployment
   - Record deployment result, validation evidence, incidents, and follow-ups.
   - Update release notes, runbooks, known issues, and lessons learned when needed.

## Failure Branches

- CI failed: stop and return to implementation or fix workflow.
- Config missing: stop until environment readiness is restored.
- Migration risk unclear: require database review and rollback decision.
- Non-production validation failed: fix or roll back before production approval.
- Production validation failed: execute rollback plan or incident workflow.
- Monitoring unavailable: do not deploy production unless risk is explicitly accepted.

## Done Criteria

- Release scope is known and approved.
- CI and required validation passed.
- Rollback plan is executable.
- Monitoring and alert signals are ready.
- Production approval is explicit.
- Deployment result and follow-ups are recorded.
