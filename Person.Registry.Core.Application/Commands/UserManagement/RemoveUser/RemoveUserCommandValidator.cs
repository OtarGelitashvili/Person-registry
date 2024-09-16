using FluentValidation;
namespace Person.Registry.Core.Application.Commands.UserManagement.RemoveUser
{
    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0)
                                          .NotNull();
        }
    }
}
