using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.Implementation.Commands;

namespace NullReferencesDemo.Presentation.Implementation
{
    internal class MenuItem
    {

        private readonly string caption;
        private readonly char hotkey;
        private readonly bool isTerminal;
        private readonly ICommand command;
        private readonly Func<bool> isVisible;

        private MenuItem(string caption, char hotkey, bool isTerminal, ICommand command, Func<bool> isVisible)
        {
            this.caption = caption;
            this.hotkey = hotkey;
            this.isTerminal = isTerminal;
            this.command = command;
            this.isVisible = isVisible;
        }

        public static MenuItem CreateTerminal(string caption, char hotkey)
        {
            return new MenuItem(caption, hotkey, true, new DoNothingCommand(), () => true);
        }

        public static MenuItem CreateNonTerminal(string caption, char hotkey, ICommand command, Func<bool> isVisible)
        {
            return new MenuItem(caption, hotkey, false, command, isVisible);
        }

        public void Display()
        {

            if (!this.isVisible())
                return;

            int pos = this.caption.IndexOf(this.hotkey);

            if (pos > 0)
                Console.Write(this.caption.Substring(0, pos));

            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.hotkey);
            Console.ForegroundColor = previousColor;

            if (pos < this.caption.Length - 1)
                Console.Write(this.caption.Substring(pos + 1));

            Console.WriteLine();

        }

        public bool IsTerminalCommand
        {
            get
            {
                return this.isTerminal;
            }
        }

        public bool MatchesKey(char key)
        {
            return this.isVisible() && char.ToLower(this.hotkey) == char.ToLower(key);
        }

        public ICommand Command
        {
            get
            {
                return this.command;
            }
        }

    }
}
