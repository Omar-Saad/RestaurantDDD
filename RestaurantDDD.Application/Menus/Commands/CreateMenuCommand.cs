using ErrorOr;
using MediatR;
using RestaurantDDD.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Application.Menus.Commands
{
    public record CreateMenuCommand
  (string Name, string Description, List<MenuSectionCommand> Sections,string HostId):IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string Name, string Description,
        List<MenuItemCommand> Items

        );

    public record MenuItemCommand(

          string Name, string Description
        );
}
