using Mapster;
using RestaurantDDD.Application.Authentication.Commands;
using RestaurantDDD.Application.Authentication.Common;
using RestaurantDDD.Application.Authentication.Queries;
using RestaurantDDD.Application.Menus.Commands;
using RestaurantDDD.Contracts.Authentication;
using RestaurantDDD.Contracts.Menus;
using RestaurantDDD.Domain.MenuAggregate;
using MenuItem = RestaurantDDD.Domain.MenuAggregate.Entities.MenuItem;
using MenuSection = RestaurantDDD.Domain.MenuAggregate.Entities.MenuSection;

namespace RestaurantDDD.API.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            //config.NewConfig<MenuSe>
            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating , src => src.AverageRating.Value)
                .Map(dest => dest.HostId , src => src.HostId.Value)
                .Map(dest => dest.DinnerIds , src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds , src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
               .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
