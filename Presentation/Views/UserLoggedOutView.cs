﻿using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserLoggedOutView: IView
    {

        private UserLoggedOut Data { get; }

        public UserLoggedOutView(UserLoggedOut data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("User {0} logged out.",
                              this.Data.Username);
        }
    }
}
