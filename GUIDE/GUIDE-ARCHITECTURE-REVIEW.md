# Guide: Architecture Review

Use this guide for major design choices, cross-module changes, integration decisions, platform changes, or durable technical trade-offs.

## Use When

- A decision affects scalability, security, operability, cost, or maintainability.
- Multiple implementation options exist.
- A change may require an ADR.
- A migration or integration needs phased rollout.

## Use These AI OS Assets

- Workflow: `.ai/workflows/architecture-review.md`
- Skill: `.ai/skills/architecture/adr.md`
- Template: `.ai/templates/adr.md`
- Existing ADRs: `docs/adr/`
- Architecture docs: `docs/architecture/`
- Relevant SPECs and standards

## How To Ask

```text
Use the Engineering AI OS architecture-review workflow.
Decision needed: [decision]
Read project/module/feature SPECs, architecture docs, ADRs, and standards first.
Compare at least two options, including an incremental option if relevant.
Evaluate security, data, performance, reliability, cost, operability, reversibility, and team fit.
Recommend one option and say whether an ADR is required.
```

## Expected Output

- Context and constraints
- Options considered
- Trade-off analysis
- Recommendation
- Consequences and accepted risks
- Implementation guidance
- ADR or documentation updates

## ADR Gate

Create or update an ADR when the decision is:

- Costly to reverse
- Cross-team or cross-module
- Security or compliance relevant
- Contract-impacting
- Infrastructure or platform defining

## Common Mistakes

- Comparing options before constraints are clear.
- Ignoring migration or rollback.
- Treating preferences as hard constraints.
- Making durable decisions without recording an ADR.
