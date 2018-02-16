namespace DependencyInjectionTutorial.App
{
    public interface IActivationLinkGenerator
    {
        string GenerateLink(string email, string token);
    }
}