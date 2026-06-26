namespace ReferenceApi.Errors;

public sealed record ErrorEnvelope(ErrorBody Error)
{
    public static ErrorEnvelope Create(
        string code,
        string message,
        string correlationId,
        IReadOnlyList<string>? details = null)
    {
        return new ErrorEnvelope(new ErrorBody(code, message, correlationId, details ?? []));
    }
}

public sealed record ErrorBody(
    string Code,
    string Message,
    string CorrelationId,
    IReadOnlyList<string> Details);
