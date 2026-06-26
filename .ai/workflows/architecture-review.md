# Architecture Review Workflow

Use this workflow for new systems, major features, integration changes, cross-module decisions, platform changes, and any change that may affect scalability, security, operability, or long-term maintainability.

## Inputs

- Requirement, feature SPEC, proposal, or architecture question
- Current project and module SPECs
- Existing ADRs and architecture docs
- Constraints: business, security, data, latency, cost, compliance, and deployment
- Known alternatives or rejected approaches when available

## Agents

- Solution Architect: leads option analysis, trade-offs, and decision framing
- Backend, Frontend, Database, DevOps, or Security: reviews domain-specific impact
- Planner: converts the decision into implementation tasks when approved
- Reviewer: checks whether the final design satisfies constraints and standards
- Documentation: records ADRs, diagrams, and implementation guidance

## Flow

1. Context
   - State the decision to be made and why it matters now.
   - Identify affected users, systems, modules, APIs, data, infrastructure, and operations.
   - Read relevant SPECs, standards, ADRs, and current architecture docs.

2. Forces and Constraints
   - Capture functional requirements and non-functional requirements.
   - List constraints for security, compliance, performance, reliability, cost, team skill, delivery time, and operational support.
   - Separate hard constraints from preferences.

3. Options
   - Describe at least two viable options unless only one is technically feasible.
   - Include a "do nothing" or incremental option when relevant.
   - For each option, describe data flow, integration points, deployment impact, and ownership.

4. Trade-Off Analysis
   - Compare options against constraints.
   - Assess risks: security, data migration, vendor lock-in, latency, failure modes, operability, and reversibility.
   - Identify unknowns that need spikes, benchmarks, or stakeholder decisions.

5. Recommendation
   - Recommend one option with rationale.
   - State consequences and accepted risks.
   - Define guardrails, success metrics, migration path, rollback path, and review date.

6. Decision Record
   - Create or update an ADR when the decision is durable, cross-team, costly to reverse, or contract-impacting.
   - Update architecture docs and affected SPECs.

7. Implementation Guidance
   - Convert the decision into approved implementation phases.
   - Define test, security, observability, and deployment requirements.
   - Identify follow-up owners and open questions.

## Failure Branches

- Requirement unclear: pause and request clarification before comparing options.
- Missing current-state docs: document current assumptions before deciding.
- Security or compliance constraint unresolved: require Security review before recommendation.
- Data migration risk unclear: require Database review and rollback plan.
- Performance risk unknown: require benchmark or performance-analysis workflow.
- Decision is high impact but no ADR exists: create ADR before implementation.

## Done Criteria

- Decision context and constraints are documented.
- Options and trade-offs are compared.
- Recommendation includes consequences and accepted risks.
- ADR is created or explicitly not required.
- Implementation guidance, validation, rollback, and monitoring expectations are clear.
