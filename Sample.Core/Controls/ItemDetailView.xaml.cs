using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class ItemDetailView : BaseContentView
    {
        public ItemDetailView() => InitializeComponent();
            
        public Item Item
        {
            get => (Item)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public static readonly BindableProperty ItemProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Item),
            returnType: typeof(Item),
            declaringType: typeof(ItemDetailView),
            defaultValue: null);
            
        public double ImageSize
        {
            get => (double)GetValue(ImageSizeProperty);
            set => SetValue(ImageSizeProperty, value);
        }

        public static readonly BindableProperty ImageSizeProperty = BindableProperty.CreateAttached(
            propertyName: nameof(ImageSize),
            returnType: typeof(double),
            declaringType: typeof(ItemDetailView),
            defaultValue: 80d);
    }
}