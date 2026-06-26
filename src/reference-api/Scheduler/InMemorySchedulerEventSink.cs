using System.Collections.Concurrent;

namespace ReferenceApi.Scheduler;

public interface ISchedulerEventSink
{
    void Record(SchedulerEvent schedulerEvent);
}

public sealed class InMemorySchedulerEventSink : ISchedulerEventSink
{
    private readonly ConcurrentQueue<SchedulerEvent> _events = new();

    public IReadOnlyCollection<SchedulerEvent> Events => _events.ToArray();

    public void Record(SchedulerEvent schedulerEvent)
    {
        _events.Enqueue(schedulerEvent);
    }
}
