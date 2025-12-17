using Geaux.SharedKernal.Entities;

namespace Geaux.SharedKernal.Tests.Entities
{
    public class EntityTests
    {
        private class Order : EntityBase<int>, IAggregateRoot, IAuditable, ISoftDelete
        {
            public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
            public DateTime? ModifiedOn { get; private set; }
            public bool IsDeleted { get; private set; }

            public void MarkDeleted() => IsDeleted = true;
        }

        [Fact]
        public void Entity_ShouldHave_Id()
        {
            Order order = new Order { Id = 42 };
            Assert.Equal(42, order.Id);
        }

        [Fact]
        public void Entity_ShouldSupport_SoftDelete()
        {
            Order order = new Order();
            order.MarkDeleted();
            Assert.True(order.IsDeleted);
        }

        [Fact]
        public void Entity_ShouldSupport_AuditTrail()
        {
            Order order = new Order();
            Assert.NotEqual(default, order.CreatedOn);
        }
    }
}
