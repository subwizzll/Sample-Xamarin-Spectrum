using System.Collections.Generic; 
using MvvmCross;
using MvvmCross.Commands;
using Sample.Core.Data;
using Sample.Core.Framework;
using Sample.Core.Framework.Interfaces;
using Sample.Core.Framework.Models;
using Sample.Core.Services;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.ViewModels
{
    public class StoreViewModel : BaseViewModel
    {
        readonly ICartService _cartService;
        public ISortAndFilterModel<Item> SortAndFilterModel { get; set; }
        public IEnumerable<Item> Items => SortAndFilterModel.DisplayItems;
        public Cart Cart => _cartService.Cart;

        public StoreViewModel(ICartService cartService)
        {
            SortAndFilterModel = Mvx.IoCConstruct<SortAndFilterModel<Item>>(Constants.StoreSettings.SortAndFilterArguments);
            SortAndFilterModel.PropertyChanged += async (_, _) => await RaisePropertyChanged(nameof(Items));
            _cartService = cartService;
        }

        IMvxAsyncCommand _myCartCommand;
        public IMvxAsyncCommand MyCartCommand => _myCartCommand ??= new MvxAsyncCommand(async () 
            => await _navigationService.Navigate<MyCartViewModel>());

        IMvxAsyncCommand _sortAndFilterItemsCommand;
        public IMvxAsyncCommand SortAndFilterItemsCommand => _sortAndFilterItemsCommand ??= new MvxAsyncCommand(async ()
            => await SortAndFilterModel.SortAndFilterItems());

        IMvxAsyncCommand<SelectableItemsView> _itemSelectedCommand;
        public IMvxAsyncCommand<SelectableItemsView> ItemSelectedCommand => _itemSelectedCommand 
            ??= new MvxAsyncCommand<SelectableItemsView>(async parameter =>
        {
            if (parameter != null)
                await _navigationService.Navigate<StoreItemDetailViewModel, Item>(parameter.SelectedItem as Item);
            parameter.SelectedItem = null;
        });

        IMvxAsyncCommand<LineItemDetail> _addToCartCommand;
        public IMvxAsyncCommand<LineItemDetail> AddToCartCommand => _addToCartCommand 
            ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            if (!parameter.Quantity.IsPositive())
                return;
            await _cartService.AddItems(parameter);
        });
    }
}
