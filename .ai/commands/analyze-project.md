# /analyze-project

Scan repository, summarize architecture, modules, risks, and improvement opportunities.

## Required Input

- Repository path or current workspace
- Analysis goal, such as onboarding, architecture review, risk review, or improvement planning
- Optional focus area: backend, frontend, data, infrastructure, security, testing, or operations

## Read First

1. `AI_OS.md`
2. `README.md`
3. `docs/specs/project/PROJECT_SPEC.md`
4. Existing architecture docs in `docs/architecture/`
5. Relevant standards in `docs/standards/`

## Execution Steps

1. Inventory
   - Identify languages, frameworks, entry points, build files, tests, infrastructure, and documentation.
   - Separate production code from examples, generated files, and placeholders.

2. Architecture Summary
   - Describe major modules, boundaries, dependencies, data flows, and deployment shape.
   - Note where the current implementation differs from the documented architecture.

3. Quality Review
   - Review testing, security, logging, performance, error handling, and deployment readiness.
   - Identify missing contracts, weak standards, duplicate guidance, and stale documentation.

4. Risk Assessment
   - Classify findings by severity and blast radius.
   - Distinguish confirmed issues from assumptions that need follow-up evidence.

5. Recommendations
   - Propose prioritized improvements with concrete files or areas to change.
   - Prefer small, sequenced improvements over broad rewrites.

## Output Format

- Repository summary
- Architecture and module map
- Confirmed strengths
- Findings by priority
- Recommended next steps
- Open questions and assumptions

## Stop Conditions

- Repository cannot be read.
- Required context is missing and assumptions would materially change the recommendation.
- Analysis requires production credentials, private data, or destructive commands.
