# Engineering AI OS v2.0

A vendor-neutral framework for AI-assisted software engineering.

## Purpose

Standardize how teams use AI agents for planning, specification, development, testing, review, deployment, and knowledge capture.

## Core Principles

- SPEC-first development
- Human approval before implementation and production deployment
- Reusable Skills, Commands, Agents, and Workflows
- Vendor-neutral `.ai` framework
- Secure-by-default engineering governance
- Continuous knowledge capture

## Recommended Workflow

Requirement -> SPEC -> Plan -> Approval -> Implement -> Test -> Review -> PR -> CI/CD -> Deploy -> Knowledge Update

## Reference App

This repository includes a minimal .NET reference API that demonstrates the AI OS golden path with the `LOGIN` feature.

- App: `src/reference-api`
- Tests: `tests/reference-api-tests`
- Golden-path records:
  - `examples/golden-path-login-reference.md`
  - `examples/golden-path-scheduler-retry-reference.md`
- Feature SPEC: `docs/specs/features/LOGIN.md`
- Module SPECs: `docs/specs/modules/AUTH_SPEC.md` and `docs/specs/modules/AUDIT_LOG_SPEC.md`

Run verification from the repository root:

```powershell
dotnet test
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\validate-framework.ps1
```

Run the API locally:

```powershell
dotnet run --project src/reference-api
```
