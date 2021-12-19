using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Browsers
{
    class PageSingleton
    {
        private static IPage _page;
        private static IBrowser _browser;
        private static IBrowserContext _context;

        private PageSingleton() {}

        public static async Task<IPage> GetPageAsync(string browserName, string isHeadless, string cookiePath)
        {
            bool headlessStart;
            if (isHeadless.ToLower() == "true")
            {
                headlessStart = true;
            }
            else
            {
                headlessStart = false;
            }

            if (_page == null)
            {
                IPlaywright playwright = await Playwright.CreateAsync();
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    { Channel = browserName, Headless = headlessStart });
                _context = await _browser.NewContextAsync(new BrowserNewContextOptions
                    { StorageStatePath = cookiePath });
                _page = await _context.NewPageAsync();
            }
            return _page;
        }

        public static async Task<IPage> DisposeAsync()
        {
            await _page.CloseAsync();
            await _context.CloseAsync();
            await _browser.CloseAsync();
            await _browser.DisposeAsync();
            return _page;
        }
    }
}
