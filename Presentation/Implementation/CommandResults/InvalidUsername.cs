using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class InvalidUsername : ICommandResult
    {
        public string Username { get; }
        public int MinLength { get; }

        public InvalidUsername(string username, int minLength)
        {
            this.Username = username ?? string.Empty;
            this.MinLength = minLength;
        }
    }
}
