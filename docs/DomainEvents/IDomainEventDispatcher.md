---
title: IDomainEventDispatcher
uid: geaux.sharedkernal.domainevents.idomaineventdispatcher
---

# IDomainEventDispatcher

Abstraction for dispatching domain events.

```csharp
public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents);
}
