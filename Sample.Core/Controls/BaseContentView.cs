using MvvmCross;
using Sample.Core.Services;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public class BaseContentView : ContentView
    {
        readonly ITextProviderService _textProvider = Mvx.IoCProvider.Resolve<ITextProviderService>();

        public string this[string index] => GetText(GetType().Name, index);

        string GetText(string model, string key) => _textProvider.GetText(model, key);
    }
}