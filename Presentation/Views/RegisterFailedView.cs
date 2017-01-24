using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class RegisterFailedView : IView
    {

        private RegisterFailed Data { get; }

        public RegisterFailedView(RegisterFailed data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Registration failed for user {0}.",
                              this.Data.Username);
        }
    }
}
