using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation.Accounts
{
    public class CreditAccount : AccountBase
    {

        private readonly IList<MoneyTransaction> pendingTransactions = new List<MoneyTransaction>();
        private readonly ITransactionSelector pendingTransactionSelectionStrategy;

        public CreditAccount(ITransactionSelector transactionSelectionStrategy)
        {
            Contract.Requires<ArgumentNullException>(transactionSelectionStrategy != null, nameof(transactionSelectionStrategy));

            this.pendingTransactionSelectionStrategy = transactionSelectionStrategy;
        }

        public override decimal Balance
        {
            get
            {
                return base.Balance + this.pendingTransactions.Sum(trans => trans.Amount);
            }
        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {
            Contract.Requires<ArgumentException>(amount > 0, "Amount to withdraw must be positive.", nameof(amount));

            MoneyTransaction transaction = new MoneyTransaction(-amount);

            this.pendingTransactions.Add(transaction);
            this.ProcessPendingWithdrawals();

            return Option<MoneyTransaction>.Create(transaction);

        }

        public override MoneyTransaction Deposit(decimal amount)
        {
            Contract.Requires<ArgumentException>(amount > 0, "Amount to deposit must be positive.", nameof(amount));

            MoneyTransaction transaction = new MoneyTransaction(amount);
            base.RegisterTransaction(transaction);

            this.ProcessPendingWithdrawals();

            return transaction;

        }

        private void ProcessPendingWithdrawals()
        {

            Option<MoneyTransaction> option = Option<MoneyTransaction>.CreateEmpty();

            do
            {
                option = this.TrySelectPendingTransaction();
                ProcessPendingWithdrawal(option);
            }
            while (option.Any());

        }

        private Option<MoneyTransaction> TrySelectPendingTransaction()
        {
            return
                this.pendingTransactionSelectionStrategy
                    .TrySelectOne(this.pendingTransactions, base.Balance);
        }

        private void ProcessPendingWithdrawal(Option<MoneyTransaction> option)
        {

            if (!option.Any())
                return;

            MoneyTransaction transaction = option.Single();

            base.RegisterTransaction(transaction);
            this.pendingTransactions.Remove(transaction);

        }
    }
}
