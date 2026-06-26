# Guide: Performance Analysis

Use this guide when latency, throughput, memory, capacity, scalability, or cost is a concern.

## Use When

- A user flow is slow.
- An endpoint, query, job, or UI render regressed.
- A service needs capacity planning.
- Cost increased because of inefficient work.
- A review requires performance evidence.

## Use These AI OS Assets

- Workflow: `.ai/workflows/performance-analysis.md`
- Standard: `docs/standards/performance.md`
- Checklist: `.ai/checklists/performance.md`
- Relevant module and feature SPECs

## How To Ask

```text
Use the Engineering AI OS performance-analysis workflow.
Concern: [latency/throughput/cost/memory/capacity]
Affected path: [endpoint/job/query/UI/infrastructure]
Target or threshold: [target]
Available evidence: [metrics/logs/traces/profiles/test results]
First define the measurement plan and baseline needed before recommending fixes.
```

## Measurement Checklist

- Metric being optimized
- Target threshold
- Environment
- Data volume
- Concurrency or workload
- Tooling and command
- Baseline result
- Error rate
- After result

## Expected Output

- Performance question and target
- Baseline evidence
- Bottleneck analysis
- Candidate fixes and trade-offs
- Recommended fix
- Before and after comparison
- Monitoring or follow-up actions

## Effective Practice

- Use the same measurement method before and after.
- Avoid optimizing without evidence.
- Check correctness, security, and cost impact.
- Separate follow-up optimizations from the current fix.

## Common Mistakes

- Guessing the bottleneck.
- Comparing local and production results without context.
- Adding cache without invalidation rules.
- Scaling infrastructure before understanding the bottleneck.
