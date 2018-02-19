namespace DependencyInjectionTutorial.App
{
    public class WebServer
    {
        private static PoorMansContainer _container;

        static void Main()
        {
            _container = new PoorMansContainer();
            _container.Register<IEmailValidator, EmailValidator>();
            _container.Register<IActivationLinkGenerator, ActivationLinkGenerator>();
            _container.Register<IEmailService, EmailService>();
            // Application compiles, but will throw in runtime
            // container.Register<IEmailTemplateGenerator, ???>();
            _container.RegisterType<UsersController>();
        }

        static void Shutdown()
        {
            // Our container does not implement this
            // _container.Dispose();
        }

        public void RegisterUser(string email)
        {
//            var emailService = new EmailService(new IEmailTemplateGenerator());
//            var emailValidator = new EmailValidator();
//            var activationLinkGenerator = new ActivationLinkGenerator();
//            var controller = new UsersController(emailService, emailValidator, activationLinkGenerator);
            var controller = _container.Resolve<UsersController>();
            controller.RegisterUser(email);
        }
    }
}