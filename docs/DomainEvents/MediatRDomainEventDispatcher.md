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
    public async Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents)
    {
        // publishes events via IMediator
    }
}
