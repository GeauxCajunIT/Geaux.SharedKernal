---
title: Geaux.SharedKernal
uid: Geaux.SharedKernal.index
---

# Geaux.SharedKernal

Geaux.SharedKernal is a lightweight NuGet package providing foundational domain‑driven building blocks for .NET applications.  

It includes:
- CQRS primitives (`ICommand`, `IQuery`, and handler interfaces built on MediatR)
- Domain events (`DomainEventBase`, `IDomainEventDispatcher`, `HasDomainEventsBase`)
- Entity base classes (`EntityBase`, `EntityBase<TId>`, `EntityBase<T, TId>`)
- Marker interfaces (`IAggregateRoot`)
- Infrastructure interfaces (`IAuditable`, `ISoftDelete`)
- Value object support (`ValueObject`)
- Repository abstractions compatible with [Geaux.Specification](https://www.nuget.org/packages/Geaux.Specification)

## Installation

```bash
dotnet add package Geaux.SharedKernal
```

## Example Usage
```csharp
public class Order : EntityBase<Guid>, IAggregateRoot, IAuditable, ISoftDelete
{
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    public DateTime? ModifiedOn { get; private set; }
    public bool IsDeleted { get; private set; }

    public void MarkDeleted() => IsDeleted = true;
}
```

## Related Packages
Geaux.Specification — Specification pattern support

Geaux.Specification.EntityFrameworkCore — EF Core integration
