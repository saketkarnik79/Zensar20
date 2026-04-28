using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Banking
{
    internal class LoanAccount: AccountBase
    {
        public sealed override decimal Balance => balance; // Read-only property implemented as an expression-bodied member

        public override void Withdraw(decimal amount)
        {
            if(amount <= 0) 
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            balance += amount;
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            if(amount > balance)
            {
                throw new InvalidOperationException("Deposit amount cannot exceed the outstanding loan balance.");
            }
            balance -= amount;
        }
    }
}
