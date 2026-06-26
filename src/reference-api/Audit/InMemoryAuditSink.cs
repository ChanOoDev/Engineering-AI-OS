using System.Collections.Concurrent;

namespace ReferenceApi.Audit;

public interface IAuditSink
{
    void Record(AuditEvent auditEvent);
}

public sealed class InMemoryAuditSink : IAuditSink
{
    private readonly ConcurrentQueue<AuditEvent> _events = new();

    public IReadOnlyCollection<AuditEvent> Events => _events.ToArray();

    public void Record(AuditEvent auditEvent)
    {
        _events.Enqueue(auditEvent);
    }
}
