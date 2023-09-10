using RestaurantDDD.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Dinner.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        public Location(string name, string address, decimal latitude, decimal longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
