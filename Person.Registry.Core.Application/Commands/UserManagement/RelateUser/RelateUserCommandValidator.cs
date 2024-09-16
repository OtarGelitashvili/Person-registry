using FluentValidation;

namespace Person.Registry.Core.Application.Commands.UserManagement.RelateUser
{
    public class RelateUserCommandValidator : AbstractValidator<RelateUserCommand>
    {
        public RelateUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThan(0)
                                              .NotNull();

            RuleFor(command => command.RelatedUserId).GreaterThan(0)
                                                     .NotNull();
        }
    }
}
