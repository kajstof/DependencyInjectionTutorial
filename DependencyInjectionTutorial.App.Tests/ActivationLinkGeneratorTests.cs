using System;
using Xunit;

namespace DependencyInjectionTutorial.App.Tests
{
    public class ActivationLinkGeneratorTests
    {
        private readonly IActivationLinkGenerator _generator;
        private string _email = "some-email";
        private string _token = "a-token";

        public ActivationLinkGeneratorTests()
        {
            _generator = new ActivationLinkGenerator();
        }

        private string Execute()
        {
            return _generator.GenerateLink(_email, _token);
        }

        [Fact]
        public void GeneratesLinkUsingGivenToken()
        {
            string result = Execute();
            Assert.Contains("token=a-token", result);
        }

        [Fact]
        public void GeneratesLinkUsingGivenEmail()
        {
            string result = Execute();
            Assert.Contains("email=some-email", result);
        }
    }
}