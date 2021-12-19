using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Model
{
    public class Deposit
    {
        public double Amount { get; set; }
        public double BalanceBeforeDeposit { get => BalanceAfterDeposit - Amount; }
        public double BalanceAfterDeposit { get; set; }

        public Deposit(double amount, double balanceAfterDeposit)
        {
            Amount = amount;
            BalanceAfterDeposit = balanceAfterDeposit;
        }
    }
}