using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Configuration;
using Serilog.Formatting.Display;

namespace PlaywrightTests.Logger
{
    public static class LoggerSinkExtension
    {
        public static LoggerConfiguration DebugTest(
            this LoggerSinkConfiguration sinkConfiguration,
            string outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
            IFormatProvider formatProvider = null)
        {
            var formatter = outputTemplate != null
                ? new MessageTemplateTextFormatter(outputTemplate, formatProvider)
                : throw new ArgumentNullException(nameof(outputTemplate));
            return sinkConfiguration.Sink(new LoggerSinkFormatter(formatter));
        }
    }
}
