---
title: EntityBase
uid: geaux.sharedkernal.entities.entitybase
---

# EntityBase

Base type for entities with domain event support.  
Supports int identifiers and strongly‑typed identifiers.

```csharp
public abstract class EntityBase : HasDomainEventsBase
{
    public int Id { get; set; }
}
