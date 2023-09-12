using MediatR;

namespace RestaurantDDD.Domain.MenuAggregate.Events
{
    public class MenuCreatedEventHandler : INotificationHandler<MenuCreated>
    {
        public async Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
