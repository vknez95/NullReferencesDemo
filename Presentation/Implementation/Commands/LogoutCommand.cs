using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class LogoutCommand: ICommand
    {

        private IApplicationServices appServices;

        public LogoutCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public void Execute()
        {
            this.appServices.Logout();
            Console.WriteLine("User is now logged out.");
        }
    }
}
