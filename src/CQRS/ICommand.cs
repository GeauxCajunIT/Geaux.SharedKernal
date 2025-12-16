// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Geaux.SharedKernal.CQRS;

/// <summary>
/// Marker interface for commands. Extends MediatR <see cref="IRequest{TResponse}"/>.
/// </summary>
/// <typeparam name="TResponse">Type returned when the command is handled.</typeparam>
[SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface to distinguish command semantics.")]
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

