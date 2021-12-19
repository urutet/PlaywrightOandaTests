using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class LoginPage: BasePage
    {
        public LoginPage(IPage page) : base(page) {}

        public async Task<LoginPage> GoToLoginPageAsync()
        {
            await Page.GotoAsync($"https://trade.oanda.com/");
            return this;
        }

        public async Task<LoginPage> SelectAccountTypeAsync()
        {
            await Page.ClickAsync("[name='practice']");
            return this;
        }

        public async Task<MainPage> LoginAsync(string email, string password)
        {
            await SelectAccountTypeAsync();
            await Page.FillAsync("#username", email);
            await Page.FillAsync("#password", password);
            await Page.ClickAsync("//*[@id='loginButton']");
            return new MainPage(Page);
        }

    }
}
