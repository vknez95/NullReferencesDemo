using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class InvalidResultView : IView
    {

        private InvalidResult result { get; }

        public InvalidResultView(InvalidResult result)
        {
            this.result = result;
        }

        public void Render()
        {
            Console.WriteLine("Invalid key entered.");
        }
    }
}
