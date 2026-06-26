using System.Collections.Concurrent;

namespace ReferenceApi.Scheduler;

public sealed class SchedulerService(ISchedulerEventSink eventSink)
{
    private readonly ConcurrentDictionary<string, JobExecution> _executions = new();
    private readonly ConcurrentDictionary<string, string> _runningExecutionIdsByJob = new();

    public JobRunResult Start(JobDefinition definition, string correlationId)
    {
        var execution = new JobExecution(
            ExecutionId: $"exec_{Guid.NewGuid():N}",
            JobId: definition.JobId,
            Status: JobExecutionStatus.Running,
            AttemptCount: 1,
            StartedAt: DateTimeOffset.UtcNow,
            CompletedAt: null,
            NextRetryAt: null,
            LastFailureClass: SchedulerFailureClass.None);

        _executions[execution.ExecutionId] = execution;

        if (!_runningExecutionIdsByJob.TryAdd(definition.JobId, execution.ExecutionId))
        {
            _executions.TryRemove(execution.ExecutionId, out _);

            return new JobRunResult(
                _executions[_runningExecutionIdsByJob[definition.JobId]],
                DuplicateSuppressed: true);
        }

        eventSink.Record(SchedulerEvent.Create(
            "scheduler.job.started",
            correlationId,
            execution,
            "started",
            SchedulerFailureClass.None,
            null));

        return new JobRunResult(execution, DuplicateSuppressed: false);
    }

    public JobExecution Succeed(JobExecution execution, string correlationId)
    {
        var updated = execution with
        {
            Status = JobExecutionStatus.Succeeded,
            CompletedAt = DateTimeOffset.UtcNow,
            LastFailureClass = SchedulerFailureClass.None
        };

        _executions[updated.ExecutionId] = updated;
        _runningExecutionIdsByJob.TryRemove(updated.JobId, out _);

        eventSink.Record(SchedulerEvent.Create(
            "scheduler.job.succeeded",
            correlationId,
            updated,
            "success",
            SchedulerFailureClass.None,
            null));

        return updated;
    }

    public JobFailureResult Fail(
        JobDefinition definition,
        JobExecution execution,
        SchedulerFailureClass failureClass,
        string correlationId)
    {
        eventSink.Record(SchedulerEvent.Create(
            "scheduler.job.failed",
            correlationId,
            execution,
            "failure",
            failureClass,
            null));

        if (!definition.IsIdempotent || !definition.RetryPolicy.CanRetry(failureClass, execution.AttemptCount))
        {
            var exhausted = execution with
            {
                Status = definition.RetryPolicy.RetryableFailureClasses.Contains(failureClass)
                    ? JobExecutionStatus.RetryExhausted
                    : JobExecutionStatus.Failed,
                CompletedAt = DateTimeOffset.UtcNow,
                LastFailureClass = failureClass
            };

            _executions[exhausted.ExecutionId] = exhausted;
            _runningExecutionIdsByJob.TryRemove(exhausted.JobId, out _);

            if (exhausted.Status is JobExecutionStatus.RetryExhausted)
            {
                eventSink.Record(SchedulerEvent.Create(
                    "scheduler.job.retry_exhausted",
                    correlationId,
                    exhausted,
                    "failure",
                    failureClass,
                    null));
            }

            return new JobFailureResult(
                exhausted,
                RetryScheduled: false,
                RetryExhausted: exhausted.Status is JobExecutionStatus.RetryExhausted);
        }

        var nextRetryAt = DateTimeOffset.UtcNow + definition.RetryPolicy.GetBackoff(execution.AttemptCount);
        var retryScheduled = execution with
        {
            Status = JobExecutionStatus.RetryScheduled,
            CompletedAt = DateTimeOffset.UtcNow,
            NextRetryAt = nextRetryAt,
            LastFailureClass = failureClass
        };

        _executions[retryScheduled.ExecutionId] = retryScheduled;
        _runningExecutionIdsByJob.TryRemove(retryScheduled.JobId, out _);

        eventSink.Record(SchedulerEvent.Create(
            "scheduler.job.retry_scheduled",
            correlationId,
            retryScheduled,
            "retry_scheduled",
            failureClass,
            nextRetryAt));

        return new JobFailureResult(retryScheduled, RetryScheduled: true, RetryExhausted: false);
    }

    public JobRunResult StartRetry(JobDefinition definition, JobExecution previousExecution, string correlationId)
    {
        if (previousExecution.Status is not JobExecutionStatus.RetryScheduled)
        {
            throw new InvalidOperationException("Only retry-scheduled executions can start another attempt.");
        }

        var nextAttempt = previousExecution.AttemptCount + 1;

        var execution = new JobExecution(
            ExecutionId: $"exec_{Guid.NewGuid():N}",
            JobId: definition.JobId,
            Status: JobExecutionStatus.Running,
            AttemptCount: nextAttempt,
            StartedAt: DateTimeOffset.UtcNow,
            CompletedAt: null,
            NextRetryAt: null,
            LastFailureClass: SchedulerFailureClass.None);

        _executions[execution.ExecutionId] = execution;

        if (!_runningExecutionIdsByJob.TryAdd(definition.JobId, execution.ExecutionId))
        {
            _executions.TryRemove(execution.ExecutionId, out _);

            return new JobRunResult(
                _executions[_runningExecutionIdsByJob[definition.JobId]],
                DuplicateSuppressed: true);
        }

        eventSink.Record(SchedulerEvent.Create(
            "scheduler.job.started",
            correlationId,
            execution,
            "started",
            SchedulerFailureClass.None,
            null));

        return new JobRunResult(execution, DuplicateSuppressed: false);
    }
}
