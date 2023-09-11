using Mapster;
using RestaurantDDD.Application.Authentication.Commands;
using RestaurantDDD.Application.Authentication.Common;
using RestaurantDDD.Application.Authentication.Queries;
using RestaurantDDD.Contracts.Authentication;

namespace RestaurantDDD.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User)
              ;
          
        }
    }
}
