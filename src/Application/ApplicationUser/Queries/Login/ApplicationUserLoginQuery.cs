using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todo_api.Application.Common.Exceptions;
using todo_api.Application.Common.Interfaces;

namespace todo_api.Application.ApplicationUser.Queries.Login
{
    public class ApplicationUserLoginQuery : IRequest<LoginResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class ApplicationUserLoginQueryHandler : IRequestHandler<ApplicationUserLoginQuery, LoginResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        
        public ApplicationUserLoginQueryHandler(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }
        public async Task<LoginResponse> Handle(ApplicationUserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.CheckUserPassword(request.Email, request.Password);

            if (user == null)
            {
                throw new NotFoundException("User", request.Email);
            }

            return new LoginResponse
            {
                User = user,
                Token = _tokenService.CreateJwtSecurityToken(user.Id)
            };
        }
    }
}