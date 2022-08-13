using System.Collections.Generic;
using Sample.Core.Framework;

namespace Sample.Core.Services
{
    public interface ITextProviderService
    {   
        string GetText(string viewModelName, string key);
    }

    public class TextProviderService : ITextProviderService
    {
        readonly TextResourceAssembler _textResourceAssembler = new();
        readonly Dictionary<string, Dictionary<string, string>> _resources;
        
        public TextProviderService() => _resources = _textResourceAssembler.GetResources();

        public string GetText(string viewModelName, string key) => _resources[viewModelName][key];
    }
}
