using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class InvalidDepositView : IView
    {

        private InvalidDeposit Data { get; }

        public InvalidDepositView(InvalidDeposit data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Amount must be positive numeric value.");
        }
    }
}
