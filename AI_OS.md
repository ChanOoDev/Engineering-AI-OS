# Engineering AI OS Overview

Engineering AI OS is an operating model for AI-assisted engineering teams.

## Main Components

- `.ai/agents` - specialized AI roles
- `.ai/skills` - reusable technical knowledge
- `.ai/commands` - repeatable execution workflows
- `.ai/workflows` - lifecycle flows
- `.ai/templates` - SPEC, ADR, PR, incident templates
- `docs/specs` - project, module, and feature specifications
- `docs/standards` - coding, security, testing, deployment rules

## Golden Rule

No SPEC -> No Plan -> No Implementation -> No Test -> No Review -> No Deployment

## Golden Path

Use `.ai/workflows/feature-development.md` and `.ai/commands/implement-feature.md` as the reference path for feature delivery. Other workflows should follow the same pattern: explicit inputs, readiness gates, agent responsibilities, verification, failure branches, and done criteria.
