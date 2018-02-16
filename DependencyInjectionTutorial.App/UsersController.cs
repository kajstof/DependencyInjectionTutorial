using System;

namespace DependencyInjectionTutorial.App
{
    public class UsersController
    {
        public void RegisterUser(string email)
        {
            // Check if email is valid
            if (new EmailValidator().Validate(email) == false)
            {
                throw new ArgumentException("Invalid email address");
            }

            // Check if email is not taken
            if (UsersDatabase.IsEmailTaken(email))
            {
                throw new InvalidOperationException("Email already taken");
            }

            // Create new user
            var newUser = new User
            {
                Email = email,
                RegistrationToken = Guid.NewGuid().ToString()
            };

            // Insert user
            UsersDatabase.InsertUser(newUser);

            // Generate activation link
            string registrationLink =
                new ActivationLinkGenerator().GenerateLink(newUser.Email, newUser.RegistrationToken);

            EmailService.RegistrationEmail(newUser.Email, registrationLink);
        }
    }
}