using ErrorOr;
using MediatR;
using RestaurantDDD.Application.Common.Interfaces.Repositories;
using RestaurantDDD.Domain.HostAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuAggregate;
using MenuItem = RestaurantDDD.Domain.MenuAggregate.Entities.MenuItem;
using MenuSection = RestaurantDDD.Domain.MenuAggregate.Entities.MenuSection;

namespace RestaurantDDD.Application.Menus.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Create Menu
            var menu = Menu.Create(request.Name, request.Description,
                HostId.Create(request.HostId),
                request.Sections.ConvertAll(
                    section => MenuSection.Create(section.Name, section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(item.Name, section.Description))
                    ))
                );
            // Persist
            _menuRepository.Add(menu);
            // Return Menu

            return menu;
        }
    }
}
