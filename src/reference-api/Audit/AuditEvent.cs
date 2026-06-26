namespace ReferenceApi.Audit;

public sealed record AuditEvent(
    string EventType,
    string CorrelationId,
    string Outcome,
    string FailureClass,
    string? ActorId,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, string> Metadata)
{
    public static AuditEvent Create(
        string eventType,
        string correlationId,
        string outcome,
        string failureClass,
        string? actorId)
    {
        return new AuditEvent(
            eventType,
            correlationId,
            outcome,
            failureClass,
            actorId,
            DateTimeOffset.UtcNow,
            new Dictionary<string, string>
            {
                ["source"] = "reference-api"
            });
    }
}
