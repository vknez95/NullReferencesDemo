using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class InvalidUsernameView : IView
    {

        private InvalidUsername Data { get; }

        public InvalidUsernameView(InvalidUsername data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Username is invalid due to one of the following reasons:");
            Console.WriteLine("    - Must contain a combination of alphanumeric or underscore characters");
            Console.WriteLine("    - Must start with alpha character");
            Console.WriteLine("    - Must be at least {0} characters in length", Data.MinLength);
        }
    }
}
