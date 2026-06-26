# Project SPEC

## Business Overview

Engineering AI OS is a vendor-neutral operating model for teams that use AI agents across software delivery. It standardizes how requirements become SPECs, plans, implementation, tests, reviews, deployments, and durable knowledge.

The framework is intentionally tool-agnostic. Vendor entry files such as `CODEX.md`, `CLAUDE.md`, `GEMINI.md`, `AIDER.md`, and `CURSOR.md` should all point agents back to the same `.ai` framework.

## Goals

- Make AI-assisted engineering predictable, auditable, and repeatable.
- Require a SPEC before planning or implementation.
- Separate roles for planning, backend, frontend, QA, security, review, DevOps, and documentation.
- Provide reusable commands, workflows, templates, skills, standards, and memory.
- Keep human approval in front of implementation scope changes and production deployment.

## Non-Goals

- This repository is not a production application by itself.
- This repository does not prescribe a single vendor, LLM, IDE, cloud provider, or programming language.
- Starter kits are reference accelerators, not mandatory architecture.

## Tech Stack

The framework supports common enterprise stacks, with initial references for:

- Backend: .NET APIs and clean architecture
- Frontend: React UI patterns
- Infrastructure: AWS, Terraform, Kubernetes, GitLab CI/CD
- Quality: unit, integration, regression, E2E, security, and performance review
- Operations: logging, deployment, incident response, and knowledge capture

## Architecture

Core structure:

- `.ai/agents` defines role-specific agent responsibilities.
- `.ai/commands` defines repeatable execution playbooks.
- `.ai/workflows` defines lifecycle processes and gates.
- `.ai/skills` stores reusable technical guidance.
- `.ai/templates` stores reusable SPEC, ADR, PR, bug, and incident formats.
- `docs/specs` stores project, module, and feature specifications.
- `docs/standards` stores engineering rules that every agent should apply.
- `docs/runbooks` stores operational procedures.
- `docs/knowledge` stores lessons learned and durable team knowledge.

## Standards

All feature work must consider:

- Coding: `docs/standards/coding.md`
- API: `docs/standards/api.md`
- Error handling: `docs/standards/error-handling.md`
- Security: `docs/standards/security.md`
- Testing: `docs/standards/testing.md`
- Logging: `docs/standards/logging.md`
- Performance: `docs/standards/performance.md`

## Environments

Recommended environment model:

- Local: developer validation and fast feedback.
- CI: automated linting, tests, security checks, and artifact creation.
- Non-production: integrated validation, smoke tests, and stakeholder review.
- Production: controlled release with explicit approval, monitoring, and rollback readiness.

## Release Strategy

- Every change starts from a SPEC or a documented bug/incident.
- Implementation requires an approved plan.
- Pull requests must include evidence of tests and self-review.
- Production deployment requires explicit human approval.
- Release notes must include user impact, operational impact, rollback steps, and monitoring signals.
