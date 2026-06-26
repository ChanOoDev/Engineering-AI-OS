# Logging Standard

Logs must help operators understand behavior without exposing sensitive data.

## Structured Logging

- Use structured events with stable event names.
- Include correlation id or trace id where available.
- Include outcome, failure class, and safe entity identifiers when useful.
- Avoid relying on free-form messages for operational dashboards.

## Sensitive Data

Never log:

- Passwords
- Tokens
- Secret values
- Raw session identifiers
- Payment details
- Unnecessary PII

Mask, hash, or omit sensitive fields.

## Error Classification

Classify failures as validation, authentication, authorization, dependency, timeout, conflict, or unexpected. Use classifications consistently across logs, metrics, and error responses.

## Operational Use

Features should identify:

- Success event
- Failure event
- Important audit event
- Dashboard or query needed for release validation
- Alert signal when the feature is business critical
