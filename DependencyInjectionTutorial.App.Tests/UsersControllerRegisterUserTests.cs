using System;
using NSubstitute;
using Xunit;

namespace DependencyInjectionTutorial.App.Tests
{
    public class UsersControllerRegisterUserTests
    {
        private readonly UsersController _controller;
        private readonly IEmailService _emailService;
        private readonly IEmailValidator _emailValidator;
        private readonly IActivationLinkGenerator _linkGenerator;
        private string _email;

        public UsersControllerRegisterUserTests()
        {
            _emailService = Substitute.For<IEmailService>();
            _emailValidator = Substitute.For<IEmailValidator>();
            _linkGenerator = Substitute.For<IActivationLinkGenerator>();
            _controller = new UsersController(_emailService, _emailValidator, _linkGenerator);
            _email = "email";
        }

        private void Execute()
        {
            _controller.RegisterUser(_email);
        }

        [Fact]
        public void ThrowsWhenEmailNotValid()
        {
            _emailValidator.Validate(_email).Returns(false);
            Assert.Throws<ArgumentException>(() => Execute());
        }
    }
}