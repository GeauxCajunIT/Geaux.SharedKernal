---
title: MediatRDomainEventDispatcher
uid: geaux.sharedkernal.domainevents.mediatrdispatcher
---

# MediatRDomainEventDispatcher

Default implementation of `IDomainEventDispatcher` using MediatR.
Publishes events and clears them from entities.

```csharp
public class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    public Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents);
}
```
