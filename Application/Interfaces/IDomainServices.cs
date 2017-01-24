using NullReferencesDemo.Presentation.Interfaces;
using System.Collections.Generic;

namespace NullReferencesDemo.Application.Interfaces
{
    public interface IDomainServices
    {
        void CreateUser(string username, int accountTypeId);
        bool IsRegistered(string username);
        void Deposit(string username, decimal amount);
        decimal GetBalance(string username);
        IEnumerable<IStockItem> GetAvailableItems();
        IEnumerable<IMoneyAccount> GetAvailableMoneyAccounts();
        IPurchaseReport Purchase(string username, string itemName);
    }
}
