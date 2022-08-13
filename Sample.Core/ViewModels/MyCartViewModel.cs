using System.Linq;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using Sample.Core.Services;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.ViewModels
{
    public class MyCartViewModel : BaseViewModel
    {
        readonly ICartService _cartService;

        public Cart Cart => _cartService.Cart;
        public AddressViewModel ToAddressViewModel { get; set; }
        public AddressViewModel FromAddressViewModel { get; set; }
        
        public string EmptyCartLabel => this[nameof(EmptyCartLabel)];
        public string CheckoutButton 
            => string.Format(this[nameof(CheckoutButton)], Cart.Items.Count);

        public bool ShowAddressView => Cart.Items.Count > 0;

        public MyCartViewModel(ICartService cartService)
        {
            _cartService = cartService;
            ToAddressViewModel = new(_cartService)
            {
                AddressType = AddressType.To, 
                CurrentAddress = _cartService.Cart.ToAddress
            };
            FromAddressViewModel = new(_cartService)
            {
                AddressType = AddressType.From,
                CurrentAddress = _cartService.Cart.FromAddress
            };
        }

        IMvxAsyncCommand _checkoutCommand;
        public IMvxAsyncCommand CheckoutCommand => _checkoutCommand ??= new MvxAsyncCommand(async ()
            => await _navigationService.Navigate<CheckoutViewModel>());

        IMvxAsyncCommand<LineItemDetail> _updateCartCommand;
        public IMvxAsyncCommand<LineItemDetail> UpdateCartCommand => _updateCartCommand ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            await _cartService.UpdateItems(parameter);
            await RefreshCartPage();
        });
        
        IMvxAsyncCommand<LineItemDetail> _removeFromCartCommand;
        public IMvxAsyncCommand<LineItemDetail> RemoveFromCartCommand => _removeFromCartCommand ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            await _cartService.RemoveItems(parameter);
            await RefreshCartPage();
        });

        async Task RefreshCartPage()
        {
            await RaisePropertyChanged(nameof(ShowAddressView));
            await RaisePropertyChanged(nameof(CheckoutButton));
        }
    }
    
    public class MyCartTemplateSelector : DataTemplateSelector
    {
        readonly ICartService _cartService = Mvx.IoCProvider.Resolve<ICartService>();
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate LastItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate (object item, BindableObject container)
        {
            var lastItem = _cartService.Cart.LineItems.LastOrDefault();
            return lastItem.Equals(item) ? LastItemTemplate : NormalTemplate;
        }
    }
}