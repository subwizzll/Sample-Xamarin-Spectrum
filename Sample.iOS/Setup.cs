using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;
using Sample.Core;

namespace Sample.iOS
{
    public class Setup : MvxFormsIosSetup<AppStart, FormsApp>
    {
        protected override ILoggerProvider CreateLogProvider() => null;

        protected override ILoggerFactory CreateLogFactory() => null;
    }
}