# Geaux.SharedKernal

Foundational domain-driven building blocks for modern .NET applications.
Provides CQRS primitives, domain events, entity base classes, value objects, repository abstractions, audit trail, and soft delete support.

## ✨ Features

- **CQRS primitives**: `ICommand`, `IQuery`, and handler interfaces built on MediatR
- **Domain events**: base classes and dispatcher abstractions
- **Entities**:
  - `EntityBase` (int identifier)
  - `EntityBase<TId>` (strongly typed identifier)
  - `EntityBase<T, TId>` (for Vogen/typed IDs)
  - `IAggregateRoot` marker
  - `IAuditable` (created/modified timestamps)
  - `ISoftDelete` (logical deletion flag)
- **ValueObject** infrastructure with equality and comparison semantics
- **Repository abstractions** compatible with [Geaux.Specification](https://www.nuget.org/packages/Geaux.Specification)

## 📦 Installation

```bash
dotnet add package Geaux.SharedKernal
 ```

## 🚀 Usage Example
```csharp
public class Order : EntityBase<Guid>, IAggregateRoot, IAuditable, ISoftDelete
{
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    public DateTime? ModifiedOn { get; private set; }
    public bool IsDeleted { get; private set; }

    public void MarkDeleted() => IsDeleted = true;
}
```

## 🔗 Related Packages
Geaux.Specification — Specification pattern support

Geaux.Specification.EntityFrameworkCore — EF Core integration
