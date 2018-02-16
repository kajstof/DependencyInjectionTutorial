﻿namespace DependencyInjectionTutorial.App
{
    public class WebServer
    {
        public void RegisterUser(string email)
        {
            var controller = new UsersController();
            controller.RegisterUser(email);
        }
    }
}