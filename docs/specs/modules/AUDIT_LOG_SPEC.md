# AUDIT LOG SPEC

## Purpose

The Audit Log module records security- and business-relevant events for investigation, compliance review, and operational troubleshooting. It provides a consistent event contract for authentication, authorization, administrative actions, approvals, exports, and other auditable behavior.

## Responsibilities

- Define stable audit event names and required fields.
- Accept audit events from application modules.
- Preserve append-only audit records from the application perspective.
- Prevent sensitive values from being written to audit metadata.
- Support authorized search or export when that capability is in scope.
- Emit operational signals when audit writes fail.

## Dependencies

- Application services that emit auditable events
- Identity or user context provider
- Correlation id provider
- Audit storage or logging sink
- Authorization policy for audit readers
- Monitoring and alerting system

## APIs

No public API is required by default.

Optional internal/admin APIs:

- `GET /api/admin/audit-events`

The search API must require authorization, pagination, time-range filtering, and safe filtering by actor, target, action, and outcome.

## Data Model

- Audit event: id, event type, actor id, target type, target id, outcome, correlation id, safe metadata, created at.
- Actor context: user id, service id, or anonymous marker when identity is unknown.
- Metadata: structured key/value data that has passed sensitive-field filtering.

## Security

- Never store credentials, tokens, passwords, password hashes, private keys, raw session identifiers, or unnecessary PII.
- Restrict audit read access to approved support, security, compliance, or operator roles.
- Treat audit mutation and deletion as administrative operations outside normal application behavior.
- Apply retention policy and legal hold requirements when defined.

## Logging

Operational logs should record audit write failures with correlation id, event type, and failure class. They must not duplicate sensitive audit metadata.

## Tests

- Unit tests for required audit fields and sensitive-field filtering.
- Integration tests for audit writes from auth and approval flows.
- Security tests for audit read authorization.
- Regression tests for audit write failure behavior.

## Known Limitations

- Long-term retention duration is project-specific and must be defined by policy.
- Cross-system audit correlation depends on consistent correlation id propagation.
- Admin search UI is optional and must be specified separately.
