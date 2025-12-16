// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using MediatR;
using Microsoft.Extensions.Logging;

namespace Geaux.SharedKernal.DomainEvents;

/// <summary>
/// Default domain event dispatcher implementation using MediatR.
/// Dispatches all pending domain events for the provided entities and then clears them.
/// </summary>
public class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;
    private readonly ILogger<MediatRDomainEventDispatcher> _logger;

    private static readonly Action<ILogger, string, string, Exception?> _logInvalidEntity =
        LoggerMessage.Define<string, string>(
            LogLevel.Error,
            new EventId(1, nameof(MediatRDomainEventDispatcher)),
            "Entity of type {EntityType} does not inherit from {BaseType}. Unable to clear domain events.");

    /// <summary>
    /// Initializes a new instance of the <see cref="MediatRDomainEventDispatcher"/> class.
    /// </summary>
    /// <param name="mediator">The MediatR mediator used to publish domain events.</param>
    /// <param name="logger">The logger used to log dispatch and error information.</param>
    public MediatRDomainEventDispatcher(IMediator mediator, ILogger<MediatRDomainEventDispatcher> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public async Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents)
    {
        ArgumentNullException.ThrowIfNull(entitiesWithEvents);

        foreach (var entity in entitiesWithEvents)
        {
            if (entity is HasDomainEventsBase hasDomainEvents)
            {
                var events = hasDomainEvents.DomainEvents.ToArray();
                hasDomainEvents.ClearDomainEvents();

                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
            else
            {
                _logInvalidEntity(
                    _logger,
                    entity.GetType().Name,
                    nameof(HasDomainEventsBase),
                    null);
            }
        }
    }
}

