using System;

namespace DependencyInjectionTutorial.App
{
    public static class UsersDatabase
    {
        public static bool IsEmailTaken(string email)
        {
            return false;
        }

        public static void InsertUser(User user)
        {
        }
    }
}