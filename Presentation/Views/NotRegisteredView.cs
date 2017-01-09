using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class NotRegisteredView: IView
    {

        private NotRegistered Data { get; }

        public NotRegisteredView(NotRegistered data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.Write("User {0} is not registered.",
                          this.Data.Username);
        }
    }
}
