using System;

namespace Sample.Core.Framework.Attributes.Http
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PostAttribute : HttpAttribute
    {
        public PostAttribute(string endpoint) : base(endpoint)
        {
        }
    }
}