using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserAlreadyRegistered : ICommandResult
    {
        public string Username { get; }

        public UserAlreadyRegistered(string username)
        {
            this.Username = username ?? string.Empty;
        }
    }
}
