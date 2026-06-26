# Production Incident Workflow

Use this workflow for production outages, degraded service, data integrity risk, security-impacting behavior, failed deployments, and customer-impacting incidents.

## Inputs

- Alert, customer report, operator observation, or failed deployment signal
- Affected service, environment, region, tenant, or customer group
- Severity estimate and customer impact
- Dashboards, logs, traces, metrics, deployment history, and recent changes
- Current owner or incident commander

## Agents

- Project Manager or Incident Commander: coordinates timeline, roles, updates, and decisions
- DevOps: checks infrastructure, deployment, config, rollback, and monitoring
- Backend, Frontend, Database, or Security: investigates affected domain
- QA: validates fix and regression checks before recovery declaration
- Documentation: records timeline, RCA, runbook updates, and follow-ups

## Flow

1. Detect and Declare
   - Confirm incident exists and assign severity.
   - Name incident commander, technical lead, communications owner, and scribe.
   - Open the agreed incident channel or tracking record.

2. Triage
   - Determine customer impact, affected surface, start time, and current symptoms.
   - Check recent deployments, config changes, migrations, traffic spikes, dependency failures, and alerts.
   - Set update cadence based on severity.

3. Contain
   - Stop the bleeding before deep root cause analysis.
   - Use rollback, feature flag disablement, traffic shift, scaling, circuit breaker, queue pause, or dependency fallback where appropriate.
   - Preserve evidence needed for root cause and audit.

4. Diagnose
   - Form hypotheses and test them with evidence.
   - Avoid broad speculative changes.
   - Escalate when required access, domain expertise, or vendor support is needed.

5. Fix or Mitigate
   - Apply the safest fix or mitigation.
   - Prefer reversible actions during active incident response.
   - Record commands, config changes, deployment IDs, and decision owners.

6. Validate Recovery
   - Confirm health checks, user workflows, logs, metrics, and error rates are back within threshold.
   - QA or domain owner verifies the critical path.
   - Communicate status and remaining risk.

7. Close Incident
   - Declare recovery time and close active response.
   - Capture timeline, impact, root cause, contributing factors, and follow-up actions.
   - Update runbooks, alerts, SPECs, tests, or deployment gates when needed.

## Failure Branches

- Severity unclear: assume higher severity until impact is bounded.
- Rollback unsafe: document why and choose mitigation or forward fix.
- Root cause unknown after recovery: keep RCA open and assign diagnostic follow-up.
- Security impact suspected: switch to security-incident process and preserve evidence.
- Data integrity risk exists: stop writes or isolate affected data until Database review.

## Done Criteria

- Customer impact is mitigated or resolved.
- Recovery is validated with evidence.
- Timeline and decisions are recorded.
- Root cause or bounded hypothesis is documented.
- Follow-ups have owners and due dates.
- Runbooks, alerts, tests, or deployment checks are updated when gaps were found.
