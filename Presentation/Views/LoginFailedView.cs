using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class LoginFailedView : IView
    {

        private LoginFailed Data { get; }

        public LoginFailedView(LoginFailed data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Login failed for user {0}.",
                              this.Data.Username);
        }
    }
}
