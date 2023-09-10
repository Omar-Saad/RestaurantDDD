using RestaurantDDD.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Common.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount; yield return Currency;
        }
    }
}
