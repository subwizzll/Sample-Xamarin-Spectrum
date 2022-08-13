using System.Collections.Generic;
using System.ComponentModel;
using Sample.Core.Framework.Models;

namespace Sample.Core.Framework.Interfaces
{
    public interface ISortAndFilterModel<T>
    {
        IEnumerable<T> OriginalItems { get; set; }
        IEnumerable<T> DisplayItems { get; set; }
        SortOption[] SortOptions { get; }
        SortOption SortSelection { get; set; }
        bool SortAscending { get; set; }
        FilterOption[] FilterOptions { get; set; }
        FilterOption FilterSelection { get; set; }
        event PropertyChangedEventHandler? PropertyChanged;
        event PropertyChangingEventHandler? PropertyChanging;
    }
}