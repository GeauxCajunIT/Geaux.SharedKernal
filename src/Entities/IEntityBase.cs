// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.Entities;

/// <summary>
/// Contract for all entities with a strongly typed identifier,
/// audit trail, and soft delete support.
/// </summary>
/// <typeparam name="TId">The type of the identifier (int, Guid, string, etc.).</typeparam>
public interface IEntityBase<TId>
{
    /// <summary>Primary key identifier.</summary>
    TId Id { get; }

}
