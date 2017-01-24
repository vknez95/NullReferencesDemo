using System.Collections.Generic;

namespace NullReferencesDemo.Presentation.Interfaces
{
    public interface IApplicationServices
    {
        bool RegisterUser(string username, int accountTypeId);
        bool Login(string username);
        bool IsUserLoggedIn { get; }
        bool IsUserRegistered(string username);
        string LoggedInUsername { get; }
        void Logout();
        void Deposit(decimal amount);
        decimal LoggedInUserBalance { get; }
        IEnumerable<IStockItem> GetAvailableItems();
        IPurchaseReport Purchase(string itemName);
    }
}
