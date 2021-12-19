using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class FundingPage: BasePage
    {
        public FundingPage(IPage page): base(page) {}

        public async Task<FundingPage> SelectAccountAsync()
        {
            await Page.ClickAsync("//*[@id='accountRow101-012-21207034-001']/td[1]");
            return this;
        }

        public async Task<FundingPage> SelectTransferWindowAsync()
        {
            await Page.ClickAsync("#transfer");
            return this;
        }

        public async Task<FundingPage> SelectWithdrawWindowAsync()
        {
            await Page.ClickAsync("#withdraw");
            return this;
        }

        public async Task<FundingPage> SelectDepositWindowAsync()
        {
            await Page.ClickAsync("#deposit");
            return this;
        }

        public async Task<FundingPage> SelectCreditCardDepositAsync()
        {
            await Page.ClickAsync("//*[@id='deposit-form']/div[1]/div/table/tbody/tr/td[5]/a");
            return this;
        }

        public async Task<FundingPage> SelectCreditCardWithdrawalAsync()
        {
            await Page.ClickAsync("//*[@id='withdrawal-form']/div[1]/div/table/tbody/tr/td[5]/a");
            return this;
        }

        public async Task<FundingPage> InputAmountAsync(double amount)
        {
            await Page.FillAsync("//input[@class='adjustmentAmount']", Convert.ToString(amount));
            return this;
        }

        public async Task<FundingPage> FinishDepositAsync()
        {
            await Page.ClickAsync("#deposit-proceed");
            return this;
        }

        public async Task<FundingPage> FinishWithdrawalAsync()
        {
            await Page.ClickAsync("#withdrawal-proceed");
            return this;
        }

        public async Task<FundingPage> MakeWithdrawalAsync(double amount)
        {
            await SelectWithdrawWindowAsync().Result
                .SelectCreditCardWithdrawalAsync().Result
                .InputAmountAsync(amount).Result
                .FinishWithdrawalAsync();
            return this;
        }

        public async Task<FundingPage> MakeDepositAsync(double amount)
        {
            await SelectDepositWindowAsync().Result
                .SelectCreditCardDepositAsync().Result
                .InputAmountAsync(amount).Result
                .FinishDepositAsync();
            return this;
        }

        public async Task<FundingPage> InputTransferAmountAsync(double amount)
        {
            await Page.FillAsync("#withdrawal-amount", Convert.ToString(amount));
            return this;
        }

        public async Task<FundingPage> CheckRateAsync()
        {
            await Page.ClickAsync("#transfer_proceed");
            return this;
        }

        public async Task<FundingPage> FinishTransferAsync()
        {
            await Page.ClickAsync("#tcr_proceed");
            return this;
        }

        public async Task<FundingPage> MakeTransferAsync(double amount)
        {
            await SelectTransferWindowAsync().Result
                .InputTransferAmountAsync(amount).Result
                .CheckRateAsync().Result
                .FinishTransferAsync();
            return this;
        }

        public async Task<double> GetConversionRateAsync()
        {
            return Math.Round(
                    Convert.ToDouble(
                        await Page.TextContentAsync("//span[@data-bind='text transfer_quote.multiply_rate']")), 5);
        }

        public async Task<double> GetTransferResultAsync()
        {
            return Math.Round(
                Convert.ToDouble(
                    Page.TextContentAsync("//span[@data-bind='currency:destination_account.currency transfer_quote.destination_amount']")
                        .Result.Remove(0, 1)), 5);
        }

        public async Task<Double> GetResultAsync()
        {
            return Math.Round(
                Convert.ToDouble(
                    Page.TextContentAsync("//*[@id='summary']/table/tbody/tr[5]/td[2]")
                        .Result.Remove(0, 1)), 7);
        }
    }
}
