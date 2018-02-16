namespace DependencyInjectionTutorial.App
{
    public class ActivationLinkGenerator
    {
        public string GenerateLink(string email, string token)
        {
            return $"http://myapp.com/confirm?email={email}&taken={token}";
        }
    }
}