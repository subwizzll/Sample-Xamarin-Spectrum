using System.ComponentModel;

namespace Sample.Core.Framework.Enums
{
    public enum FilterCriteria
    {
        [Description("None")]
        None = 0,
        [Description("<")]
        LessThan,
        [Description("<=")]
        LessThanOrEqual,
        [Description("is")]
        Equal,
        [Description("is not")]
        NotEqual,
        [Description(">")]
        GreaterThan,
        [Description(">=")]
        GreaterThanOrEqual
    }
}