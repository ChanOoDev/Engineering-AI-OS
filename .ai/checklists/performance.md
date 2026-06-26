# Performance Checklist

- Performance target or symptom is defined
- Baseline metrics captured before changes
- Measurement environment and data volume recorded
- Bottleneck evidence collected from logs, metrics, traces, profiles, query plans, or browser tools
- Recent changes reviewed
- Candidate fixes compared for correctness, security, cost, complexity, and rollback risk
- Caching, batching, indexing, payload size, rendering, scaling, and config considered where relevant
- Fix is scoped to measured bottleneck
- Before/after metrics recorded
- Secondary effects checked: cost, memory, stale data, error rate, and reliability
- Monitoring or alerting updates identified
- Follow-up optimization separated from current fix
