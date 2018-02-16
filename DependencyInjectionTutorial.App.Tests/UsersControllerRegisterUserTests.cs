using System;
using NSubstitute;
using Xunit;

namespace DependencyInjectionTutorial.App.Tests
{
    public class UsersControllerRegisterUserTests
    {
        private readonly UsersController _controller;
        private readonly IEmailValidator _emailValidator;
        private string _email;

        public UsersControllerRegisterUserTests()
        {
            _emailValidator = Substitute.For<IEmailValidator>();
            var linkGenerator = Substitute.For<IActivationLinkGenerator>();
            _controller = new UsersController(_emailValidator, linkGenerator);
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