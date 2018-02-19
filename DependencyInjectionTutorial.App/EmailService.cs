using System;

namespace DependencyInjectionTutorial.App
{
    public class EmailService : IEmailService
    {
        private readonly IEmailTemplateGenerator _templateGenerator;

        public EmailService(IEmailTemplateGenerator templateGenerator)
        {
            _templateGenerator = templateGenerator;
        }
        
        public void RegistrationEmail(string email, string link)
        {
            string template = _templateGenerator.ActivationTemplate(link);
            // Send email...
        }
    }
}