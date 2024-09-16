using FluentValidation;
using Person.Registry.Shared.Extensions;

namespace Person.Registry.Core.Application.Commands.UserManagement.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.Gender).NotNull()
                                             .NotEmpty();

            RuleFor(command => command.FirstName).MaximumLength(50)
                                                   .WithMessage((command, firstName) =>
                                                    $"The maximum length for FirstName is 50 characters. You entered {firstName.Length} characters.")
                                                 .MinimumLength(2)
                                                   .WithMessage((command, firstName) =>
                                                    $"The minimum length for FirstName is 2 characters. You entered {firstName.Length} characters.")
                                                 .NotEmpty()
                                                 .NotNull()
                                                 .Must(TextExtensions.CheckTextIsGeorgianOrEnglish)
                                                   .WithMessage("First name must contain either only Georgian letters or only English letters"); ;

            RuleFor(command => command.LastName).MaximumLength(50)
                                                  .WithMessage((command, lastName) =>
                                                   $"The maximum length for LastName is 50 characters. You entered {lastName.Length} characters.")
                                                .MinimumLength(2)
                                                   .WithMessage((command, firstName) =>
                                                    $"The minimum length for FirstName is 2 characters. You entered {firstName.Length} characters.")
                                                 .NotEmpty()
                                                 .NotNull()
                                                 .Must(TextExtensions.CheckTextIsGeorgianOrEnglish)
                                                   .WithMessage("Last name must contain either only Georgian letters or only English letters");

            RuleFor(command => command.BirthDate).Must(DateExtensions.BeAtLeast18YearsOld)
                                                 .WithMessage("You must be at least 18 years old");


            RuleForEach(command => command.Phones)
                 .ChildRules(phone =>
                 {
                     phone.RuleFor(p => p.PhoneNumber)
                          .MaximumLength(50)
                             .WithMessage((command, phoneNumber) =>
                                                    $"The maximum length for phone is 50 characters. You entered {phoneNumber.Length} characters.")
                          .MinimumLength(2)
                             .WithMessage((command, phoneNumber) =>
                                                    $"The minimum length for phone is 2 characters. You entered {phoneNumber.Length} characters.")
                          .Matches(@"^[0-9]+$")
                             .WithMessage("Phone number must contain only digits.");

                     phone.RuleFor(p => p.Type)
                          .IsInEnum()
                            .WithMessage("Phone type is invalid.");
                 }).When(command => command.Phones != null && command.Phones.Any())
                    .WithMessage("At least one phone is required.");
        }
    }
}
