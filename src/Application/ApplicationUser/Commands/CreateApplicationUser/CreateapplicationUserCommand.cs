using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todo_api.Application.ApplicationUser.Queries.Login;
using todo_api.Application.Common.Interfaces;
using todo_api.Application.Common.Models;

namespace todo_api.Application.ApplicationUser.Commands.CreateApplicationUser
{
    public class CreateapplicationUserCommand : IRequest<ApplicationUserDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmationPassword { get; set; }
    }

    public class CreateapplicationUserCommandHandler : IRequestHandler<CreateapplicationUserCommand, ApplicationUserDto>
    {
        private readonly IIdentityService _identityService;

        public CreateapplicationUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ApplicationUserDto> Handle(CreateapplicationUserCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.CreateUserAsync(request.Email, request.ConfirmationPassword);
        }
    }
}