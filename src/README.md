# Source Code

Application source code lives here.

## Reference API

`reference-api` is a minimal ASP.NET Core API that proves the Engineering AI OS golden path for the `LOGIN` feature.

It demonstrates:

- `POST /api/auth/login`
- In-memory user store
- Standard error envelope
- Generic authentication failures
- Safe login response
- Structured audit events for login success, failure, and lockout
- In-memory scheduler retry policy for retryable and non-retryable job failures

The password hasher and token issuer are intentionally demo-only. Production applications should use ASP.NET Core Identity or another approved authentication stack with adaptive password hashing and signed tokens.

Run locally from the repository root:

```powershell
dotnet run --project src/reference-api
```
