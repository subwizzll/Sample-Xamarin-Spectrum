using MvvmCross.Forms.Views;
using Sample.Core.Framework.Effects;
using Sample.Core.ViewModels;

namespace Sample.Core.Views
{
   public partial class StoreItemDetailPage : MvxContentPage<StoreItemDetailViewModel>
   {
        public StoreItemDetailPage()
        { 
            InitializeComponent();
            Effects.Add(new SafeAreaInsetEffect());
        }
   }
}