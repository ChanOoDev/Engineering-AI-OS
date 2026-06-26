# Guide: Feature Development

Use this guide to move a feature from requirement to implementation using the SPEC-first golden path.

## Use When

- You are building a new feature.
- You are changing user-facing or service-facing behavior.
- You are adding or changing an API, database model, UI flow, or business rule.

## Use These AI OS Assets

- Workflow: `.ai/workflows/feature-development.md`
- Command: `.ai/commands/implement-feature.md`
- Template: `.ai/templates/feature-spec.md`
- Project SPEC: `docs/specs/project/PROJECT_SPEC.md`
- Module SPEC: `docs/specs/modules/*.md`
- Feature SPEC: `docs/specs/features/*.md`
- Standards: `docs/standards/coding.md`, `api.md`, `error-handling.md`, `security.md`, `testing.md`, `logging.md`, `performance.md`

## How To Ask For Planning

```text
Use the Engineering AI OS feature-development workflow and /implement-feature.
Feature SPEC: [path]
Module SPEC: [path]
Read the project SPEC and relevant standards first.
First provide scope, non-scope, assumptions, risks, implementation plan, affected files, and verification steps.
Do not modify files until I approve the plan.
```

## Approval Gate

Approve implementation only after the plan includes:

- Clear scope and non-scope
- Affected files or areas
- Security and data impact
- API and database impact
- Tests to add or update
- Rollback approach
- Monitoring or logging expectations

## How To Ask For Implementation

```text
I approve the plan for [feature name].
Implement only the approved scope.
Add or update tests with the change.
Run targeted verification and summarize changed files, behavior, tests, and risks.
```

## Expected Final Output

- Changes made
- Tests added or updated
- Verification commands and results
- Docs updated
- Risks and follow-ups
- Release or deployment notes

## Common Mistakes

- Starting implementation before the feature SPEC is ready.
- Hiding assumptions inside code instead of recording them.
- Changing API contracts without explicit approval.
- Adding behavior without tests.
- Forgetting rollback, monitoring, or release notes.
