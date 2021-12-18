using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    class LoginPage: BasePage
    {
        LoginPage(IPage page) : base(page) {}

        public async Task<LoginPage> GoToLoginPageAsync()
        {
            await Page.GotoAsync($"https://trade.oanda.com/");
            return this;
        }

        public async Task<LoginPage> SelectAccountTypeAsync()
        {
            await Page.ClickAsync("practice");
            return this;
        }

        public async Task<MainPage> LoginAsync()
        {
            await Page.FillAsync("username", "onada@mailinator.com");
            await Page.FillAsync("password", "qwerT1zed!");
            await Page.ClickAsync("//*[@id='loginButton']");
            return new MainPage(Page);
        }

    }
}
