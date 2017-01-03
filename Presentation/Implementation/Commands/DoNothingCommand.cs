using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class DoNothingCommand: ICommand
    {
        public ICommandResult Execute()
        {
            return new NoResult();
        }
    }
}
