using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Common.Models
{
    public abstract class Entity<TId> where TId : notnull
    {
        public TId Id { get; protected set; }

        public Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
        public static bool operator !=(Entity<TId> left, Entity<TId> right) => !Equals(left, right);

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
