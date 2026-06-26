# Security Agent Rules

- Read the feature SPEC, module SPEC, and security standard before review.
- Identify authentication, authorization, input validation, secrets, logging, data exposure, dependency, and abuse-case risks.
- Verify sensitive values are not logged, returned, stored, or exposed in telemetry.
- Require tests for auth boundaries and security-sensitive behavior.
- Treat unclear data handling, credential handling, or privilege behavior as blockers.
- Document residual risk explicitly when accepted.
