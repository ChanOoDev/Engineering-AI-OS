using System.Text.Json;
using System.Collections.Concurrent;
using ReferenceApi.Scheduler;
using Xunit;

namespace ReferenceApi.Tests;

public sealed class SchedulerRetryTests
{
    private static readonly RetryPolicy DefaultRetryPolicy = new(
        MaxAttempts: 3,
        BaseBackoff: TimeSpan.FromSeconds(10),
        RetryableFailureClasses: new HashSet<SchedulerFailureClass>
        {
            SchedulerFailureClass.TransientDependency,
            SchedulerFailureClass.Timeout
        });

    [Fact]
    public void RetryableFailure_SchedulesAnotherAttempt()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();

        var started = service.Start(definition, "corr_1");
        var failed = service.Fail(
            definition,
            started.Execution,
            SchedulerFailureClass.TransientDependency,
            "corr_1");

        Assert.True(failed.RetryScheduled);
        Assert.False(failed.RetryExhausted);
        Assert.Equal(JobExecutionStatus.RetryScheduled, failed.Execution.Status);
        Assert.Equal(1, failed.Execution.AttemptCount);
        Assert.NotNull(failed.Execution.NextRetryAt);
        Assert.Contains(eventSink.Events, item => item.EventType == "scheduler.job.retry_scheduled");
    }

    [Fact]
    public void NonRetryableFailure_DoesNotRetry()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();

        var started = service.Start(definition, "corr_2");
        var failed = service.Fail(
            definition,
            started.Execution,
            SchedulerFailureClass.Validation,
            "corr_2");

        Assert.False(failed.RetryScheduled);
        Assert.False(failed.RetryExhausted);
        Assert.Equal(JobExecutionStatus.Failed, failed.Execution.Status);
        Assert.Null(failed.Execution.NextRetryAt);
        Assert.DoesNotContain(eventSink.Events, item => item.EventType == "scheduler.job.retry_scheduled");
    }

    [Fact]
    public void RetryAttempts_StopAfterMaxAttempts()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();

        var first = service.Start(definition, "corr_3");
        var firstFailure = service.Fail(
            definition,
            first.Execution,
            SchedulerFailureClass.Timeout,
            "corr_3");
        var second = service.StartRetry(definition, firstFailure.Execution, "corr_3");
        var secondFailure = service.Fail(
            definition,
            second.Execution,
            SchedulerFailureClass.Timeout,
            "corr_3");
        var third = service.StartRetry(definition, secondFailure.Execution, "corr_3");
        var thirdFailure = service.Fail(
            definition,
            third.Execution,
            SchedulerFailureClass.Timeout,
            "corr_3");

        Assert.False(thirdFailure.RetryScheduled);
        Assert.True(thirdFailure.RetryExhausted);
        Assert.Equal(JobExecutionStatus.RetryExhausted, thirdFailure.Execution.Status);
        Assert.Equal(3, thirdFailure.Execution.AttemptCount);
        Assert.Contains(eventSink.Events, item => item.EventType == "scheduler.job.retry_exhausted");
    }

    [Fact]
    public void TransientFailure_CanSucceedOnRetry()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();

        var first = service.Start(definition, "corr_4");
        var firstFailure = service.Fail(
            definition,
            first.Execution,
            SchedulerFailureClass.TransientDependency,
            "corr_4");
        var retry = service.StartRetry(definition, firstFailure.Execution, "corr_4");
        var succeeded = service.Succeed(retry.Execution, "corr_4");

        Assert.Equal(JobExecutionStatus.Succeeded, succeeded.Status);
        Assert.Equal(2, succeeded.AttemptCount);
        Assert.Contains(eventSink.Events, item => item.EventType == "scheduler.job.succeeded");
    }

    [Fact]
    public void ConcurrentDuplicateStart_IsSuppressedForSameJob()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();

        var first = service.Start(definition, "corr_5");
        var duplicate = service.Start(definition, "corr_5");

        Assert.False(first.DuplicateSuppressed);
        Assert.True(duplicate.DuplicateSuppressed);
        Assert.Equal(first.Execution.ExecutionId, duplicate.Execution.ExecutionId);
    }

    [Fact]
    public void ParallelDuplicateStarts_AreSuppressedForSameJob()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();
        var results = new ConcurrentBag<JobRunResult>();

        Parallel.For(
            0,
            20,
            index => results.Add(service.Start(definition, $"corr_parallel_{index}")));

        Assert.Single(results, item => !item.DuplicateSuppressed);
        Assert.Equal(19, results.Count(item => item.DuplicateSuppressed));
        Assert.Single(results.Select(item => item.Execution.ExecutionId).Distinct());
    }

    [Fact]
    public void NonIdempotentJob_DoesNotRetry()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition(isIdempotent: false);

        var started = service.Start(definition, "corr_6");
        var failed = service.Fail(
            definition,
            started.Execution,
            SchedulerFailureClass.TransientDependency,
            "corr_6");

        Assert.False(failed.RetryScheduled);
        Assert.Equal(JobExecutionStatus.RetryExhausted, failed.Execution.Status);
    }

    [Fact]
    public void SchedulerEvents_DoNotContainSensitivePayloadValues()
    {
        var eventSink = new InMemorySchedulerEventSink();
        var service = new SchedulerService(eventSink);
        var definition = CreateDefinition();

        var started = service.Start(definition, "corr_7");
        service.Fail(
            definition,
            started.Execution,
            SchedulerFailureClass.TransientDependency,
            "corr_7");

        var eventText = JsonSerializer.Serialize(eventSink.Events);
        Assert.DoesNotContain("secret", eventText, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("payload", eventText, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("credential", eventText, StringComparison.OrdinalIgnoreCase);
    }

    private static JobDefinition CreateDefinition(bool isIdempotent = true)
    {
        return new JobDefinition(
            JobId: "job_inventory_sync",
            Name: "Inventory Sync",
            RetryPolicy: DefaultRetryPolicy,
            IsIdempotent: isIdempotent);
    }
}
