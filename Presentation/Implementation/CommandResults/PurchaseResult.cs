using System;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class PurchaseResult: ICommandResult
    {

        public IPurchaseReport Report { get; }

        public PurchaseResult(IPurchaseReport purchaseReport)
        {

            if (purchaseReport == null)
                throw new ArgumentNullException(nameof(purchaseReport));

            this.Report = purchaseReport;

        } 
    }
}
