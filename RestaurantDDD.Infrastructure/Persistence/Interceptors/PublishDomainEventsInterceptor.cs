using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.CommonAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishDomainEventsInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDominEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDominEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    

        private async Task PublishDominEvents(DbContext? context)
        {
            if (context == null) return;

            // Get all entities
            var entitiesWithDomainEvents = 
                context.ChangeTracker.Entries<IHasDomainEvent>()
                .Where(entry => entry.Entity.Events.Any())
                .Select(entry => entry.Entity)
                .ToList();
            // Get All Domain Events
            var domainEvents = entitiesWithDomainEvents.SelectMany(e => e.Events).ToList();
            // Clear Domain Events
            entitiesWithDomainEvents.ForEach(e => e.ClearDomainEvent());

            // Publis Events
            foreach ( var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}
