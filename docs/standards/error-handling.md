# Error Handling Standard

Use this standard for API, service, UI, and operational error behavior.

## Principles

- Make errors actionable for clients and operators.
- Do not expose stack traces, secrets, credentials, tokens, or internal implementation details.
- Use stable error codes for expected failures.
- Use consistent HTTP status codes from `docs/standards/api.md`.
- Log enough context to investigate without leaking sensitive data.

## Error Envelope

APIs should return a consistent error shape:

```json
{
  "error": {
    "code": "AUTH_INVALID_CREDENTIALS",
    "message": "Invalid email or password.",
    "correlationId": "corr_123",
    "details": []
  }
}
```

## Error Classes

- Validation: caller supplied malformed or missing input.
- Authentication: caller is not authenticated or credentials are invalid.
- Authorization: caller is authenticated but not allowed.
- Conflict: requested state transition or uniqueness rule failed.
- Dependency: downstream service, database, queue, or provider failed.
- Timeout: operation exceeded its allowed time.
- Unexpected: unhandled server-side failure.

## Client Messages

- Use user-safe messages.
- Use generic messages for authentication failures.
- Keep detailed diagnostic context in logs, not public responses.

## Retry Guidance

- Validation, authentication, and authorization failures should not be retried unchanged.
- Timeout and dependency failures may be retried only when the operation is idempotent or safely guarded.
- Use `Retry-After` with `429 Too Many Requests` when possible.

## Review Gate

Before merge, confirm:

- Expected failures have documented status codes and error codes.
- Unexpected exceptions are logged with correlation id.
- Sensitive data is not exposed in responses or logs.
- Tests cover important error paths.
