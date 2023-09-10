using Microsoft.AspNetCore.Mvc;
using RestaurantDDD.Contracts.Authentication;
using ErrorOr;
using MediatR;
using RestaurantDDD.Application.Authentication.Commands;
using RestaurantDDD.Application.Authentication.Common;
using RestaurantDDD.Application.Authentication.Queries;
using MapsterMapper;

namespace RestaurantDDD.API.Controllers
{
    [Route("auth")]
    //[ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _medaitR;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender medaitR, IMapper mapper)
        {
            _medaitR = medaitR;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterCommand command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authRes = await _medaitR.Send(command);
            return authRes.Match(
                _authRes => Ok(_mapper.Map<AuthenticationResponse>(_authRes)),
                _errors => Problem(_errors));
        }


        [HttpPost("login")]
        public async  Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery command = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authRes = await _medaitR.Send(command);

            return authRes.Match(
                _authRes => Ok(_mapper.Map<AuthenticationResponse>(_authRes)),
                _errors => Problem(_errors));
        }
    }
}
