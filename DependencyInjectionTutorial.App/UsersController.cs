﻿using System;

namespace DependencyInjectionTutorial.App
{
    public class UsersController
    {
        private readonly IEmailService _emailService;
        private readonly IEmailValidator _emailValidator;
        private readonly IActivationLinkGenerator _activationLinkGenerator;

        public UsersController(IEmailService emailService, IEmailValidator emailValidator, IActivationLinkGenerator activationLinkGenerator)
        {
            _emailService = emailService;
            _emailValidator = emailValidator;
            _activationLinkGenerator = activationLinkGenerator;
        }

        public void RegisterUser(string email)
        {
            // Check if email is valid
            if (_emailValidator.Validate(email) == false)
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
            string registrationLink = _activationLinkGenerator.GenerateLink(newUser.Email, newUser.RegistrationToken);

            _emailService.RegistrationEmail(newUser.Email, registrationLink);
        }
    }
}