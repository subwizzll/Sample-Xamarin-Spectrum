using System.Reflection;
using MvvmCross;
using Sample.Core.Services;

namespace Sample.Core.Framework.Models
{
    public class SortOption
    {
        readonly ITextProviderService _textProvider = Mvx.IoCProvider.Resolve<ITextProviderService>();
            
        public SortOption() => Property = default;
        
        public PropertyInfo Property { get; set; }

        public string DisplayString => ToString();

        public override string ToString() 
            => Property != null
                ? $"{Property.Name}"
                : _textProvider.GetText("Shared", "DefaultPickerOptionLabel");
    }
}