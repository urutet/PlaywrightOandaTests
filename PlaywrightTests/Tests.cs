using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests.Browsers;
using PlaywrightTests.Logger;
using PlaywrightTests.Model;
using PlaywrightTests.Pages;
using PlaywrightTests.Service;

namespace PlaywrightTests
{
    //need to use browserTest or contextTest
    public class Tests : Logging
    {
        private IPage _page;
        private User _user;

        [OneTimeSetUp]
        public async Task Setup()
        {
            _user = UserCreator.userWithDefaultCookie();
            //TestContext.Parameters[];
            _page = await PageSingleton.GetPageAsync("chrome",
                "false",
                _user.CookiePath);
        }

        [Test]
        [TestCase(1)]
        public async Task BuyMarketStocks_ReturnsExpectedAmount(int amount)
        {
            MainPage mainPage = new MainPage(_page);
            Stock stock = new Stock();
            stock.NumberBeforeOperation = await mainPage.GetStocksAmount();
            await mainPage.BuyMarketStockAsync(amount);

            await mainPage.WaitTimeOutAsync(5000.0f);

            stock.NumberAfterOperation = await mainPage.GetStocksAmount();
            Assert.AreEqual(stock.NumberBeforeOperation, stock.NumberAfterOperation - amount);
        }

        [Test]
        [TestCase(1)]
        public async Task SellMarketStocks_ReturnsExpectedAmount(int amount)
        {
            MainPage mainPage = new MainPage(_page);
            Stock stock = new Stock();

            stock.NumberBeforeOperation = await mainPage.GetStocksAmount();

            await mainPage.SellMarketStockAsync(amount);
            await mainPage.WaitTimeOutAsync(5000.0f);

            stock.NumberAfterOperation = await mainPage.GetStocksAmount();
            Assert.AreEqual(stock.NumberBeforeOperation, stock.NumberAfterOperation + amount);
        }

        [Test]
        [TestCase(1)]
        public async Task BuyLimitStocks_ReturnsExpectedAmount(int amount)
        {
            MainPage mainPage = new MainPage(_page);
            Stock stock = new Stock();
            stock.NumberBeforeOperation = await mainPage.GetStocksAmount();
            await mainPage.BuyLimitStockAsync(amount);

            await mainPage.WaitTimeOutAsync(5000.0f);

            stock.NumberAfterOperation = await mainPage.GetStocksAmount();
            Assert.AreEqual(stock.NumberBeforeOperation, stock.NumberAfterOperation - amount);
        }

        [Test]
        [TestCase(1)]
        public async Task SellLimitStocks_ReturnsExpectedAmount(int amount)
        {
            MainPage mainPage = new MainPage(_page);
            Stock stock = new Stock();

            stock.NumberBeforeOperation = await mainPage.GetStocksAmount();

            await mainPage.SellLimitStockAsync(amount);
            await mainPage.WaitTimeOutAsync(5000.0f);

            stock.NumberAfterOperation = await mainPage.GetStocksAmount();
            Assert.AreEqual(stock.NumberBeforeOperation, stock.NumberAfterOperation + amount);
        }

                [Test]
        [TestCase(1)]
        public async Task BuyStopStocks_ReturnsExpectedAmount(int amount)
        {
            MainPage mainPage = new MainPage(_page);
            Stock stock = new Stock();
            stock.NumberBeforeOperation = await mainPage.GetStocksAmount();
            await mainPage.BuyStopStockAsync(amount);

            await mainPage.WaitTimeOutAsync(5000.0f);

            stock.NumberAfterOperation = await mainPage.GetStocksAmount();
            Assert.AreEqual(stock.NumberBeforeOperation, stock.NumberAfterOperation - amount);
        }

        [Test]
        [TestCase(1)]
        public async Task SellStopStocks_ReturnsExpectedAmount(int amount)
        {
            MainPage mainPage = new MainPage(_page);
            Stock stock = new Stock();

            stock.NumberBeforeOperation = await mainPage.GetStocksAmount();

            await mainPage.SellStopStockAsync(amount);
            await mainPage.WaitTimeOutAsync(5000.0f);

            stock.NumberAfterOperation = await mainPage.GetStocksAmount();
            Assert.AreEqual(stock.NumberBeforeOperation, stock.NumberAfterOperation + amount);
        }

        [Test]
        [TestCase(10)]
        public async Task MoneyTransfer_ReturnsExpectedValue(double amount)
        {
            FundingPage fundingPage = await new MainPage(_page)
                .GoToFundingPageAsync().Result
                .MakeTransferAsync(10);

            Transfer transfer = new Transfer(amount, await fundingPage.GetTransferResultAsync(),
                await fundingPage.GetConversionRateAsync());

            Assert.AreEqual(transfer.ExpectedTransferResult, transfer.CurrentTransferResult);
        }

        [Test]
        [TestCase(10)]
        public async Task MoneyWithdrawal_ReturnsExpectedValue(double amount)
        {
            FundingPage fundingPage = await new MainPage(_page)
                .GoToFundingPageAsync().Result
                .MakeWithdrawalAsync(10);
            Withdraw withdraw = new Withdraw(amount, await fundingPage.GetResultAsync());

            Assert.AreEqual(withdraw.BalanceBeforeWithdrawal, withdraw.BalanceAfterWithdrawal + withdraw.Amount);
        }

        [Test]
        [TestCase(10)]
        public async Task MoneyDeposit_ReturnsExpectedValue(double amount)
        {
            FundingPage fundingPage = await new MainPage(_page)
                .GoToFundingPageAsync().Result
                .MakeDepositAsync(10);
            Deposit deposit = new Deposit(amount, await fundingPage.GetResultAsync());

            Assert.AreEqual(deposit.BalanceBeforeDeposit, deposit.BalanceAfterDeposit - deposit.Amount);
        }

        [OneTimeTearDown]
        public async Task Teardown()
        {
            _page = await PageSingleton.DisposeAsync();
        }
    }
}