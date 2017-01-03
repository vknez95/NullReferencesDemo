using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class DepositView: IView
    {

        private DepositResult Data { get; }

        public DepositView(DepositResult data)
        {

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("User {0} has deposited {1:C2}; {2:C2} available.",
                              this.Data.Username, this.Data.Amount,
                              this.Data.Balance);
        }
    }
}
