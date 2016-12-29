using NullReferencesDemo.Presentation.Interfaces;
namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IUser
    {
        string Username { get; }
        void Deposit(decimal amount);
        decimal Balance { get; }
        IPurchaseReport Purchase(IProduct product);
    }
}
