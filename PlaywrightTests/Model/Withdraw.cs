using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Model
{
    public class Withdraw
    {
        public double Amount { get; set; }
        public double BalanceBeforeWithdrawal { get => BalanceAfterWithdrawal + Amount; }
        public double BalanceAfterWithdrawal { get; set; }

        public Withdraw(double amount, double balanceAfterWithdrawal)
        {
            Amount = amount;
            BalanceAfterWithdrawal = balanceAfterWithdrawal;
        }
    }
}
