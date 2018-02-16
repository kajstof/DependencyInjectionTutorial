namespace DependencyInjectionTutorial.App
{
    public class ActivationLinkGenerator : IActivationLinkGenerator
    {
        public string GenerateLink(string email, string token)
        {
            return $"http://myapp.com/confirm?email={email}&token={token}";
        }
    }
}