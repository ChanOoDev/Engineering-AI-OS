# /review-security

Perform secure code review against OWASP, secrets, auth, logging, and dependencies.

## Required Input

- PR, diff, feature SPEC, bug report, or files to review
- Data classification or sensitive-data context when relevant
- Auth, authorization, or identity expectations
- Dependency or infrastructure changes when relevant

## Read First

1. `.ai/agents/security/RULES.md`
2. `docs/standards/security.md`
3. `docs/standards/error-handling.md`
4. `docs/standards/logging.md`
5. Relevant SPECs and changed files

## Execution Steps

1. Scope
   - Identify entry points, trust boundaries, actors, assets, and sensitive data.
   - Note whether the change affects auth, authorization, storage, logging, dependencies, or infrastructure.

2. Threat Review
   - Check input validation, output encoding, authentication, authorization, session handling, secrets, injection, SSRF, CSRF, replay, rate limiting, and abuse cases where relevant.
   - Review error messages and logs for sensitive data exposure.

3. Evidence
   - Inspect tests for auth boundaries, forbidden paths, validation, and sensitive logging.
   - Check dependency or container changes for vulnerability review expectations.

4. Findings
   - Report confirmed issues first, ordered by severity.
   - Include file references, impact, exploitability, and recommended fix.
   - Separate assumptions, questions, and optional hardening.

5. Recommendation
   - Classify as approved, approved with follow-up, or blocked.
   - Require explicit acceptance for residual security risk.

## Output Format

- Findings
- Abuse cases reviewed
- Test gaps
- Sensitive data/logging assessment
- Approval recommendation

## Stop Conditions

- Security-sensitive behavior is undocumented.
- Required auth or data classification context is missing.
- Review requires access to secrets, production data, or live privileged systems.
