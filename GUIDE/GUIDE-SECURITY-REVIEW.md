# Guide: Security Review

Use this guide for security-sensitive features, PRs, architecture choices, deployments, or incident follow-ups.

## Use When

- A change touches authentication or authorization.
- Sensitive data, secrets, tokens, or PII are involved.
- Logging, telemetry, dependencies, or infrastructure permissions change.
- A review needs abuse-case thinking.

## Use These AI OS Assets

- Command: `.ai/commands/review-security.md`
- Agent rules: `.ai/agents/security/RULES.md`
- Standards: `docs/standards/security.md`, `logging.md`, `error-handling.md`, `api.md`
- Relevant feature and module SPECs

## How To Ask

```text
Use the Engineering AI OS /review-security command.
Review [diff/feature/SPEC/files].
Read the security, logging, and error-handling standards first.
Identify trust boundaries, sensitive data, abuse cases, auth risks, secrets risks, logging risks, dependency risks, and missing tests.
Lead with findings by severity.
```

## Security Checklist

- Authentication is required where needed.
- Authorization is enforced server-side.
- Inputs are validated at boundaries.
- Secrets and tokens are not logged or returned.
- Error messages do not expose internals.
- Sensitive data is minimized and protected.
- Dependencies and images are reviewed when changed.
- Abuse cases and rate limiting are considered.
- Security-sensitive behavior has tests.

## Expected Output

- Security findings by severity
- Abuse cases reviewed
- Sensitive data and logging assessment
- Test gaps
- Residual risk and approval recommendation

## Common Mistakes

- Treating client-side checks as authorization.
- Logging full payloads for debugging.
- Returning different auth errors that allow enumeration.
- Accepting residual risk without an owner.
