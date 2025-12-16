---
title: ICommandHandler
uid: geaux.sharedkernal.cqrs.icommandhandler
---

# ICommandHandler

Handler interface for commands.
Extends MediatR `IRequestHandler<TCommand, TResponse>`.

- `TCommand`: command type that implements `ICommand<TResponse>`
- `TResponse`: response returned by the command handler

```csharp
public interface ICommandHandler<in TCommand, TResponse>
  : IRequestHandler<TCommand, TResponse>
  where TCommand : ICommand<TResponse>;
```
