using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace PlaywrightTests.Logger
{
    class LoggerSinkFormatter :ILogEventSink
    {
        private readonly ITextFormatter _formatter;

        public LoggerSinkFormatter(ITextFormatter formatter) => _formatter = formatter ??
                                                                       throw new ArgumentNullException(nameof(formatter));

        public void Emit(LogEvent logEvent)
        {
            using var output = new StringWriter();
            _formatter.Format(logEvent, output);
            TestContext.Progress.Write($"{TestContext.CurrentContext.Test.FullName} {output}");
        }
    }
}
