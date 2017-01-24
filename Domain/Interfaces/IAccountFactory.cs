namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IAccountFactory
    {
        IAccount CreateAccount(int accountTypeId);
    }
}
