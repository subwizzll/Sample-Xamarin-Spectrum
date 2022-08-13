using MvvmCross.Commands;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class CartItemView : BaseContentView
    {
        public CartItemView() => InitializeComponent();
        
        public string PriceLabel => this[nameof(PriceLabel)];
        public string QuantityLabel => this[nameof(QuantityLabel)];
        public string UpdateCart => this[nameof(UpdateCart)];
        public string RemoveFromCart => this[nameof(RemoveFromCart)];
            
        public LineItemDetail ItemDetail
        {
            get => (LineItemDetail)GetValue(ItemDetailProperty);
            set => SetValue(ItemDetailProperty, value);
        }

        public static readonly BindableProperty ItemDetailProperty = BindableProperty.CreateAttached(
            propertyName: nameof(ItemDetail),
            returnType: typeof(LineItemDetail),
            declaringType: typeof(ItemDetailView),
            defaultValue: null,
            propertyChanged: (b, o, n) =>
            {
                var cartItemView = b as CartItemView;
                if (n is not LineItemDetail lineItem)
                    return;
                
                cartItemView.CartCommandParameter.Item = lineItem.Item;
                cartItemView.CartCommandParameter.Quantity = lineItem.Quantity;
                cartItemView.Quantity = lineItem.Quantity.ToString();
                cartItemView.QuantityChanged = false;
            });

        public string Quantity
        {
            get => (string)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public static readonly BindableProperty QuantityProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Quantity),
            returnType: typeof(string),
            declaringType: typeof(CartItemView),
            defaultValue: "1",
            propertyChanged: (b, o, n) =>
            {
                var cartItemView = b as CartItemView;
                var newString = n as string;
                int.TryParse(newString, out var newQty);
                
                if (newQty == cartItemView.ItemDetail.Quantity)
                {
                    cartItemView.QuantityChanged = false;
                    return;
                }
                cartItemView.QuantityChanged = true;
                cartItemView.CartCommandParameter.Quantity = newQty;
            });

        public bool QuantityChanged
        {
            get => (bool)GetValue(QuantityChangedProperty);
            set => SetValue(QuantityChangedProperty, value);
        }

        public static readonly BindableProperty QuantityChangedProperty = BindableProperty.CreateAttached(
            propertyName: nameof(QuantityChanged),
            returnType: typeof(bool),
            declaringType: typeof(CartItemView),
            defaultValue: false);

        public IMvxAsyncCommand<LineItemDetail> UpdateCartCommand
        {
            get => (IMvxAsyncCommand<LineItemDetail>)GetValue(UpdateCartCommandProperty);
            set => SetValue(UpdateCartCommandProperty, value);
        }

        public static readonly BindableProperty UpdateCartCommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(UpdateCartCommand),
            returnType: typeof(IMvxAsyncCommand<LineItemDetail>),
            declaringType: typeof(CartItemView),
            defaultValue: null);

        public IMvxAsyncCommand<LineItemDetail> RemoveFromCartCommand
        {
            get => (IMvxAsyncCommand<LineItemDetail>)GetValue(RemoveFromCartCommandProperty);
            set => SetValue(RemoveFromCartCommandProperty, value);
        }

        public static readonly BindableProperty RemoveFromCartCommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(RemoveFromCartCommand),
            returnType: typeof(IMvxAsyncCommand<LineItemDetail>),
            declaringType: typeof(CartItemView),
            defaultValue: null);

        public LineItemDetail CartCommandParameter
        {
            get => (LineItemDetail)GetValue(CartCommandParameterProperty);
            set => SetValue(CartCommandParameterProperty, value);
        }

        public readonly BindableProperty CartCommandParameterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(CartCommandParameter),
            returnType: typeof(LineItemDetail),
            declaringType: typeof(CartItemView),
            defaultValue: new LineItemDetail());
    }
}