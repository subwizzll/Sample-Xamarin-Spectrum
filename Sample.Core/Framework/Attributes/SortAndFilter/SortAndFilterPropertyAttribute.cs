using System;

namespace Sample.Core.Framework.Attributes.SortAndFilter
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SortAndFilterPropertyAttribute : Attribute
    {
        public bool Sort { get; set; }
        public bool Filter { get; set; }

        public SortAndFilterPropertyAttribute()
        {
            Sort = true;
            Filter = true;
        }

        public SortAndFilterPropertyAttribute(bool sort, bool filter)
        {
            Sort = sort;
            Filter = filter;
        }
    }
}