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
```

Implementations can use MediatR or any other mechanism to publish and then clear the domain events captured on aggregates.
