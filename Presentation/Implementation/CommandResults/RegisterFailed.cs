using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class RegisterFailed : ICommandResult
    {
        public string Username { get; }

        public RegisterFailed(string username)
        {
            this.Username = username ?? string.Empty;
        }
    }
}
