
namespace Person.Registry.Shared.Extensions
{
    public static class DateExtensions
    {
        public static bool BeAtLeast18YearsOld(this DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) age--;

            return (age - 18 > 0);
        }
    }
}
