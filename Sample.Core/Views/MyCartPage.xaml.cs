using System.ComponentModel;
using MvvmCross.Forms.Views;
using Sample.Core.ViewModels;

namespace Sample.Core.Views
{
   public partial class MyCartPage : MvxContentPage<MyCartViewModel>
   {
        public MyCartPage() => InitializeComponent();
   }
}