using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_DemoOOP.Insurance;

namespace CS_DemoOOP.Banking
{
    internal class SavingsAccount: AccountBase, IInsurance
    {
        public sealed override decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            balance += amount;
        }

        public decimal GetPremium()
        {
            return 0.02m * balance; // Example premium calculation as 2% of balance
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            balance -= amount;
        }
    }
}