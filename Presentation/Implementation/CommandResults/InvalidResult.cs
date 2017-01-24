using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class InvalidResult : ICommandResult
    {
        public char InvalidKey { get; }

        public InvalidResult(char invalidKey)
        {
            this.InvalidKey = invalidKey;
        }
    }
}
