---
title: DomainEventBase
uid: geaux.sharedkernal.domainevents.domaineventbase
---

# DomainEventBase

Base type for domain events.
Implements MediatR `INotification` and captures `DateOccurred`.

```csharp
public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
```
