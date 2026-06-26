# Performance Analysis Workflow

Use this workflow when latency, throughput, capacity, memory, cost, or scalability is a concern. Performance work must start with a baseline and end with measured verification.

## Inputs

- Performance symptom, target, or regression report
- Affected endpoint, job, UI flow, query, service, or infrastructure component
- Baseline metrics, logs, traces, profiles, or test results
- Expected service level or business threshold
- Recent changes that may have affected performance

## Agents

- Planner: scopes investigation and defines measurement plan
- Backend, Frontend, Database, or DevOps: investigates the affected layer
- QA: validates performance test method and regression coverage
- Security: reviews changes that affect caching, data exposure, auth, or rate limiting
- Reviewer: checks that fixes are measured and scoped

## Flow

1. Define Target
   - State the performance question and desired outcome.
   - Identify metric: latency, throughput, CPU, memory, queue time, error rate, cost, or user-perceived delay.
   - Define success threshold and measurement environment.

2. Baseline
   - Capture current measurements before changing code.
   - Record inputs, data volume, environment, concurrency, and tooling.
   - Separate user-facing latency from dependency, query, network, queue, or render time.

3. Bottleneck Analysis
   - Use logs, metrics, traces, profiles, query plans, or browser tools to localize the bottleneck.
   - Check recent code, dependency, config, data, and infrastructure changes.
   - Avoid optimizing without evidence.

4. Options
   - Identify candidate fixes such as query/index change, caching, batching, async processing, payload reduction, rendering optimization, scaling, or configuration change.
   - Assess correctness, security, cost, complexity, and rollback impact.
   - Prefer the smallest measured fix that meets the target.

5. Implement or Recommend
   - If approved, implement the scoped fix.
   - Add tests or safeguards for correctness and regression risk.
   - Update docs when thresholds, dashboards, or operational behavior change.

6. Verify
   - Re-run the same measurement method used for the baseline.
   - Compare before and after metrics.
   - Check for secondary effects such as increased cost, stale data, higher memory, or reduced reliability.

7. Monitor
   - Define dashboard or query for ongoing tracking.
   - Add alert thresholds for business-critical paths.
   - Record follow-up optimization opportunities separately.

## Failure Branches

- No baseline exists: gather baseline before recommending fixes.
- Target is undefined: request service-level or business threshold.
- Results cannot be reproduced: document environment and measurement limits.
- Fix risks correctness or data exposure: require review before implementation.
- Improvement is insufficient: return to bottleneck analysis with updated evidence.

## Done Criteria

- Baseline and after metrics are recorded.
- Bottleneck evidence supports the chosen fix.
- Success threshold is met or residual gap is documented.
- Correctness, security, and rollback risks are reviewed.
- Monitoring or follow-up actions are recorded.
