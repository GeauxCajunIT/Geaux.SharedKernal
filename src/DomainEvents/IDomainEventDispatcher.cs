// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.DomainEvents;

/// <summary>
/// A simple interface for sending domain events. Can use MediatR or any other implementation.
/// </summary>
public interface IDomainEventDispatcher
{
    /// <summary>
    /// Dispatches and then clears all domain events associated with the given entities.
    /// </summary>
    /// <param name="entitiesWithEvents">
    /// The entities that have pending domain events to dispatch.
    /// </param>
    Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents);
}


