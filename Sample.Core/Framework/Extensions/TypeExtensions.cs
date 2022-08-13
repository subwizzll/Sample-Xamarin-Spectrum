using System;
using System.Linq;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static bool HasProperty(this Type type, string propertyName)
            => type.GetProperties().Any(x => x.Name.Equals(propertyName));
    }
}