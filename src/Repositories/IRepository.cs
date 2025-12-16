// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.Repositories;

using Geaux.SharedKernal.Entities;

/// <summary>
/// An abstraction for persistence, based on Geaux.Specification
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T?> GetByIdAsync(object id, CancellationToken ct = default);

    Task AddAsync(T entity, CancellationToken ct = default);

    Task UpdateAsync(T entity, CancellationToken ct = default);

    /// <summary>
    /// Soft deletes the entity (sets IsDeleted = true).
    /// </summary>
    Task SoftDeleteAsync(T entity, CancellationToken ct = default);

    /// <summary>
    /// Hard delete if absolutely required.
    /// </summary>
    Task DeleteAsync(T entity, CancellationToken ct = default);
}
