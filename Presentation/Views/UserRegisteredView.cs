using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserRegisteredView: IView
    {

        private UserRegistered Data { get; }

        public UserRegisteredView(UserRegistered data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("User {0} is now registered.", this.Data.Username);
        }
    }
}
