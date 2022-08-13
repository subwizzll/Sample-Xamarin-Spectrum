using System;

namespace Sample.Core.Framework.Attributes.Http
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class BodyAttribute : Attribute
    {
    }
}