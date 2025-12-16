---
title: ICommand
uid: geaux.sharedkernal.cqrs.icommand
---

# ICommand

Marker interface for commands in CQRS.
Extends MediatR `IRequest<TResponse>` to represent write operations.

- `TResponse`: response returned when the command is processed

```csharp
public interface ICommand<out TResponse> : IRequest<TResponse> { }
```
