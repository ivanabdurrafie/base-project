using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_api.Application.ApplicationUser.Commands.CreateApplicationUser;
using todo_api.Application.ApplicationUser.Queries.Login;

namespace todo_api.Api.Controllers
{
    public class AuthController : ApiControllerBase
    {
        [HttpPost("locgin")]
        public async Task<ActionResult<LoginResponse>> Login(ApplicationUserLoginQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUserDto>> Register(CreateapplicationUserCommand cmd)
        {
            return Ok(await Mediator.Send(cmd));
        }
    }
}