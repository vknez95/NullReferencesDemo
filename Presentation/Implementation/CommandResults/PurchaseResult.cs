using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class PurchaseResult : ICommandResult
    {

        public IPurchaseReport Report { get; }

        public PurchaseResult(IPurchaseReport purchaseReport)
        {
            Contract.Requires<ArgumentNullException>(purchaseReport != null, nameof(purchaseReport));

            this.Report = purchaseReport;

        }
    }
}
