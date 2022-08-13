using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sample.Core.Framework
{
    public class TextResourceAssembler
    {
        public Dictionary<string, Dictionary<string, string>> GetResources()
        {
            var resources = new Dictionary<string, Dictionary<string, string>>();

            var assemblies = new Assembly[]
            {
                typeof(Sample.Core.FormsApp).Assembly,
                Assembly.GetExecutingAssembly()
            };

            foreach (var assembly in assemblies)
            {
                var res = GetAllResourceFiles(assembly);
                var processed = GetTextFromEmbeddedResource(assembly, res);
                foreach (var item in processed)
                {
                    if (resources.TryGetValue(item.Key, out var currentResource))
                    {
                        foreach (var text in item.Value)
                        {
                            if (currentResource.ContainsKey(text.Key))
                                currentResource[text.Key] = text.Value;
                            else
                                currentResource.Add(text.Key, text.Value);
                        }
                    }
                    else
                        resources.Add(item.Key, item.Value);
                }
            }

            return resources;
        }

        string[] GetAllResourceFiles(Assembly executingAssembly)
        {
            var folderName = string.Format("{0}.Resources", executingAssembly.GetName().Name);
            return executingAssembly
                .GetManifestResourceNames()
                .Where(r => r.StartsWith(folderName) && r.EndsWith(".json"))
                .ToArray();
        }

        Dictionary<string, Dictionary<string, string>> GetTextFromEmbeddedResource(Assembly assembly, string[] resources)
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            foreach (var resource in resources)
            {
                var filename = resource.Substring(0, resource.LastIndexOf('.'));
                filename = filename.Substring(filename.LastIndexOf('.') + 1);

                using (Stream stream = assembly.GetManifestResourceStream(resource))
                using (var textReader = new StreamReader(stream))
                {
                    dictionary.Add(filename, JsonConvert.DeserializeObject<Dictionary<string, string>>(textReader.ReadToEnd()));
                }
            }

            return dictionary;
        }
    }
}