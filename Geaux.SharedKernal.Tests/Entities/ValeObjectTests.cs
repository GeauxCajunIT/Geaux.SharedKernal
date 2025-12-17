using Geaux.SharedKernal.Entities;

namespace Geaux.SharedKernal.Tests.Entities
{
    public class ValueObjectTests
    {
        private class Money : ValueObject
        {
            public decimal Amount { get; }
            public string Currency { get; }

            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Amount;
                yield return Currency;
            }
        }

        [Fact]
        public void ValueObjects_WithSameValues_ShouldBeEqual()
        {
            Money m1 = new Money(100, "USD");
            Money m2 = new Money(100, "USD");

            Assert.Equal(m1, m2);
            Assert.True(m1 == m2);
        }

        [Fact]
        public void ValueObjects_WithDifferentValues_ShouldNotBeEqual()
        {
            Money m1 = new Money(100, "USD");
            Money m2 = new Money(200, "USD");

            Assert.NotEqual(m1, m2);
            Assert.True(m1 != m2);
        }

        [Fact]
        public void ValueObject_ShouldSupport_ComparisonOperators()
        {
            Money m1 = new Money(100, "USD");
            Money m2 = new Money(200, "USD");

            Assert.True(m1 < m2);
            Assert.True(m2 > m1);
        }
    }
}
