using Geaux.SharedKernal.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Geaux.SharedKernal.Tests.DomainEvents
{
    public class DomainEventsTests
    {
        private class TestEvent : DomainEventBase { }

        private class TestEntity : HasDomainEventsBase
        {
            public void RaiseEvent() => RegisterDomainEvent(new TestEvent());
        }

        [Fact]
        public void RegisterDomainEvent_ShouldAddEvent()
        {
            TestEntity entity = new TestEntity();
            entity.RaiseEvent();

            Assert.Single(entity.DomainEvents);
        }

        [Fact]
        public async Task Dispatcher_ShouldPublishAndClearEvents()
        {
            Mock<IMediator> mediator = new Mock<IMediator>();
            MediatRDomainEventDispatcher dispatcher = new(mediator.Object, NullLogger<MediatRDomainEventDispatcher>.Instance);

            TestEntity entity = new();
            entity.RaiseEvent();

            await dispatcher.DispatchAndClearEvents([entity]);

            mediator.Verify(m => m.Publish(It.IsAny<DomainEventBase>(), default), Times.Once); ;
            Assert.Empty(entity.DomainEvents);
        }
    }
}
