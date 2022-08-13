using System.Collections.Generic;
using System.Linq;
using MvvmCross.ViewModels;
using Sample.Core.Framework.Interfaces;

namespace Sample.Core.Framework.Models
{
    public class SortAndFilterModel<T> : MvxNotifyPropertyChanged, ISortAndFilterModel<T>
    {
        public SortAndFilterModel(IEnumerable<T> initialItems,
                                  SortOption[] sortOptions,
                                  FilterOption[] filterOptions)
        {
            OriginalItems = initialItems;
            DisplayItems = OriginalItems;
            SortOptions = sortOptions.Any() 
                ? sortOptions
                : this.InitDefaultSortOptions();
            FilterOptions = filterOptions;
        }

        IEnumerable<T> _originalItems;
        public IEnumerable<T> OriginalItems
        {
            get => _originalItems;
            set => SetProperty(ref _originalItems, value);
        }

        IEnumerable<T> _displayItems;
        public IEnumerable<T> DisplayItems
        {
            get => _displayItems;
            set => SetProperty(ref _displayItems, value);
        }

        SortOption[] _sortOptions;
        public SortOption[] SortOptions
        {
            get => _sortOptions;
            set => SetProperty(ref _sortOptions, value);
        }

        SortOption _sortSelection;
        public SortOption SortSelection
        {
            get => _sortSelection;
            set => SetProperty(ref _sortSelection, value);
        }

        bool _sortAscending = true;
        public bool SortAscending
        {
            get => _sortAscending;
            set => SetProperty(ref _sortAscending, value);
        }

        FilterOption[] _filterOptions;
        public FilterOption[] FilterOptions
        {
            get => _filterOptions;
            set => SetProperty(ref _filterOptions, value);
        }

        FilterOption _filterSelection;
        public FilterOption FilterSelection
        {
            get => _filterSelection;
            set => SetProperty(ref _filterSelection, value);
        }
    }
}