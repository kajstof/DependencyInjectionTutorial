namespace DependencyInjectionTutorial.App
{
    public interface IEmailService
    {
        void RegistrationEmail(string newUserEmail, string registrationLink);
    }
}