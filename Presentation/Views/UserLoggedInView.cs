using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserLoggedInView : IView
    {
        private UserLoggedIn Data { get; }

        public UserLoggedInView(UserLoggedIn data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("User {0} logged in; {1:C2} available",
                              this.Data.Username,
                              this.Data.Balance);
        }
    }
}
