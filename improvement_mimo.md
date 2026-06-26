# Engineering AI OS -- Current Improvement Backlog

**Updated:** 2026-06-26  
**Baseline:** After `7c75b27 Add LOGIN golden-path reference app`  
**Status:** Framework and first runnable proof are in place.

---

## Current Grade

| Area | Grade | Notes |
| --- | ---: | --- |
| AI OS framework | 9.3/10 | Workflows, commands, prompts, specs, standards, guides, validation, and CI are now actionable. |
| Runnable reference proof | 8.5/10 | `LOGIN` reference API proves the golden path with tests and security follow-ups. |
| Operational maturity | 7.5/10 | More runbooks, dependency/security workflows, and production-style examples are still needed. |
| Starter kit completeness | 5/10 | Starter kits remain mostly README-level accelerators. |

---

## Completed Since Original Audit

- Expanded key commands into executable playbooks.
- Expanded workflows into structured lifecycle gates.
- Added role-specific default prompts.
- Populated project, module, and feature SPECs.
- Added user guides under `GUIDE/`.
- Added `scripts/validate-framework.ps1`.
- Added GitHub Actions validation.
- Added `docs/standards/performance.md`.
- Added a runnable .NET `LOGIN` reference API.
- Added integration tests for the reference API.
- Captured the first golden-path example in `examples/golden-path-login-reference.md`.
- Captured lessons learned in `docs/knowledge/lessons-learned.md`.

---

## Priority Backlog

### P1 -- Next Golden-Path Proofs

1. **Add `SCHEDULER_RETRY` reference implementation**
   - Implement a small in-memory scheduler/job retry sample.
   - Cover retryable failure, non-retryable failure, max attempts, retry exhaustion, and safe logging.
   - Capture a second golden-path example.

2. **Add abuse-prevention demo for LOGIN**
   - Add a small rate-limit or failed-attempt policy to the reference API.
   - Keep it demo-safe and in-memory.
   - Add tests for repeated failures and lockout behavior.

3. **Add a simple frontend login UI**
   - Optional React reference UI against `src/reference-api`.
   - Demonstrate validation, generic auth failure, and safe error display.

### P1 -- Security And Supply Chain

4. **Create dependency update workflow**
   - Add `.ai/workflows/dependency-update.md`.
   - Cover NuGet/npm updates, security advisories, compatibility checks, tests, and rollback.

5. **Create vulnerability scanning standard**
   - Add `docs/standards/vulnerability-scanning.md`.
   - Define SAST, SCA, secret scanning, container scanning, severity thresholds, and remediation timelines.

6. **Create secrets management standard**
   - Add `docs/standards/secrets-management.md`.
   - Cover approved stores, local development, rotation, emergency response, and logging restrictions.

### P2 -- Operational Maturity

7. **Create security incident workflow**
   - Add `.ai/workflows/security-incident.md`.
   - Cover triage, containment, evidence preservation, communication, notification, recovery, and postmortem.

8. **Create data migration workflow**
   - Add `.ai/workflows/data-migration.md`.
   - Cover migration impact analysis, staging validation, rollback/forward-fix strategy, backups, and verification.

9. **Add operational runbooks**
   - Add runbooks for incident response, service restart, performance degradation, backup restore, and certificate rotation.

10. **Create monitoring and alerting standard**
    - Add `docs/standards/monitoring-alerting.md`.
    - Define signals, alert thresholds, ownership, escalation, and alert fatigue controls.

### P2 -- Engineering Standards

11. **Create AI code generation standard**
    - Add `docs/standards/ai-code-generation.md`.
    - Cover prompt hygiene, hallucination checks, human approval, test expectations, and review rules.

12. **Create configuration management standard**
    - Add `docs/standards/configuration-management.md`.
    - Cover environment variables, options validation, feature flags, defaults, and config drift.

13. **Create caching standard**
    - Add `docs/standards/caching.md`.
    - Cover cache keys, TTL, invalidation, stale data, authorization, and observability.

14. **Create accessibility standard**
    - Add `docs/standards/accessibility.md`.
    - Cover WCAG target, keyboard behavior, labels, contrast, testing, and review gates.

### P3 -- Skills And Starter Kits

15. **Expand skills**
    - Add CI/CD, Docker, profiling, refactoring, database-specific, and React sub-skills.

16. **Turn starter kits into runnable samples**
    - Add minimal working assets for Terraform AWS, GitLab CI, Kubernetes platform, MLOps, and .NET/React/AWS.

17. **Add platform/SRE agent**
    - Add SLO/SLI, error budget, capacity planning, incident, and observability responsibilities.

18. **Add data/ML agent if MLOps remains in scope**
    - Cover model validation, feature stores, drift detection, reproducibility, and governance.

### P3 -- Repository Hygiene

19. **Refresh vendor entry files**
    - Customize `CODEX.md`, `CLAUDE.md`, `GEMINI.md`, `CURSOR.md`, and `AIDER.md` for each tool's conventions while keeping `.ai` as the source of truth.

20. **Populate ADR-001**
    - Record adoption of Engineering AI OS as an accepted decision with context, alternatives, consequences, and review date.

21. **Add CONTRIBUTING.md**
    - Explain how to add workflows, commands, skills, standards, specs, and reference apps.

22. **Expand CHANGELOG.md**
    - Follow a simple Keep a Changelog style.

---

## Recommended Next Step

Start a second golden-path proof:

```text
Use the Engineering AI OS feature-development workflow and /implement-feature.

Feature SPEC: docs/specs/features/SCHEDULER_RETRY.md
Module SPEC: docs/specs/modules/SCHEDULER_SPEC.md

First provide scope, non-scope, assumptions, risks, affected files, implementation plan, tests, and verification commands.
Do not modify files until I approve the plan.
```

This will prove that the framework works beyond authentication and can guide background/operational behavior.
