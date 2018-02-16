using Xunit;

namespace DependencyInjectionTutorial.App.Tests
{
    public class EmailValidatorTests
    {
        private readonly EmailValidator _validator;
        private string _email;

        public EmailValidatorTests()
        {
            _validator = new EmailValidator();
        }

        private bool Execute()
        {
            return _validator.Validate(_email);
        }

        [Fact]
        public void ValidatesGmailEmailAddressWithDot()
        {
            _email = "my.email@gmail.com";
            bool result = Execute();
            Assert.True(result);
        }
    }
}