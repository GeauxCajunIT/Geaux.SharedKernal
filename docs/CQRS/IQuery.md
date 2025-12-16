---
title: IQuery
uid: geaux.sharedkernal.cqrs.iquery
---

# IQuery

Marker interface for queries in CQRS.  
Extends MediatR `IRequest<TResponse>` to represent read operations.

```csharp
public interface IQuery<out TResponse> : IRequest<TResponse> { }
