using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class InvalidCommand : ICommand
    {
        private char invalidKey;

        public InvalidCommand(char invalidKey)
        {
            this.invalidKey = invalidKey;
        }
        public ICommandResult Execute()
        {
            return new InvalidResult(this.invalidKey);
        }
    }
}
