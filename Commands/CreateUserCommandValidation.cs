using FluentValidation;

namespace CQSSample.Commands
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand> {
        public CreateUserCommandValidation () {
            RuleFor (user => user.Name).NotNull ().NotEmpty ().WithMessage ("Name is required");
            RuleFor(user=> user.Age).GreaterThanOrEqualTo(18).WithMessage ("Underage is not allowed");
            RuleFor(user=> user.Email).EmailAddress().WithMessage("Invalid e-amail");
            RuleFor (user => user.Birthday).NotNull ().WithMessage ("Birdth day is required");
        }
    }
}