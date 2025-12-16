// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.DomainEvents;

/// <summary>
/// Represents an entity that produces domain events.
/// </summary>
public interface IHasDomainEvents
{
    /// <summary>
    /// Gets the collection of domain events that have been raised by this entity.
    /// </summary>
    IReadOnlyCollection<DomainEventBase> DomainEvents { get; }
}


