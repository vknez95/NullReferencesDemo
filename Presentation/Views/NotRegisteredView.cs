using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class NotRegisteredView: IView
    {

        private NotRegistered Data { get; }

        public NotRegisteredView(NotRegistered data)
        {
            
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.Write("User {0} is not registered.",
                          this.Data.Username);
        }
    }
}
