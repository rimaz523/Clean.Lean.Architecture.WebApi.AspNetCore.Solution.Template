using FluentValidation;

namespace Application.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(createUserCommand => createUserCommand.FirstName)
        .NotEmpty()
        .MaximumLength(255);
        RuleFor(createUserCommand => createUserCommand.LastName)
        .NotEmpty()
        .MaximumLength(255);
    }
}
