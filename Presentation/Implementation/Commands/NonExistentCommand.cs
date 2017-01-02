using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class NonExistentCommand : ICommand
    {
        private readonly char operationKey;

        public NonExistentCommand(char operationKey)
        {
            this.operationKey = operationKey;
        }

        public void Execute()
        {
            Console.Write("Operation ");
            ConsoleEx.WriteAndHighlight(this.operationKey, ConsoleColor.Magenta);
            Console.WriteLine(" does not exist.");
        }
    }
}
