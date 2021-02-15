using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo_api.Application.ApplicationUser.Commands.DeleteApplicationUser;

namespace todo_api.Api.Controllers
{
    [Authorize]
    public class UserController : ApiControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteApplicationCommand {Id = id});

            return NoContent();
        }
    }
}