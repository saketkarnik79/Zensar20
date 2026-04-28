using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Banking
{
    internal abstract class AccountBase
    {
        protected decimal balance;

        public abstract decimal Balance { get; }

        public abstract void Deposit(decimal amount);

        public abstract void Withdraw(decimal amount);
    }
}
