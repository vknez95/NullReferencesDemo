using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class LoginFailedView: IView
    {

        private LoginFailed Data { get; }

        public LoginFailedView(LoginFailed data)
        {

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Login failed for user {0}.",
                              this.Data.Username);
        }
    }
}
