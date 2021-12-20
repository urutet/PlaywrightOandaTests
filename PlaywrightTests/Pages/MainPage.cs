using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<MainPage> SelectBuyStock()
        {
            await Page.Locator("button .bid .style-scope .panel-view-quote").Nth(1).ClickAsync();
            return this;
        }
    }
}
