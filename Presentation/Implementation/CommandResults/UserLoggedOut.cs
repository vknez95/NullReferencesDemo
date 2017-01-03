using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserLoggedOut: ICommandResult
    {
        public string Username { get; }

        public UserLoggedOut(string username)
        {
            this.Username = username ?? string.Empty;
        }
    }
}
