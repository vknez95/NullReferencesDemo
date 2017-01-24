using NullReferencesDemo.Presentation.Interfaces;
using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class LoginCommand : ICommand
    {

        private IApplicationServices appServices;
        private readonly IUsernameValidator validator;

        public LoginCommand(IApplicationServices appServices, IUsernameValidator validator)
        {
            this.appServices = appServices;
            this.validator = validator;
        }

        public ICommandResult Execute()
        {

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (!validator.IsValid(username))
                return new InvalidUsername(username, validator.MinLength);

            if (this.appServices.Login(username))
                return new UserLoggedIn(username, this.appServices.LoggedInUserBalance);

            return new LoginFailed(username);

        }
    }
}
