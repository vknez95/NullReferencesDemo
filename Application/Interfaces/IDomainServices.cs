using NullReferencesDemo.Presentation.Interfaces;
using System.Collections.Generic;

namespace NullReferencesDemo.Application.Interfaces
{
    public interface IDomainServices
    {
        void CreateUser(string username);
        bool IsRegistered(string username);
        void Deposit(string username, decimal amount);
        decimal GetBalance(string username);
        IEnumerable<StockItem> GetAvailableItems();
        IPurchaseReport Purchase(string username, string itemName);
    }
}
