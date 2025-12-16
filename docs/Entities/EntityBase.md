---
title: EntityBase
uid: geaux.sharedkernal.entities.entitybase
---

# EntityBase

Base type for entities with domain event support.
Supports int identifiers and strongly-typed identifiers.

- `EntityBase` – uses `int` identifiers
- `EntityBase<TId>` – strongly typed identifiers
- `EntityBase<T, TId>` – Vogen/typed ID friendly base with self-referencing generic constraint

```csharp
public abstract class EntityBase : HasDomainEventsBase
{
    public int Id { get; set; }
}
```
