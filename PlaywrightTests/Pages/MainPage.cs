using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    class MainPage : BasePage
    {
        public MainPage(IPage page) : base(page) {}

        public async Task<FundingPage> GoToFundingPageAsync()
        {
            await Page.GotoAsync("https://www.oanda.com/demo-account/funding/");
            return new FundingPage(Page);
        }
    }
}
