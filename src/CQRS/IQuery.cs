// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Geaux.SharedKernal.CQRS;

/// <summary>
/// Marker interface for queries. Extends MediatR <see cref="IRequest{TResponse}"/>.
/// </summary>
[SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface to distinguish query semantics.")]
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

