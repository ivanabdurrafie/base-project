using todo_api.Application.Common.Interfaces;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace todo_api.Application.ApplicationUser.Commands.CreateApplicationUser
{
    public class CreateapplicationUserCommandValidator : AbstractValidator<CreateapplicationUserCommand>
    {
        private readonly IIdentityService _identityService;

        public CreateapplicationUserCommandValidator(IIdentityService identityService)
        {
            _identityService = identityService;

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("Email must not exceed 50 characters.")
                .EmailAddress()
                .MustAsync(BeUniqueEmail);
            
            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("PasswordRequiresNonAlphanumeric;PasswordRequiresDigit;PasswordRequiresUpper.");

            RuleFor(v => v.ConfirmationPassword)
                .NotEmpty().WithMessage("ConfirmationPassword is required.")
                .Equal(u => u.Password).WithMessage("ConfirmationPassword must same with Password");

        }

        public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return !await _identityService.IsUserExist(email);
        }
    }
}