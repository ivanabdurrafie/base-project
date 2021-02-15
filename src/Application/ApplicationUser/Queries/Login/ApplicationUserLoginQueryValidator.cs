using FluentValidation;

namespace todo_api.Application.ApplicationUser.Queries.Login
{
    public class ApplicationUserLoginQueryValidator : AbstractValidator<ApplicationUserLoginQuery>
    {

        public ApplicationUserLoginQueryValidator()
        {

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("Email must not exceed 50 characters.")
                .EmailAddress();
            
            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Passowrd is required.")
                .MinimumLength(5).WithMessage("Password must 4 characters.");
        }
    }
}