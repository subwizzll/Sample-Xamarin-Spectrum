using Sample.Core;
using Foundation;
using UIKit;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace Sample.iOS
{

    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, AppStart, FormsApp>
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
            => base.FinishedLaunching(app, options);
    }
}
