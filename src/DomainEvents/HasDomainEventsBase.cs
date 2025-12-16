// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace Geaux.SharedKernal.DomainEvents;

/// <summary>
/// Base type for entities that can publish domain events.
/// Stores events until they are dispatched and cleared.
/// </summary>
public abstract class HasDomainEventsBase : IHasDomainEvents
{
    private readonly List<DomainEventBase> _domainEvents = new();

    /// <inheritdoc />
    [NotMapped]
    public IReadOnlyCollection<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Registers a new domain event to be dispatched later.
    /// </summary>
    /// <param name="domainEvent">The domain event to register.</param>
    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears all tracked domain events after they have been dispatched.
    /// </summary>
    internal void ClearDomainEvents() => _domainEvents.Clear();
}


