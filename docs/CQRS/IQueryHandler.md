---
title: IQueryHandler
uid: geaux.sharedkernal.cqrs.iqueryhandler
---

# IQueryHandler

Handler interface for queries.  
Extends MediatR `IRequestHandler<TQuery, TResponse>`.

```csharp
public interface IQueryHandler<in TQuery, TResponse> 
  : IRequestHandler<TQuery, TResponse>
  where TQuery : IQuery<TResponse>;
