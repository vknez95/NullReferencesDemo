using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserAlreadyRegisteredView : IView
    {

        private UserAlreadyRegistered Data { get; }

        public UserAlreadyRegisteredView(UserAlreadyRegistered data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("User {0} is already registered.", this.Data.Username);
        }
    }
}
