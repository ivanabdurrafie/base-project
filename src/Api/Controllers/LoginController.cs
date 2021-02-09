using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_api.Application.ApplicationUser.Queries.Login;

namespace todo_api.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Create(ApplicationUserLoginQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}