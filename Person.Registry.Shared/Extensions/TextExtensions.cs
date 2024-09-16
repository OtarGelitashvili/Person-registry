using System.Text.RegularExpressions;

namespace Person.Registry.Shared.Extensions
{
    public static class TextExtensions
    {
        public static bool CheckTextIsGeorgianOrEnglish(this string name)
        {
            var georgianRegex = new Regex("^[ა-ჰ]+$");
            var englishRegex = new Regex("^[a-zA-Z]+$");

            return georgianRegex.IsMatch(name) || englishRegex.IsMatch(name);
        }
    }
}
