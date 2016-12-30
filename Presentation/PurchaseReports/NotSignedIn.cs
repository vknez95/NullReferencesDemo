using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class NotSignedIn : IPurchaseReport
    {
        public string ToUiText()
        {
            return string.Format("No user is signed in.");
        }
    }
}
