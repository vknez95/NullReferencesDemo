using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class FailedPurchase : IPurchaseReport
    {
        private static FailedPurchase instance;

        private FailedPurchase()
        {
        }

        public static FailedPurchase Instance
        {
            get
            {
                if (instance == null)
                    instance = new FailedPurchase();

                return instance;
            }
        }

        public string ToUiText()
        {
            return "Purchase failed.";
        }
    }
}
