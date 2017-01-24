using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.Implementation.Commands;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Presentation.Implementation
{
    public class UserInterface : IUserInterface
    {

        private readonly IApplicationServices appServices;
        private ICommand currentCommand = new DoNothingCommand();
        private readonly IEnumerable<MenuItem> menu;
        private readonly ViewLocator viewLocator;

        public UserInterface(IApplicationServices appServices,
                             ViewLocator viewLocator,
                             IEnumerable<MenuItem> menu)
        {

            this.appServices = appServices;

            this.menu = menu;

            this.viewLocator = viewLocator;

        }

        public bool ReadCommand()
        {

            this.RefreshDisplay();

            MenuItem selectedMenuItem = SelectMenuItem();

            if (selectedMenuItem.IsTerminalCommand)
                return false;

            this.currentCommand = selectedMenuItem.Command;
            return true;

        }

        public void ExecuteCommand()
        {

            ICommandResult result = this.currentCommand.Execute();

            IView view = this.viewLocator.LocateServiceFor(result);

            Render(view);

            Console.WriteLine();
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();

        }

        private void RefreshDisplay()
        {
            Console.Clear();
            this.ShowStatus();
            this.ShowMenu();
        }

        private void Render(IView view)
        {

            Console.WriteLine("");

            view.Render();

            Console.WriteLine("");

        }

        private void ShowStatus()
        {

            Console.Write("Logged in user: ");
            this.Highlight(this.LoggedInUserDisplay);
            Console.WriteLine();

            Console.Write("       Balance: ");
            this.Highlight(this.BalanceDisplay);
            Console.WriteLine();

            Console.WriteLine();

        }

        private string LoggedInUserDisplay
        {
            get
            {
                if (this.appServices.IsUserLoggedIn)
                    return this.appServices.LoggedInUsername;
                return "none";
            }
        }

        private string BalanceDisplay
        {
            get
            {
                if (this.appServices.IsUserLoggedIn)
                    return this.appServices.LoggedInUserBalance.ToString("C");
                return "N/A";
            }
        }

        private void Highlight(string message)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ForegroundColor = prevColor;
        }

        private void ShowMenu()
        {

            Console.WriteLine("Select operation:");
            Console.WriteLine();

            foreach (MenuItem menuItem in this.menu)
                menuItem.Display();

            Console.WriteLine();

        }

        private MenuItem SelectMenuItem()
        {

            ConsoleKeyInfo key = Console.ReadKey(true);

            MenuItem selectedItem =
                this.menu
                    .Where(item => item.MatchesKey(key.KeyChar))
                    .LazyDefaultIfEmpty(() => MenuItem.CreateInvalid(key.KeyChar, new InvalidCommand(key.KeyChar)))
                    .Single();

            return selectedItem;

        }
    }
}
