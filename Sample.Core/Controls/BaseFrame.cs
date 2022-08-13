using MvvmCross;
using Sample.Core.Services;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public class BaseFrame : Frame
    {
        protected readonly ITextProviderService _textProvider = Mvx.IoCProvider.Resolve<ITextProviderService>();

        public BaseFrame()
        {
            if(!IsSet(CornerRadiusProperty))
                CornerRadius = 0;
        }

        public string this[string index] => GetText(GetType().Name, index);

        string GetText(string model, string key) => _textProvider.GetText(model, key);

        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.CreateAttached(
            propertyName: nameof(BorderWidth),
            returnType: typeof(float),
            declaringType: typeof(BaseFrame),
            defaultValue: 0f);
    }
}
