---
title: HasDomainEventsBase
uid: geaux.sharedkernal.domainevents.hasdomaineventsbase
---

# HasDomainEventsBase

Base type for entities that can publish domain events.
Stores events until they are dispatched and cleared.

```csharp
public abstract class HasDomainEventsBase : IHasDomainEvents
{
    private readonly List<DomainEventBase> _domainEvents = new();
    public IReadOnlyCollection<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();
    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}
```
