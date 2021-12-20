using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Microsoft.Playwright.Helpers;
using PlaywrightTests.Utils;
using Serilog;
using Serilog.Sinks.SystemConsole;

namespace PlaywrightTests.Logger
{
    public class Logging
    {
        protected IConfiguration Configuration;
        protected ILogger Logger;
        protected IPage Page;


        [OneTimeSetUp]
        public void LoadConfiguration()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Logger = new LoggerConfiguration().WriteTo
                .Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            Log.Logger = Logger;
        }

        [SetUp]
        public async Task OnSetup()
        {
            Logger.Information("Started");
        }

        private async Task ScreenshotOnFail()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome;
            if (outcome == ResultState.Error)
            {
                await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = DirectoryNames.GetSolutionDirectory + @"/Screenshots/" + $"{DateTime.Now:dd-mm-yyyy-hh-mm-ss}.png"
                });
            }
        }
        private async Task LogResult()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome;
            if (outcome == ResultState.Error)
            {
                Logger.Error($"Failed: {TestContext.CurrentContext.Result.Message}");
                return;
            }

            Logger.Information($"Finished with outcome: {outcome}");
        }
        [TearDown]
        public async Task OnTearDown()
        {
            await ScreenshotOnFail();
            await LogResult();
        }

        [OneTimeTearDown]
        public void FlushLogger()
        {
            Trace.Flush();
        }
    }
}
