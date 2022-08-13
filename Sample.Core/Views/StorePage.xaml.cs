using MvvmCross.Forms.Views;
using Sample.Core.Framework.Effects;
using Sample.Core.ViewModels;
using Xamarin.Forms;

namespace Sample.Core.Views
{
   public partial class StorePage : MvxContentPage<StoreViewModel>
   {
        public StorePage()
        { 
            InitializeComponent();
            Effects.Add(new SafeAreaInsetEffect());
        }
   }
}