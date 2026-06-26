# LOGIN

## Objective

Allow a registered user to sign in with email and password and receive an authenticated session while preserving secure error handling, auditability, and testable behavior.

## Background

This feature is the reference example for the Engineering AI OS golden path. It demonstrates how a feature SPEC should connect business workflow, API contract, security requirements, logging, acceptance criteria, testing, rollback, and monitoring.

## Actors

- Registered user
- Auth service
- User identity store
- Audit logging pipeline
- Support or operations staff reviewing login issues

## Workflow

1. User enters email and password.
2. Client submits credentials to `POST /api/auth/login`.
3. Auth service validates request shape and required fields.
4. Auth service checks account status and verifies credentials.
5. On success, Auth service issues an access token and returns safe user profile fields.
6. On failure, Auth service returns a generic authentication error.
7. Auth service logs a structured audit event for success or failure.

## Business Rules

- Email is required and must be normalized before lookup.
- Password is required and must never be logged.
- Failed login responses must not reveal whether the email exists.
- Locked, disabled, or deleted accounts must not receive tokens.
- Successful login returns only the minimum user data needed by the client.
- Repeated failed attempts must trigger the configured abuse-prevention control.

## API Changes

Add or implement:

- `POST /api/auth/login`

Request body:

```json
{
  "email": "user@example.com",
  "password": "correct horse battery staple"
}
```

Success: `200 OK`

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

Validation failure: `400 Bad Request`

Authentication failure: `401 Unauthorized`

Locked or disabled account: `401 Unauthorized` with the same public message as invalid credentials.

## Database Changes

No mandatory schema change for the reference feature. If lockout or refresh-token persistence is not already available, create a separate migration SPEC before implementation.

## UI Changes

- Add a login form with email and password fields.
- Show field validation for missing or malformed input.
- Show a generic sign-in failure message.
- Do not display raw server errors.
- Preserve accessibility labels and keyboard navigation.

## Non-Functional Requirements

- Login response p95 should remain under the project-defined API latency target.
- Credential verification must use constant-time comparison where applicable.
- The endpoint must be safe under repeated failed attempts.
- The implementation must be testable without production credentials or live identity providers.

## Security

- Do not log credentials, tokens, password hashes, or raw session ids.
- Return generic authentication failures.
- Validate and normalize input before lookup.
- Enforce account status and lockout.
- Use signed, expiring tokens.
- Include authorization-sensitive behavior in tests.

## Logging

Emit structured events:

- `auth.login.succeeded`
- `auth.login.failed`
- `auth.login.locked_out`

Include correlation id, outcome, failure class, and safe user identifier when available.

## Monitoring

Track:

- Login success count
- Login failure count
- Lockout count
- Login latency
- Error rate by failure class

Alert when login failures spike, latency exceeds threshold, or token issuance errors increase.

## Acceptance Criteria

- Valid active user credentials return `200 OK`, an access token, expiry, and safe user profile fields.
- Invalid credentials return `401 Unauthorized` with a generic error message.
- Missing email or password returns `400 Bad Request` with validation details.
- Disabled or locked accounts do not receive tokens.
- No sensitive credential or token material appears in logs.
- Audit events are emitted for success and failure.
- Tests cover success, validation failure, authentication failure, locked account, and sensitive logging.

## Test Cases

- Unit: email normalization and validation.
- Unit: credential verification maps to success and failure outcomes.
- Unit: disabled and locked accounts reject login.
- Unit: error responses use the standard envelope.
- Integration: successful login returns expected response shape.
- Integration: invalid credentials return generic `401`.
- Integration: audit events are emitted without sensitive fields.
- UI: login form validates required fields.
- UI: failed login displays generic error.
- Security: logs and responses do not expose passwords or tokens.

## Feature Flags

No feature flag is required for the reference feature unless replacing an existing login path. If replacing an existing path, use a server-side flag that can route traffic back to the previous implementation.

## Risks

- Account enumeration through error messages or timing differences.
- Sensitive data leakage through logs, telemetry, or browser storage.
- Token expiry or clock-skew defects.
- Lockout behavior creating support burden or denial-of-service risk.

## Rollback Plan

- If the feature replaces an existing implementation, disable the routing flag and restore the previous login path.
- If a deployment introduces login failures, roll back the service version and validate login smoke tests.
- Preserve audit logs for investigation.

## Deployment Notes

- Confirm token signing configuration is present in each environment.
- Confirm audit logging sink is available.
- Run login smoke tests in non-production before production approval.
- Monitor login success/failure and latency immediately after deployment.

## Open Questions

- What is the exact lockout threshold and duration?
- Are refresh tokens required in the first implementation?
- Which roles must be returned to the client at login?
