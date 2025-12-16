---
title: IRepository
uid: geaux.sharedkernal.repositories.irepository
---

# IRepository

Full repository abstraction.
Extends Geaux.Specification's `IRepositoryBase<T>` and constrains `T` to aggregate roots.

```csharp
public interface IRepository<T> : IRepositoryBase<T>
  where T : class, IAggregateRoot;
```
