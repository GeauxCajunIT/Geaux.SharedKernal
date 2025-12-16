// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using Geaux.SharedKernal.Entities;
using Geaux.Specification.Abstractions;

namespace Geaux.SharedKernal.Repositories;

/// <summary>
/// An abstraction for read only persistence operations, based on Geaux.Specification.
/// Use this primarily to fetch trackable domain entities, not for custom queries.
/// </summary>
/// <typeparam name="T">Aggregate root type this repository reads.</typeparam>
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}

