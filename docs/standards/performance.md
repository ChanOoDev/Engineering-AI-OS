# Performance Standard

Use this standard for features, fixes, infrastructure changes, and reviews that affect latency, throughput, capacity, memory, scalability, or cost.

## Principles

- Define the performance target before implementation.
- Measure before optimizing.
- Use the same method for baseline and after measurements.
- Optimize the measured bottleneck, not the most visible code.
- Treat correctness, security, reliability, and data freshness as constraints.

## Targets

Every performance-sensitive change should define the relevant target:

- User-facing latency, such as p95 or p99 response time.
- Throughput, such as requests, jobs, events, or records per second.
- Resource use, such as CPU, memory, database load, queue depth, network, or storage.
- Cost, such as cloud spend, query cost, or per-transaction cost.
- Scalability limit, such as concurrent users, tenants, data volume, or batch size.

When no product-specific target exists, document the temporary assumption and create a follow-up to define one.

## Measurement

Record enough context for results to be reproducible:

- Environment and version under test.
- Data volume and shape.
- Concurrency and request mix.
- Test duration and warm-up period.
- Tooling and command used.
- Baseline and after metrics.
- Error rate during the test.

Do not compare local measurements with production measurements unless the difference is explicitly called out.

## Common Bottlenecks

Review the affected layer before changing code:

- API: expensive serialization, chatty calls, blocking I/O, missing pagination, excessive payloads.
- Database: missing indexes, N+1 queries, table scans, lock contention, inefficient migrations.
- Frontend: unnecessary renders, large bundles, slow hydration, unbounded lists, oversized assets.
- Messaging and jobs: queue backlog, retry storms, batch size, idempotency, dependency throttling.
- Infrastructure: under-sized resources, cold starts, connection limits, autoscaling lag, network latency.

## Fix Patterns

Prefer fixes that are measurable, reversible, and scoped:

- Add or tune indexes with migration and rollback guidance.
- Reduce payload size and avoid unbounded queries.
- Batch or debounce repeated work.
- Cache only when invalidation, TTL, authorization, and data freshness are clear.
- Move long-running work to asynchronous processing when user flow allows it.
- Tune concurrency, connection pools, timeouts, and retry policies carefully.
- Scale infrastructure only after application and data bottlenecks are understood.

## Caching Rules

- Define owner, cache key, TTL, invalidation trigger, and stale-data tolerance.
- Do not cache user-specific or authorization-sensitive data without explicit review.
- Include cache hit rate and failure behavior in monitoring.
- Provide a bypass or rollback path for high-risk caches.

## Database Rules

- Review query plans for high-volume or high-latency queries.
- Add indexes with write-impact and storage-impact review.
- Avoid migrations that lock large tables without an execution and rollback plan.
- Keep batch jobs resumable and idempotent.

## Verification Gate

Before performance work is considered done, confirm:

- Baseline and after metrics are recorded.
- The chosen fix maps to bottleneck evidence.
- Success threshold is met or residual gap is documented.
- Error rate, correctness, security, and cost were checked.
- Monitoring or alerting exists for business-critical paths.
