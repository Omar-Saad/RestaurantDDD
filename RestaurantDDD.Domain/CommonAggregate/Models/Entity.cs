using RestaurantDDD.Domain.CommonAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Common.Models
{
    public abstract class Entity<TId> : IHasDomainEvent where TId : notnull
    {
        public TId Id { get; protected set; }
        private readonly List<IDomianEvent> _events = new();
        public IReadOnlyList<IDomianEvent> Events => _events.AsReadOnly();

        public Entity(TId id)
        {
            Id = id;
        }
        protected Entity() { }

        public void AddDomainEvent(IDomianEvent domianEvent){
            _events.Add(domianEvent);
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

        public void ClearDomainEvent()
        {
            _events.Clear();
        }
    }
}
