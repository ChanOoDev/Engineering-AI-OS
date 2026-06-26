# /update-docs

Update README, SPEC, ADR, runbook, release note, and troubleshooting docs.

## Required Input

- Change summary or files changed
- Documentation target: README, SPEC, ADR, runbook, release notes, standards, or examples
- Audience: developer, operator, reviewer, stakeholder, or end user
- Source of truth for behavior

## Read First

1. `AI_OS.md`
2. Relevant SPECs, standards, ADRs, and runbooks
3. Changed files or approved implementation summary
4. Existing docs in the target area

## Execution Steps

1. Determine Doc Impact
   - Identify behavior, API, configuration, deployment, operational, or workflow changes.
   - Decide whether docs need creation, update, or no change.

2. Preserve Source of Truth
   - Keep SPECs focused on intended behavior.
   - Keep ADRs focused on durable decisions.
   - Keep runbooks focused on repeatable operations.
   - Keep README content focused on orientation and quick start.

3. Update
   - Use existing templates and terminology.
   - Remove stale statements when replacing behavior.
   - Link related SPECs, ADRs, standards, runbooks, and examples.

4. Review
   - Check for contradictions across docs.
   - Confirm examples, commands, paths, and status codes are current.
   - Note unresolved documentation gaps separately.

## Output Format

- Docs updated
- Behavior or decision captured
- Related links
- Remaining documentation gaps

## Stop Conditions

- Behavior is not finalized or approved.
- Documentation would contradict an existing SPEC or ADR.
- Required source material is unavailable.
