# Deployment Runbook

Use this runbook with `.ai/workflows/deployment.md` and `.ai/commands/deployment-check.md`.

## Purpose

Provide a repeatable deployment procedure with validation, rollback, and post-deployment monitoring.

## Required Information

- Target environment
- Artifact version, build number, or commit SHA
- Release notes or included changes
- Deployment owner
- Rollback owner
- Expected deployment window
- Relevant dashboards, logs, and smoke tests

## Pre-Deployment

1. Confirm release scope and approvals.
2. Confirm CI and required tests passed.
3. Confirm environment config and secret references exist.
4. Confirm infrastructure and database changes were reviewed.
5. Confirm rollback steps and trigger conditions.
6. Confirm monitoring and alert readiness.

## Deployment Steps

1. Announce deployment start if the team process requires it.
2. Deploy to non-production first when applicable.
3. Run smoke tests and review logs/metrics.
4. Obtain production approval.
5. Deploy the approved artifact to production.
6. Run production smoke tests.
7. Monitor health, latency, error rate, and feature-specific signals.

## Rollback

Trigger rollback when:

- Health checks fail.
- Error rate or latency exceeds agreed threshold.
- Business-critical smoke test fails.
- Security-sensitive behavior is incorrect.
- Data integrity risk appears.

Rollback steps should identify:

- Artifact rollback command or pipeline action.
- Config or feature flag reversal.
- Database rollback or forward-fix decision.
- Post-rollback validation.
- Communication owner.

## Post-Deployment

- Record result and validation evidence.
- Document incidents or anomalies.
- Update release notes, known issues, and lessons learned when needed.
- Track follow-up owners and due dates.
