using System.Collections.Generic;

namespace NullReferencesDemo.Presentation.Interfaces
{
    public interface IApplicationServices
    {
        void RegisterUser(string username);
        bool Login(string username);
        bool IsUserLoggedIn { get; }
        string LoggedInUsername { get; }
        void Logout();
        void Deposit(decimal amount);
        decimal LoggedInUserBalance { get; }
        IEnumerable<StockItem> GetAvailableItems();
        Receipt Purchase(string itemName);
    }
}
