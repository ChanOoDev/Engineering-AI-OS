# Engineering AI OS User Guide

Use this guide set to apply the Engineering AI OS consistently across common software delivery work. The framework is SPEC-first, approval-gated, and evidence-driven.

## Start Here

1. Read `AI_OS.md`.
2. Read the guide that matches your use case.
3. Read the referenced workflow and command.
4. Read the relevant project, module, and feature SPECs.
5. Ask the AI agent for a plan.
6. Approve the plan before implementation.
7. Require verification evidence before review or deployment.

## Guides

- `GUIDE-ANALYZE-PROJECT.md`: understand a repository and identify improvement opportunities.
- `GUIDE-FEATURE-DEVELOPMENT.md`: take a feature from requirement to tested implementation.
- `GUIDE-BUG-FIX.md`: reproduce, fix, and verify a defect.
- `GUIDE-GENERATE-TESTS.md`: derive tests from SPECs, bugs, and acceptance criteria.
- `GUIDE-CODE-REVIEW.md`: review a PR or local diff.
- `GUIDE-SECURITY-REVIEW.md`: review auth, secrets, logging, dependencies, and abuse cases.
- `GUIDE-ARCHITECTURE-REVIEW.md`: compare options and record durable decisions.
- `GUIDE-PERFORMANCE-ANALYSIS.md`: measure and improve latency, throughput, capacity, or cost.
- `GUIDE-DEPLOYMENT-RELEASE.md`: assess deployment readiness, rollback, and release safety.
- `GUIDE-DOCUMENTATION-KNOWLEDGE.md`: update SPECs, ADRs, runbooks, and lessons learned.

## Core Rules

- No SPEC, no implementation.
- No approved plan, no implementation.
- No tests or verification evidence, no review approval.
- No rollback path, no production deployment.
- No secrets, credentials, production data, or unnecessary PII in prompts, logs, docs, or code.

## Recommended Prompt Pattern

```text
Use the Engineering AI OS.
Use [workflow/command name].
Read [SPEC paths] and [standards].
First provide understanding, assumptions, risks, plan, and verification steps.
Do not modify files until I approve the plan.
```

## What Good Output Looks Like

Good AI OS output is specific and auditable:

- It names the files, workflows, commands, and SPECs used.
- It separates scope from non-scope.
- It lists assumptions and open questions.
- It identifies risks before implementation.
- It includes tests and verification commands.
- It records residual risk and follow-up work.

## When To Stop

Stop and ask for clarification when:

- Expected behavior is unclear.
- Security, data, API, or deployment impact is undocumented.
- A change would break a public contract.
- Production access, secrets, or destructive actions are required.
- The requested work does not match the approved SPEC or plan.
