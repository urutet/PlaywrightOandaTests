using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Model
{
    public class Transfer
    {
        public double Amount { get; set; }
        public double CurrentTransferResult { get; set; }
        public double ConversionRate { get; set; }

        public double ExpectedTransferResult {get => Amount * ConversionRate;}

        public Transfer(double amount, double currentTransferResult, double conversionRate)
        {
            Amount = amount;
            CurrentTransferResult = currentTransferResult;
            ConversionRate = conversionRate;
        }
    }
}
