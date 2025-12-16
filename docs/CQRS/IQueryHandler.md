---
title: IQueryHandler
uid: geaux.sharedkernal.cqrs.iqueryhandler
---

# IQueryHandler

Handler interface for queries.
Extends MediatR `IRequestHandler<TQuery, TResponse>`.

- `TQuery`: query type implementing `IQuery<TResponse>`
- `TResponse`: response returned by the query handler

```csharp
public interface IQueryHandler<in TQuery, TResponse>
  : IRequestHandler<TQuery, TResponse>
  where TQuery : IQuery<TResponse>;
```
