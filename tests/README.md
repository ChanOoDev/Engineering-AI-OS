# Tests

Unit, integration, regression, and E2E tests live here.

## Reference API Tests

`reference-api-tests` verifies the `LOGIN` reference API against the feature and module SPECs.

It covers:

- Successful login
- Validation failures
- Generic invalid credential responses
- Locked and disabled account behavior
- Standard error envelope shape
- Safe audit event emission

Run from the repository root:

```powershell
dotnet test
```
