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
    public int Id { get; set; }

    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

}

/// <summary>
/// Base type for entities with strongly typed identifier.
/// </summary>
public abstract class EntityBase<TId> : HasDomainEventsBase, IEntityBase<TId>
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; } = default!;

}

/// <summary>
/// For use with Vogen or similar strongly typed Id generators.
/// </summary>
public abstract class EntityBase<T, TId> : HasDomainEventsBase, IEntityBase<TId>
    where T : EntityBase<T, TId>
{
    public TId Id { get; set; } = default!;

}
