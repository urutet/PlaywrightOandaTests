using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;



namespace PlaywrightTests.Pages
{
    public abstract class BasePage
    {
        protected IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }

        public async Task<BasePage> WaitTimeOutAsync(float time)
        {
            await Page.WaitForTimeoutAsync(time);
            return this;
        }
    }
}
