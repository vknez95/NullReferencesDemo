using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class LoginFailed: ICommandResult
    {
        public string Username { get; }

        public LoginFailed(string username)
        {
            this.Username = username ?? string.Empty;
        }
    }
}
