using System.Text.RegularExpressions;

namespace DependencyInjectionTutorial.App
{
    public class EmailValidator : IEmailValidator
    {
        private const string EMAIL_REGEX = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public bool Validate(string email)
        {
            return Regex.IsMatch(email, EMAIL_REGEX);
        }
    }
}