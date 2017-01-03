using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserRegistered: ICommandResult
    {
        public string Username { get; }

        public UserRegistered(string username)
        {
            this.Username = username ?? string.Empty;
        }
    }
}
