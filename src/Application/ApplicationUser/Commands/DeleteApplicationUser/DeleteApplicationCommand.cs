using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todo_api.Application.Common.Interfaces;

namespace todo_api.Application.ApplicationUser.Commands.DeleteApplicationUser
{
    public class DeleteApplicationCommand : IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand>
    {
        private readonly IIdentityService _identityService;

        public DeleteApplicationCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Unit> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            await _identityService.DeleteUserAsync(request.Id);
            return Unit.Value;
        }
    }
}