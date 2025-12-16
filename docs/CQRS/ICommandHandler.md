---
title: ICommandHandler
uid: geaux.sharedkernal.cqrs.icommandhandler
---

# ICommandHandler

Handler interface for commands.  
Extends MediatR `IRequestHandler<TCommand, TResponse>`.

```csharp
public interface ICommandHandler<in TCommand, TResponse> 
  : IRequestHandler<TCommand, TResponse>
  where TCommand : ICommand<TResponse>;
