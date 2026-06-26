# Security Standard

Security requirements apply to every feature, bug fix, workflow, and deployment.

## Baseline Rules

- Follow OWASP guidance for input validation, authentication, authorization, session management, and output encoding.
- Apply least privilege to users, services, infrastructure, and CI/CD identities.
- Never commit secrets, credentials, private keys, tokens, or production data.
- Never log passwords, tokens, secret values, raw session identifiers, or unnecessary PII.
- Treat all external input as untrusted.

## Authentication and Authorization

- Authenticate before granting access to protected resources.
- Authorize every sensitive action at the server side.
- Prefer deny-by-default policies.
- Test privilege boundaries and forbidden paths.
- Avoid relying on client-side checks for security.

## Secrets

- Store secrets in an approved secret manager or environment-specific secure store.
- Rotate secrets after exposure, employee transition, or provider guidance.
- Use short-lived credentials where possible.
- Do not print secrets in logs, CI output, exception messages, or telemetry.

## Data Protection

- Minimize sensitive data collection and retention.
- Encrypt sensitive data in transit and at rest where applicable.
- Mask or hash identifiers in logs when full values are not needed.
- Define retention and deletion expectations for sensitive records.

## Security Review Gate

Before implementation is considered done, confirm:

- Abuse cases are listed for security-sensitive features.
- Sensitive logs were checked.
- Auth and authorization tests exist when relevant.
- Dependency or container risk is reviewed when packages or images changed.
- Residual risk is documented when accepted.
