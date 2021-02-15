using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using todo_api.Application.Common.Interfaces;

namespace todo_api.Application.ApplicationUser.Commands.DeleteApplicationUser
{
    public class DeleteApplicationCommandValidator : AbstractValidator<DeleteApplicationCommand>
    {
        private readonly IIdentityService _identityService;

        public DeleteApplicationCommandValidator(IIdentityService identityService)
        {
            _identityService = identityService;

            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.")
                .MustAsync(BeExistUser).WithMessage("user not found");

        }

        public async Task<bool> BeExistUser(string id, CancellationToken cancellationToken)
        {
            return !String.IsNullOrWhiteSpace(await _identityService.GetUserNameAsync(id));
        }
    }
}