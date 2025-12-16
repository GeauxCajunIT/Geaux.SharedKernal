// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.Repositories;

using Geaux.SharedKernal.Entities;

/// <summary>
/// An abstraction for persistence, based on Geaux.Specification
/// </summary>
/// <typeparam name="T">Aggregate root type this repository manages.</typeparam>
public interface IRepository<T> where T : class, IAggregateRoot
{
    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">Identifier value for the entity.</param>
    /// <param name="ct">Cancellation token for the asynchronous operation.</param>
    Task<T?> GetByIdAsync(object id, CancellationToken ct = default);

    /// <summary>
    /// Adds a new entity instance to the underlying store.
    /// </summary>
    /// <param name="entity">Entity instance to add.</param>
    /// <param name="ct">Cancellation token for the asynchronous operation.</param>
    Task AddAsync(T entity, CancellationToken ct = default);

    /// <summary>
    /// Persists changes for an existing entity instance.
    /// </summary>
    /// <param name="entity">Entity instance to update.</param>
    /// <param name="ct">Cancellation token for the asynchronous operation.</param>
    Task UpdateAsync(T entity, CancellationToken ct = default);

    /// <summary>
    /// Soft deletes the entity (sets IsDeleted = true).
    /// </summary>
    /// <param name="entity">Entity instance to soft delete.</param>
    /// <param name="ct">Cancellation token for the asynchronous operation.</param>
    Task SoftDeleteAsync(T entity, CancellationToken ct = default);

    /// <summary>
    /// Hard delete if absolutely required.
    /// </summary>
    /// <param name="entity">Entity instance to remove.</param>
    /// <param name="ct">Cancellation token for the asynchronous operation.</param>
    Task DeleteAsync(T entity, CancellationToken ct = default);
}
