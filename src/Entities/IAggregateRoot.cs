// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.Diagnostics.CodeAnalysis;

namespace Geaux.SharedKernal.Entities;

/// <summary>
/// Apply this marker interface only to aggregate root entities in your domain model.
/// Your repository implementation can use constraints to ensure it only operates on aggregate roots.
/// </summary>
[SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface used for aggregate root constraints.")]
public interface IAggregateRoot
{
}

