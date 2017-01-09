using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.Implementation.Commands;

namespace NullReferencesDemo.Presentation.Implementation
{
    public class UserInterface: IUserInterface
    {

        private readonly IApplicationServices appServices;
        private ICommand currentCommand = new DoNothingCommand();
        private readonly IEnumerable<MenuItem> menu;

        private readonly ViewLocator viewLocator;

        public UserInterface(IApplicationServices appServices, ViewLocator viewLocator)
        {

            this.appServices = appServices;

            this.menu = new MenuItem[]
            {
                MenuItem.CreateNonTerminal("Register new user", 'R',
                    new RegisterCommand(appServices), () => true),
                MenuItem.CreateNonTerminal("Login", 'L',
                    new LoginCommand(appServices), () => true),
                MenuItem.CreateNonTerminal("LogOut", 'O',
                    new LogoutCommand(appServices), () => appServices.IsUserLoggedIn),
                MenuItem.CreateNonTerminal("Deposit", 'D',
                    new DepositCommand(appServices), () => appServices.IsUserLoggedIn),
                MenuItem.CreateNonTerminal("Purchase", 'P',
                    new PurchaseCommand(appServices), () => true),
                MenuItem.CreateTerminal("Quit", 'Q')
            };

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

        private void RefreshDisplay()
        {
            Console.Clear();
            this.ShowStatus();
            this.ShowMenu();
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

        private void Render(IView view)
        {

            string message = string.Format("Rendering {0}", view.GetType().Name);
            string delimiter = new string('-', message.Length);

            Console.WriteLine("\n{0}\n{1}\n{0}\n", delimiter, message);

            view.Render();

            Console.WriteLine("\n{0}", delimiter);

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
            Console.ForegroundColor = ConsoleColor.White;
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

            MenuItem selectedItem = this.menu.Single(item => item.MatchesKey(key.KeyChar));

            return selectedItem;

        }
    }
}
