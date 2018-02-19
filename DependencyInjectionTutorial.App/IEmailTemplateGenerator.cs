namespace DependencyInjectionTutorial.App
{
    public interface IEmailTemplateGenerator
    {
        string ActivationTemplate(string link);
    }
}