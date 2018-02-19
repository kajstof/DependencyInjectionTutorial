namespace DependencyInjectionTutorial.App
{
    public class WebServer
    {
        public void RegisterUser(string email)
        {
            var emailService = new EmailService();
            var emailValidator = new EmailValidator();
            var activationLinkGenerator = new ActivationLinkGenerator();
            var controller = new UsersController(emailService, emailValidator, activationLinkGenerator);
            controller.RegisterUser(email);
        }
    }
}