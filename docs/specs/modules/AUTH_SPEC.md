# AUTH SPEC

## Purpose

The Auth module owns user authentication, session issuance, session validation, logout, and security logging for identity-related events. It provides the baseline example module for the Engineering AI OS golden-path feature workflow.

## Responsibilities

- Validate login credentials without exposing sensitive details.
- Issue short-lived access tokens and optional refresh/session tokens.
- Enforce account status, lockout, and credential policy rules.
- Provide logout/session invalidation.
- Emit security-safe audit events for login success, login failure, lockout, and logout.
- Keep authentication APIs stable and backward compatible.

## Dependencies

- User identity store
- Password hashing and verification service
- Token signing service
- Clock/time provider
- Audit logging pipeline
- Rate limiting or abuse-prevention component

## APIs

### POST `/api/auth/login`

Authenticates a user and creates a session.

Request:

```json
{
  "email": "user@example.com",
  "password": "correct horse battery staple"
}
```

Success response:

```json
{
  "accessToken": "<jwt>",
  "expiresInSeconds": 900,
  "user": {
    "id": "usr_123",
    "email": "user@example.com",
    "displayName": "Example User",
    "roles": ["User"]
  }
}
```

Failure response uses the standard error envelope from `docs/standards/error-handling.md`.

### POST `/api/auth/logout`

Invalidates the current session or refresh token.

## Data Model

- User: id, email, display name, password hash, roles, account status, failed login count, lockout until.
- Session/refresh token: id, user id, token hash, issued at, expires at, revoked at.
- Audit event: id, event type, user id when known, correlation id, source IP hash when available, timestamp, outcome.

## Security

- Never log passwords, tokens, password hashes, or raw session identifiers.
- Use a generic login failure message for invalid credentials and disabled accounts.
- Apply rate limiting or progressive delay to repeated login attempts.
- Use secure password hashing with a modern adaptive algorithm.
- Tokens must be signed, expire, and include only required claims.
- Auth APIs must use HTTPS in deployed environments.

## Logging

Log structured events for:

- `auth.login.succeeded`
- `auth.login.failed`
- `auth.login.locked_out`
- `auth.logout.succeeded`

Each event should include correlation id, outcome, user id when safely known, and failure class. Do not include credentials or tokens.

## Tests

- Unit tests for credential validation, lockout, token creation, and error mapping.
- Integration tests for login success, login failure, logout, and account status.
- Security tests for generic failure responses and sensitive logging.
- Regression tests for token expiry and invalid session handling.

## Known Limitations

- Multi-factor authentication is out of scope for the initial LOGIN reference feature.
- Social login and SSO are out of scope unless a feature SPEC explicitly adds them.
