using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class NotRegistered: IPurchaseReport
    {

        public string Username { get; }

        public NotRegistered(string username)
        {
            this.Username = username;
        }
    }
}
