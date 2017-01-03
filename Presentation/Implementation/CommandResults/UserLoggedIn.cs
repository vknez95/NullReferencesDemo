using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserLoggedIn: ICommandResult
    {
        public string Username { get; }
        public decimal Balance { get; }

        public UserLoggedIn(string username, decimal balance)
        {
            this.Username = username ?? string.Empty;
            this.Balance = balance;
        }
    }
}
