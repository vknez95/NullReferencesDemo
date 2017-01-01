using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class NotRegistered : IPurchaseReport
    {
        private readonly string username;
        
        public NotRegistered(string username)
        {
            this.username = username;
        }

        public string ToUiText()
        {
            return string.Format("User {0} is not registered.", this.username);
        }
    }
}
