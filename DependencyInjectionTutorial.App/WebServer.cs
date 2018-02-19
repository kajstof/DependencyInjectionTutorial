using System.Reflection;
using Autofac;

namespace DependencyInjectionTutorial.App
{
    public class WebServer
    {
        private static IContainer _container;

        static void Main()
        {
            var builder = new ContainerBuilder();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsSelf()
                .AsImplementedInterfaces();
            
            // Override default registration if needed
            builder.RegisterType<EmailValidator>()
                .AsImplementedInterfaces()
                .SingleInstance();

            _container = builder.Build();
        }

        static void Shutdown()
        {
            _container.Dispose();
        }

        public void RegisterUser(string email)
        {
            var controller = _container.Resolve<UsersController>();
            controller.RegisterUser(email);
        }
    }
}