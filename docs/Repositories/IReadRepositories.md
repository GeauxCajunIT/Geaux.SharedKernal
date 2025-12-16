---
title: IReadRepository
uid: geaux.sharedkernal.repositories.ireadrepository
---

# IReadRepository

Read-only repository abstraction.
Extends Geaux.Specification's `IReadRepositoryBase<T>` and constrains `T` to aggregate roots.

```csharp
public interface IReadRepository<T> : IReadRepositoryBase<T>
  where T : class, IAggregateRoot;
```
