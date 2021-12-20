using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(IPage page) : base(page)
        {
            Page.GotoAsync("https://trade.oanda.com/");
        }

        public async Task<FundingPage> GoToFundingPageAsync()
        {
            await Page.GotoAsync("https://www.oanda.com/demo-account/funding/");
            return new FundingPage(Page);
        }

        public async Task<MainPage> SelectSellStockAsync()
        {
            await Page.Locator("//*[@id='ratesComponent']/div/rates-panel-selector/div/div[2]/div/iron-pages/panel-view/div/panel-view-quote[1]/div/div[2]/button[1]/div[2]/strong").ClickAsync();
            return this;
        }

        public async Task<MainPage> SelectBuyStockAsync()
        {
            await Page.Locator("//*[@id='ratesComponent']/div/rates-panel-selector/div/div[2]/div/iron-pages/panel-view/div/panel-view-quote[1]/div/div[2]/button[2]/div[2]/strong").ClickAsync();
            return this;
        }

        public async Task<MainPage> SelectMarketStockAsync()
        {
            await Page.Locator("//a[@data-view='market']").ClickAsync();
            return this;
        }

        public async Task<MainPage> SelectLimitStockAsync()
        {
            await Page.Locator("//a[@data-view='limit']").ClickAsync();
            return this;
        }

        public async Task<MainPage> SelectStopStockAsync()
        {
            await Page.Locator("//a[@data-view='stop']").ClickAsync();
            return this;
        }

        public async Task<MainPage> InputAmountAsync(int amount)
        {
            await Page.Locator("//*[@id='unit-input']/div/input")
                .FillAsync(Convert.ToString(amount));
            return this;
        }

        public async Task<MainPage> SubmitOperationAsync()
        {
            await Page.ClickAsync("//*[@id='submit']");
            return this;
        }

        public async Task<MainPage> SellMarketStockAsync(int amount)
        {
            await SelectSellStockAsync();
            await SelectMarketStockAsync();
            await InputAmountAsync(amount);
            await SubmitOperationAsync();
            return this;
        }

        public async Task<MainPage> BuyMarketStockAsync(int amount)
        {
            await SelectBuyStockAsync();
            await SelectMarketStockAsync();
            await InputAmountAsync(amount);
            await SubmitOperationAsync();
            return this;
        }

        public async Task<MainPage> SellLimitStockAsync(int amount)
        {
            await SelectSellStockAsync();
            await SelectLimitStockAsync();
            await InputAmountAsync(amount);
            await SubmitOperationAsync();
            return this;
        }

        public async Task<MainPage> BuyLimitStockAsync(int amount)
        {
            await SelectBuyStockAsync();
            await SelectLimitStockAsync();
            await InputAmountAsync(amount);
            await SubmitOperationAsync();
            return this;
        }

        public async Task<MainPage> SellStopStockAsync(int amount)
        {
            await SelectSellStockAsync();
            await SelectStopStockAsync();
            await InputAmountAsync(amount);
            await SubmitOperationAsync();
            return this;
        }

        public async Task<MainPage> BuyStopStockAsync(int amount)
        {
            await SelectBuyStockAsync();
            await SelectStopStockAsync();
            await InputAmountAsync(amount);
            await SubmitOperationAsync();
            return this;
        }

        public async Task<int> GetStocksAmount()
        {
            string str = await Page.Locator("//*[@id='positionsPortfolioManager']/div/div/div[2]/div/div[2]/div[1]/div[2]")
                .TextContentAsync();
            return Convert.ToInt32(Regex.Match(str, @"\d+").Value);
        }
    }
}
