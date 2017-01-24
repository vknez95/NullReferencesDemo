using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Application.Implementation;
using NullReferencesDemo.Domain.Implementation;
using NullReferencesDemo.Domain.Implementation.Accounts;
using NullReferencesDemo.Infrastructure.Implementation;
using NullReferencesDemo.Presentation.Implementation;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Implementation.Commands;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.Interfaces.Validators;
using NullReferencesDemo.Presentation.PurchaseReports;
using NullReferencesDemo.Presentation.Validators;
using NullReferencesDemo.Presentation.Views;

namespace NullReferencesDemo
{
    class Program
    {
        public static MenuItem CreateRegisterNewUser(ApplicationServices appServices,
                                                     IEnumerable<IMoneyAccount> moneyAccounts,
                                                     IRegisterValidator validator)
        {
            IEnumerable<MenuItem> menu =
                            moneyAccounts.Select(moneyAccount => MenuItem.CreateNonTerminal
                                                    (
                                                        moneyAccount.AccountTypeId +
                                                            ") " + moneyAccount.AccountName + " - " + moneyAccount.Description,
                                                        char.Parse(moneyAccount.AccountTypeId.ToString()),
                                                        () => true
                                                    ));

            return MenuItem.CreateNonTerminal("Register new user", 'R',
                    new RegisterCommand(appServices, menu, validator), () => !appServices.IsUserLoggedIn);
        }

        static MenuItem CreateLogin(ApplicationServices appServices, IUsernameValidator validator)
        {
            return MenuItem.CreateNonTerminal("Login", 'L',
                    new LoginCommand(appServices, validator), () => !appServices.IsUserLoggedIn);
        }

        static MenuItem CreateLogout(ApplicationServices appServices)
        {
            return MenuItem.CreateNonTerminal("LogOut", 'O',
                    new LogoutCommand(appServices), () => appServices.IsUserLoggedIn);
        }

        static MenuItem CreateDeposit(ApplicationServices appServices, IDepositValidator validator)
        {
            return MenuItem.CreateNonTerminal("Deposit", 'D',
                    new DepositCommand(appServices, validator), () => appServices.IsUserLoggedIn);
        }

        static MenuItem CreatePurchase(ApplicationServices appServices)
        {
            return MenuItem.CreateNonTerminal("Purchase", 'P',
                    new PurchaseCommand(appServices), () => appServices.IsUserLoggedIn);
        }

        static bool Selector<TCommand>(ICommandResult cmdResult) where TCommand : ICommandResult
        {
            return cmdResult != null && cmdResult.GetType() == typeof(TCommand);
        }

        static bool PurchaseSelector<TPurchaseReport>(ICommandResult cmdResult)
            where TPurchaseReport : IPurchaseReport
        {

            PurchaseResult purchaseResult = cmdResult as PurchaseResult;

            if (purchaseResult == null)
                return false;

            return purchaseResult.Report.GetType() == typeof(TPurchaseReport);

        }

        static TPurchaseReport Cast<TPurchaseReport>(ICommandResult cmdResult)
            where TPurchaseReport : IPurchaseReport
        {

            PurchaseResult purchaseResult = cmdResult as PurchaseResult;

            if (purchaseResult == null)
                return default(TPurchaseReport);

            IPurchaseReport report = purchaseResult.Report;

            return (TPurchaseReport)report;

        }

        static ViewLocator CreateViewLocator()
        {
            ViewLocator viewLocator = new ViewLocator();

            viewLocator.RegisterService(Selector<DepositResult>, obj => new DepositView((DepositResult)obj));
            viewLocator.RegisterService(Selector<LoginFailed>, obj => new LoginFailedView((LoginFailed)obj));
            viewLocator.RegisterService(Selector<UserLoggedIn>, obj => new UserLoggedInView((UserLoggedIn)obj));
            viewLocator.RegisterService(Selector<UserLoggedOut>, obj => new UserLoggedOutView((UserLoggedOut)obj));
            viewLocator.RegisterService(Selector<UserRegistered>, obj => new UserRegisteredView((UserRegistered)obj));
            viewLocator.RegisterService(Selector<InvalidResult>, obj => new InvalidResultView((InvalidResult)obj));
            viewLocator.RegisterService(Selector<RegisterFailed>, obj => new RegisterFailedView((RegisterFailed)obj));
            viewLocator.RegisterService(Selector<InvalidUsername>, obj => new InvalidUsernameView((InvalidUsername)obj));
            viewLocator.RegisterService(Selector<UserAlreadyRegistered>, obj => new UserAlreadyRegisteredView((UserAlreadyRegistered)obj));
            viewLocator.RegisterService(Selector<InvalidDeposit>, obj => new InvalidDepositView((InvalidDeposit)obj));
            viewLocator.RegisterService(Selector<InvalidAccountType>, obj => new InvalidAccountTypeView((InvalidAccountType)obj));

            viewLocator.RegisterService(PurchaseSelector<FailedPurchase>, obj => new FailedPurchaseView());
            viewLocator.RegisterService(PurchaseSelector<NotEnoughMoney>, obj => new NotEnoughMoneyView(Cast<NotEnoughMoney>(obj)));
            viewLocator.RegisterService(PurchaseSelector<NotRegistered>, obj => new NotRegisteredView(Cast<NotRegistered>(obj)));
            viewLocator.RegisterService(PurchaseSelector<NotSignedIn>, obj => new NotSignedInView());
            viewLocator.RegisterService(PurchaseSelector<ProductNotFound>, obj => new ProductNotFoundView(Cast<ProductNotFound>(obj)));
            viewLocator.RegisterService(PurchaseSelector<Receipt>, obj => new ReceiptView(Cast<Receipt>(obj)));

            return viewLocator;
        }

        static void Main(string[] args)
        {

            IPurchaseReportFactory reportFactory = new PurchaseReportFactory();

            DomainServices domainServices = new DomainServices(new UserRepository(),
                                                               new ProductRepository(),
                                                               new AccountTypeRepository(),
                                                               reportFactory,
                                                               new AccountFactory());

            ApplicationServices appServices =
                new ApplicationServices(domainServices, reportFactory);

            IEnumerable<IMoneyAccount> moneyAccounts = domainServices.GetAvailableMoneyAccounts();

            IUsernameValidator usernameValidator = new UsernameValidator();
            IDepositValidator depositValidator = new DepositValidator();
            IAccountTypeValidator accountTypeValidator = new AccountTypeValidator(moneyAccounts);
            IRegisterValidator registerValidator = new RegisterValidator(usernameValidator, accountTypeValidator);

            IEnumerable<MenuItem> menu = new MenuItem[]
            {
                CreateRegisterNewUser(appServices, moneyAccounts, registerValidator),
                CreateLogin(appServices, usernameValidator),
                CreateLogout(appServices),
                CreateDeposit(appServices, depositValidator),
                CreatePurchase(appServices),
                MenuItem.CreateTerminal("Quit", 'Q')
            };

            ViewLocator viewLocator = CreateViewLocator();

            UserInterface ui =
                new UserInterface(
                    appServices,
                    viewLocator,
                    menu);

            while (ui.ReadCommand())
            {
                ui.ExecuteCommand();
            }
        }
    }
}
