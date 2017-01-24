using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class InvalidAccountTypeView : IView
    {

        private InvalidAccountType Data { get; }

        public InvalidAccountTypeView(InvalidAccountType data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Invalid account type selected: {0}", this.Data.AccountTypeId);
        }
    }
}
