using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
//using Serilog;
//using Serilog.Extensions.Logging;
using Sample.Core;

namespace Sample.Droid
{
    public class Setup : MvxFormsAndroidSetup<AppStart, FormsApp>
    {
        protected override ILoggerProvider CreateLogProvider() => null;

        protected override ILoggerFactory CreateLogFactory() => null;
    }
}