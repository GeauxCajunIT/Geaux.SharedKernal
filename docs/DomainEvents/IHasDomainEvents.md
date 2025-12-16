---
title: IHasDomainEvents
uid: geaux.sharedkernal.domainevents.ihasdomainevents
---

# IHasDomainEvents

Contract for entities that produce domain events.

```csharp
public interface IHasDomainEvents
{
    IReadOnlyCollection<DomainEventBase> DomainEvents { get; }
}
```
