using NullReferencesDemo.Presentation.Interfaces;
using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class LoginCommand: ICommand
    {

        private IApplicationServices appServices;

        public LoginCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (this.appServices.Login(username))
                return new UserLoggedIn(username,
                                        this.appServices.LoggedInUserBalance);

            return new LoginFailed(username);

        }
    }
}
