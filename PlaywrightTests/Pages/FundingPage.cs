using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    class FundingPage: BasePage
    {
        public FundingPage(IPage page): base(page) {}

        public async Task<FundingPage> SelectAccountAsync()
        {
            await Page.ClickAsync("//*[@id='accountRow101-012-21207034-001']/td[1]");
            return this;
        }

        public async Task<FundingPage> SelectTransferWindowAsync()
        {
            await Page.ClickAsync("transfer");
            return this;
        }

        public async Task<FundingPage> InputAmountAsync(double amount)
        {
            await Page.FillAsync("transfer-amount", Convert.ToString(amount));
            return this;
        }

        public async Task<FundingPage> CheckRateAsync()
        {
            await Page.ClickAsync("transfer_proceed");
            return this;
        }

        public async Task<FundingPage> FinishTransferAsync()
        {
            await Page.ClickAsync("tcr_proceed");
            return this;
        }

        public async Task<double> GetConversionRateAsync()
        {
            return Math.Round(
                    Convert.ToDouble(
                        await Page.TextContentAsync("//span[@data-bind='text transfer_quote.multiply_rate']")), 4);
        }

        public async Task<double> GetTransferResult()
        {
            return Math.Round(
                Convert.ToDouble(
                    await Page.TextContentAsync("//span[@data-bind='currency:destination_account.currency transfer_quote.destination_amount']")), 4);
        }

        public async Task<Double> GetConversionRate()
        {
            return Math.Round(
                Convert.ToDouble(
                    await Page.TextContentAsync("//span[@data-bind='text transfer_quote.multiply_rate']")), 4);
        }
    }
}
