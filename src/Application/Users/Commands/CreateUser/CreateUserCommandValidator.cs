using FluentValidation;

namespace Application.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(createUserCommand => createUserCommand.Name)
        .NotEmpty()
        .MaximumLength(255);
        RuleFor(createUserCommand => createUserCommand.Username)
        .NotEmpty()
        .MaximumLength(255);
        RuleFor(createUserCommand => createUserCommand.Email)
        .NotEmpty()
        .EmailAddress()
        .MaximumLength(255);
    }
}
