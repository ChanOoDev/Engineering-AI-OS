namespace ReferenceApi.Scheduler;

public enum JobExecutionStatus
{
    Running,
    Succeeded,
    RetryScheduled,
    Failed,
    RetryExhausted
}

public enum SchedulerFailureClass
{
    None,
    TransientDependency,
    Timeout,
    Validation,
    Authorization,
    Unexpected
}

public sealed record RetryPolicy(
    int MaxAttempts,
    TimeSpan BaseBackoff,
    IReadOnlySet<SchedulerFailureClass> RetryableFailureClasses)
{
    public bool CanRetry(SchedulerFailureClass failureClass, int currentAttempt)
    {
        return currentAttempt < MaxAttempts && RetryableFailureClasses.Contains(failureClass);
    }

    public TimeSpan GetBackoff(int attempt)
    {
        var multiplier = Math.Max(1, attempt);
        return TimeSpan.FromTicks(BaseBackoff.Ticks * multiplier);
    }
}

public sealed record JobDefinition(
    string JobId,
    string Name,
    RetryPolicy RetryPolicy,
    bool IsIdempotent);

public sealed record JobExecution(
    string ExecutionId,
    string JobId,
    JobExecutionStatus Status,
    int AttemptCount,
    DateTimeOffset StartedAt,
    DateTimeOffset? CompletedAt,
    DateTimeOffset? NextRetryAt,
    SchedulerFailureClass LastFailureClass);

public sealed record JobRunResult(
    JobExecution Execution,
    bool DuplicateSuppressed);

public sealed record JobFailureResult(
    JobExecution Execution,
    bool RetryScheduled,
    bool RetryExhausted);
