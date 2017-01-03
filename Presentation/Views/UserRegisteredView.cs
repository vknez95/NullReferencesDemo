using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserRegisteredView: IView
    {

        private UserRegistered Data { get; }

        public UserRegisteredView(UserRegistered data)
        {

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("User {0} is now registered.", this.Data.Username);
        }
    }
}
