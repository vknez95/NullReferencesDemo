using System;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class NotSignedInView: IView
    {
        public void Render()
        {
            Console.WriteLine("No user is signed in.");
        }
    }
}
