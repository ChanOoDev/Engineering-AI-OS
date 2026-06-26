# API Standard

Use this standard for HTTP APIs and service contracts.

## Contract Design

- Use resource-oriented URLs and consistent HTTP methods.
- Keep public contracts backward compatible by default.
- Use request and response DTOs rather than exposing persistence models.
- Validate all input at the boundary.
- Document every endpoint with request shape, response shape, status codes, auth requirements, and examples.

## Status Codes

- `200 OK`: successful read or command with response body.
- `201 Created`: resource created.
- `204 No Content`: successful command without response body.
- `400 Bad Request`: validation or malformed input.
- `401 Unauthorized`: unauthenticated or invalid credentials.
- `403 Forbidden`: authenticated but not allowed.
- `404 Not Found`: resource not found or intentionally hidden.
- `409 Conflict`: version, uniqueness, or state conflict.
- `429 Too Many Requests`: rate limit exceeded.
- `500 Internal Server Error`: unexpected server failure.

## Response Shape

Successful responses should be stable, minimal, and explicit. Error responses must use the standard error envelope from `docs/standards/error-handling.md`.

## Pagination and Filtering

- Use explicit pagination parameters for list endpoints.
- Include stable ordering when paginating.
- Validate filters and reject unsupported fields.
- Avoid unbounded list responses.

## Versioning

- Prefer backward-compatible additive changes.
- Use URL or header versioning consistently within a system.
- Deprecate old versions with notice, migration guidance, and removal date.
- Breaking changes require SPEC approval.

## Compatibility Gate

Before merging API changes, verify:

- Existing clients are not broken.
- Error codes remain documented.
- Auth and authorization behavior is explicit.
- Tests cover success, validation, authorization, and failure cases.
