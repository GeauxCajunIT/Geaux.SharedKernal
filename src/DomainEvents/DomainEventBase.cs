// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using MediatR;

namespace Geaux.SharedKernal.DomainEvents;

/// <summary>
/// A base type for domain events. Depends on MediatR INotification.
/// Includes <see cref="DateOccurred"/> which is set on creation.
/// </summary>
public abstract class DomainEventBase : INotification
{
    /// <summary>
    /// Gets the UTC timestamp representing when the domain event was created.
    /// </summary>
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}


