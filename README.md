# **Geaux.SharedKernal**

Foundational domain-driven building blocks for GeauxPlatform and modern .NET applications. Provides CQRS primitives, domain events, entity base classes, value objects, repository abstractions, audit trail, and soft delete support.

`Geaux.SharedKernal` provides the essential abstractions and base classes needed to implement **Domain-Driven Design (DDD)**, **CQRS**, and clean architectural separation across your application. It is intentionally minimal, framework-agnostic, and highly reusable.

This library contains no Entity Framework, no ASP.NET Core hosting code, and no platform-specific dependencies — making it ideal for use in **domain layers**, **use case layers**, and **NuGet packages**.

---

## ✨ Features

* 🧱 **Entity base classes** with domain event support
* 🎯 **ValueObject** infrastructure with equality & comparison semantics
* 🔔 **Domain events** & dispatching abstractions
* 🔄 **Mediator pipeline behaviors**, including logging
* 📬 **CQRS primitives** (ICommand, IQuery, and handler interfaces)
* 📚 **Repository abstractions** (`IRepository`, `IReadRepository`) compatible with Specification pattern
* 🕒 **Auditable trail** (`IAuditable`) for created/modified timestamps
* 🗑️ **Soft delete** (`ISoftDelete`) for logical deletion support
* 🎨 100% framework‑agnostic, usable in any architecture (Clean, Onion, Hexagonal)

---

## **📦 Installation**

```bash
dotnet add package Geaux.SharedKernal
```

---

# **🧱 Core Building Blocks**
### Entities 
- `EntityBase` (int identifier) 
- `EntityBase<TId>` (strongly‑typed identifier) 
- `EntityBase<T, TId>` (pattern‑friendly base for typed IDs) 
- `IAggregateRoot` (marker interface for aggregate roots) 
- `IAuditable` (created/modified timestamps for audit trail) 
- `ISoftDelete` (flag for logical deletion)

---

## **EntityBase**

A base class for aggregate roots or domain entities.

### Features:

* Automatic tracking of domain events
* Generic (`EntityBase<TId>`) and non-generic versions
* Equality based on identifier
* Hook for clearing/processing domain events

### Example

```csharp
public class Order : EntityBase<Guid>, IAggregateRoot
{
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
}
```

---

## **ValueObject**

Implements the classic DDD Value Object pattern using component-based equality.

### Features:

* Automatic equality comparisons
* Sorting support via `IComparable`
* Semantic equality instead of object identity

### Example

```csharp
public class Money : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
```

---

# **🔔 Domain Events**

Domain events allow aggregates to publish meaningful system changes.

---

## **DomainEventBase**

```csharp
public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; } = DateTime.UtcNow;
}
```

Each event is attached to an entity and later dispatched.

---

## **IDomainEventDispatcher**

Abstraction that hands domain events off to an external mechanism (such as MediatR).

---

## **MediatRDomainEventDispatcher**

A concrete implementation using MediatR:

* Dispatches events after persistence completes
* Ensures reliable event handling patterns

---

# **🧭 CQRS Abstractions**

`Geaux.SharedKernal` defines command/query primitives compatible with MediatR.

### **Commands**

```csharp
public interface ICommand<TResult> : IRequest<TResult> { }
public interface ICommandHandler<TCommand, TResult> 
    : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>;
```

### **Queries**

```csharp
public interface IQuery<TResult> : IRequest<TResult> { }
public interface IQueryHandler<TQuery, TResult>
    : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>;
```

These interfaces unify CQRS semantics across modules and improve discoverability.

---

# **📚 Repository Abstractions**

This library defines two essential repository contracts.

---

## **IReadRepository<T>**

Read-only operations using Specification pattern:

```csharp
Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken);
Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
```

---

## **IRepository<T>**

Adds stateful write capabilities:

```csharp
Task AddAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(T entity);
```

These interfaces pair with `Geaux.Specification` and `Geaux.Specification.EntityFrameworkCore`.

---

# **📜 Logging Behavior**

Includes `LoggingBehavior<TRequest, TResponse>` to integrate into the MediatR pipeline:

* Logs request start/end
* Captures timing
* Helps track application flow consistently

---

# **🏛 Architectural Role**

`Geaux.SharedKernal` sits at the **center** of the dependency graph.

### It **may** be referenced by:

* Domain projects (`Geaux.Core`)
* Use case projects (`Geaux.UseCases`)
* Infrastructure implementations (read-only)

### It **must not** reference:

* EF Core
* ASP.NET Core
* Infrastructure
* UI or Presentation layers

This enforces pure domain compliance.

---

# **📂 Project Structure**

```
Geaux.SharedKernal/
│
├── CQRS/
│   ├── ICommand.cs
│   ├── ICommandHandler.cs
│   ├── IQuery.cs
│   └── IQueryHandler.cs
│
├── DomainEvents/
│   ├── DomainEventBase.cs
│   ├── IDomainEventDispatcher.cs
│   ├── MediatRDomainEventDispatcher.cs
│   └── LoggingBehavior.cs
│
├── Entities/
│   ├── EntityBase.cs
│   ├── EntityBase.TId.cs
│   ├── ValueObject.cs
│   ├── HasDomainEventsBase.cs
│   └── IAggregateRoot.cs
│
├── Repositories/
│   ├── IRepository.cs
│   └── IReadRepository.cs
│
└── Geaux.SharedKernal.csproj
```

---

# **📘 Usage Summary**

Geaux.SharedKernal provides:

* The base types for all domain models
* Building blocks for domain events
* Command/query abstractions
* Repository contracts
* MediatR pipeline utilities

It is the foundational library for building **decoupled, testable, scalable** applications following Clean Architecture and DDD practices.

---

# **📄 License**

MIT License
© Brent Lee Rigsby / GeauxCajunIT

---

# **🌐 Repository**

[https://github.com/GeauxCajunIT/GeauxPlatform](https://github.com/GeauxCajunIT/GeauxPlatform)
