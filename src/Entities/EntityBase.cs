// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using Geaux.SharedKernal.DomainEvents;

namespace Geaux.SharedKernal.Entities;

/// <summary>
/// Base type for entities with int identifier.
/// </summary>
public abstract class EntityBase : HasDomainEventsBase, IEntityBase<int>
{
    /// <summary>
    /// Gets or sets the primary integer identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

}

/// <summary>
/// Base type for entities with strongly typed identifier.
/// </summary>
/// <typeparam name="TId">Struct type used as the identifier.</typeparam>
public abstract class EntityBase<TId> : HasDomainEventsBase, IEntityBase<TId>
    where TId : struct, IEquatable<TId>
{
    /// <summary>
    /// Gets or sets the strongly typed identifier for the entity.
    /// </summary>
    public TId Id { get; set; } = default!;

}

/// <summary>
/// For use with Vogen or similar strongly typed Id generators.
/// </summary>
/// <typeparam name="T">Concrete entity type deriving from this base.</typeparam>
/// <typeparam name="TId">Struct type used as the identifier.</typeparam>
public abstract class EntityBase<T, TId> : HasDomainEventsBase, IEntityBase<TId>
    where T : EntityBase<T, TId>
{
    /// <summary>
    /// Gets or sets the strongly typed identifier for the entity.
    /// </summary>
    public TId Id { get; set; } = default!;

}
