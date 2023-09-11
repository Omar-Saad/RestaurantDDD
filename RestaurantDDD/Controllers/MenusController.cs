using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantDDD.Application.Menus.Commands;
using RestaurantDDD.Contracts.Menus;

namespace RestaurantDDD.API.Controllers
{
    [Route("api/hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediatR;
        private readonly IMapper _mapper;

        public MenusController(ISender mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatMenu(CreateMenuRequest request , string hostId)
        {
            
            var command = _mapper.Map<CreateMenuCommand>((request , hostId));

            var createMenuResult =  await _mediatR.Send(command);

            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }
    }
}
