﻿using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class RegisterCommand: ICommand
    {

        private readonly IApplicationServices appServices;

        public RegisterCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            
            Console.Write("Enter username to register: ");
            string username = Console.ReadLine();

            this.appServices.RegisterUser(username);

            return new UserRegistered(username);

        }
    }
}
