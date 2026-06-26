# Guide: Documentation And Knowledge Capture

Use this guide to keep README files, SPECs, ADRs, runbooks, release notes, and lessons learned aligned with implementation.

## Use When

- Behavior changed.
- A durable decision was made.
- An operational procedure changed.
- A bug or incident produced a lesson.
- A reviewer asks for docs.

## Use These AI OS Assets

- Command: `.ai/commands/update-docs.md`
- Templates: `.ai/templates/`
- ADRs: `docs/adr/`
- Runbooks: `docs/runbooks/`
- Knowledge: `docs/knowledge/`
- Specs: `docs/specs/`

## How To Ask

```text
Use the Engineering AI OS /update-docs command.
Change summary: [summary]
Changed files or behavior: [details]
Audience: [developer/operator/reviewer/stakeholder/user]
Determine whether README, SPEC, ADR, runbook, release note, troubleshooting, or lessons learned docs need updates.
Update only docs that should be source of truth for this change.
```

## Where Information Belongs

- README: orientation, quick start, repository usage.
- Project SPEC: project-wide goals, non-goals, architecture, release model.
- Module SPEC: module responsibilities, APIs, data model, security, logging, tests.
- Feature SPEC: behavior, business rules, acceptance criteria, rollback, monitoring.
- ADR: durable decision and trade-offs.
- Runbook: repeatable operational procedure.
- Lessons learned: reusable insight from bugs, incidents, reviews, or delivery.

## Expected Output

- Docs updated
- Behavior or decision captured
- Related links
- Remaining documentation gaps
- Verification performed

## Common Mistakes

- Duplicating the same source of truth in several places.
- Updating README while leaving SPECs stale.
- Recording a durable architecture choice only in chat.
- Forgetting runbooks after deployment behavior changes.
