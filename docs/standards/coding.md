# Coding Standard

Code should be readable, testable, scoped to the approved SPEC, and easy to review.

## Design

- Keep controllers and UI handlers thin.
- Put business rules in testable services or domain code.
- Keep persistence concerns behind clear repositories or data access boundaries.
- Prefer explicit request and response models.
- Avoid unrelated refactors in feature work.

## Naming

- Use names that describe behavior or business meaning.
- Avoid abbreviations unless they are standard in the domain.
- Keep file, class, function, and test names consistent with the module.

## Validation and Errors

- Validate input at system boundaries.
- Return structured errors using `docs/standards/error-handling.md`.
- Avoid leaking internal exception details to clients.
- Convert expected domain failures into documented outcomes.

## Tests

- Add or update tests with behavior changes.
- Keep tests deterministic and isolated.
- Prefer tests that describe behavior over implementation details.

## Review Readiness

Before review, confirm:

- Approved scope only
- No secrets or sensitive data
- Relevant tests pass
- Public contract changes are documented
- Logs and errors follow standards
