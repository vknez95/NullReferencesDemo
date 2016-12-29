using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class LoginCommand: ICommand
    {

        private IApplicationServices appServices;

        public LoginCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public void Execute()
        {

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (this.appServices.Login(username))
                Console.WriteLine("User '{0}' is now logged in.", username);
            else
                Console.WriteLine("Login failed for user '{0}'.", username);

        }
    }
}
