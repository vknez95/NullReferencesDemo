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

        public UserInterface(IApplicationServices appServices)
        {

            this.appServices = appServices;

            this.menu = new MenuItem[]
            {
                MenuItem.CreateNonTerminal("Register new user", 'R', new RegisterCommand(appServices), () => true),
                MenuItem.CreateNonTerminal("Login", 'L', new LoginCommand(appServices), () => true),
                MenuItem.CreateNonTerminal("LogOut", 'O', new LogoutCommand(appServices), () => appServices.IsUserLoggedIn),
                MenuItem.CreateNonTerminal("Deposit", 'D', new DepositCommand(appServices), () => appServices.IsUserLoggedIn),
                MenuItem.CreateNonTerminal("Purchase", 'P', new PurchaseCommand(appServices), () => true),
                MenuItem.CreateTerminal("Quit", 'Q')
            };

        }

        public bool ReadCommand()
        {

            this.RefreshDisplay();

            ConsoleKeyInfo key = Console.ReadKey(true);

            ICommand command = ReadCommand(key);

            if (command is DoNothingCommand)
                return false;

            this.currentCommand = command;
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

            this.currentCommand.Execute();

            Console.WriteLine();
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();

        }

        private void ShowStatus()
        {

            Console.Write("Logged in user: ");
            ConsoleEx.WriteAndHighlight(this.LoggedInUserDisplay, ConsoleColor.Cyan);
            Console.WriteLine();

            Console.Write("       Balance: ");
            ConsoleEx.WriteAndHighlight(this.BalanceDisplay, ConsoleColor.Cyan);
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

        private void ShowMenu()
        {

            Console.WriteLine("Select operation:");
            Console.WriteLine();

            foreach (MenuItem menuItem in this.menu)
                menuItem.Display();

            Console.WriteLine();

        }

        private ICommand ReadCommand(ConsoleKeyInfo key)
        {
            return
                this.TrySelectMenuItem(key)
                    .Select(menuItem => menuItem.Command)
                    .DefaultIfEmpty(new NonExistentCommand(key.KeyChar))
                    .Single();
        }

        private Option<MenuItem> TrySelectMenuItem(ConsoleKeyInfo key)
        {

            MenuItem selectedItem = this.menu.FirstOrDefault(item => item.MatchesKey(key.KeyChar));

            if (selectedItem == null)
                return Option<MenuItem>.CreateEmpty();
            return Option<MenuItem>.Create(selectedItem);

        }
    }
}
