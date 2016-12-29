using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class DoNothingCommand: ICommand
    {
        public void Execute()
        {
        }
    }
}
