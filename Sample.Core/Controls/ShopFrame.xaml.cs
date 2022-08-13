using System;
using MvvmCross.Commands;
using MvvmCross.Core;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class ShopFrame : BaseFrame
    {
        public ShopFrame() => InitializeComponent();

        public string QuantityLabel => this[nameof(QuantityLabel)];
        public string AddToCart => this[nameof(AddToCart)];
            
        public Item Item
        {
            get => (Item)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public static readonly BindableProperty ItemProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Item),
            returnType: typeof(Item),
            declaringType: typeof(ShopFrame),
            defaultValue: null,
            propertyChanged: (b, o, n) =>
            {
                var shopFrame = b as ShopFrame;
                shopFrame.AddToCartCommandParameter.Item = shopFrame.Item;
                shopFrame.AddToCartCommandParameter.Quantity = int.Parse(shopFrame.Quantity);
            });

        public string Quantity
        {
            get => (string)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public static readonly BindableProperty QuantityProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Quantity),
            returnType: typeof(string),
            declaringType: typeof(ShopFrame),
            defaultValue: "1",
            propertyChanged: (b, o, n) =>
            {
                var shopFrame = b as ShopFrame;
                int.TryParse(n as string, out var newQty);
                shopFrame.AddToCartCommandParameter.Quantity = newQty;
            });

        public IMvxAsyncCommand<LineItemDetail> AddToCartCommand
        {
            get => (IMvxAsyncCommand<LineItemDetail>)GetValue(AddToCartCommandProperty);
            set => SetValue(AddToCartCommandProperty, value);
        }

        public static readonly BindableProperty AddToCartCommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommand),
            returnType: typeof(IMvxAsyncCommand<LineItemDetail>),
            declaringType: typeof(ShopFrame),
            defaultValue: null);

        public LineItemDetail AddToCartCommandParameter
        {
            get => (LineItemDetail)GetValue(AddToCartCommandParameterProperty);
            set => SetValue(AddToCartCommandParameterProperty, value);
        }

        public readonly BindableProperty AddToCartCommandParameterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommandParameter),
            returnType: typeof(LineItemDetail),
            declaringType: typeof(ShopFrame),
            defaultValue: new LineItemDetail());
    }
}