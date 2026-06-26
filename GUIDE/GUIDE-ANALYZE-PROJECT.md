# Guide: Analyze A Project

Use this guide when onboarding to a repository, auditing framework maturity, preparing an improvement backlog, or asking an AI agent to explain architecture and risks.

## Use When

- You inherit a codebase.
- You need a repository health check.
- You want improvement opportunities ranked by impact.
- You need to compare implementation against documentation.

## Use These AI OS Assets

- Command: `.ai/commands/analyze-project.md`
- Workflow: `.ai/workflows/architecture-review.md` when design decisions are involved
- Project SPEC: `docs/specs/project/PROJECT_SPEC.md`
- Architecture docs: `docs/architecture/`
- Standards: `docs/standards/`

## How To Ask

```text
Use the Engineering AI OS and /analyze-project.
Analyze this repository for architecture, module boundaries, standards coverage, risks, and improvement opportunities.
Read AI_OS.md, README.md, docs/specs/project/PROJECT_SPEC.md, docs/architecture, and docs/standards first.
Return findings by priority with concrete file references.
Do not modify files.
```

## Expected Output

- Repository summary
- Architecture and module map
- Confirmed strengths
- Findings by priority
- Recommended next steps
- Open questions and assumptions

## Effective Practice

- Ask for confirmed evidence, not guesses.
- Separate current-state analysis from proposed changes.
- Ask the agent to identify stale docs and placeholder files.
- Convert findings into a backlog only after reviewing the evidence.

## Common Mistakes

- Asking for improvements before the agent reads the repository.
- Treating every suggestion as equally urgent.
- Allowing broad refactors without a SPEC or approved plan.
- Ignoring test, deployment, and rollback gaps.
