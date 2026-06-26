namespace ReferenceApi.Scheduler;

public sealed record SchedulerEvent(
    string EventType,
    string CorrelationId,
    string JobId,
    string ExecutionId,
    int AttemptCount,
    string Outcome,
    SchedulerFailureClass FailureClass,
    DateTimeOffset? NextRetryAt,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, string> Metadata)
{
    public static SchedulerEvent Create(
        string eventType,
        string correlationId,
        JobExecution execution,
        string outcome,
        SchedulerFailureClass failureClass,
        DateTimeOffset? nextRetryAt)
    {
        return new SchedulerEvent(
            eventType,
            correlationId,
            execution.JobId,
            execution.ExecutionId,
            execution.AttemptCount,
            outcome,
            failureClass,
            nextRetryAt,
            DateTimeOffset.UtcNow,
            new Dictionary<string, string>
            {
                ["source"] = "reference-api"
            });
    }
}
