using System;
using MvvmCross.Commands;
using Sample.Core.Framework.Models;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class SortAndFilterBar : BaseContentView
    {   
        public SortAndFilterBar() => InitializeComponent();
        
        public string SortLabel => this[nameof(SortLabel)];
        public string FilterLabel => this[nameof(FilterLabel)];
        public string SelectLabel => this[nameof(SelectLabel)];
        public string AscendingLabel => this[nameof(AscendingLabel)];
        public string DescendingLabel => this[nameof(DescendingLabel)];

        public SortOption[] SortOptions
        {
            get => (SortOption[])GetValue(SortOptionsProperty);
            set => SetValue(SortOptionsProperty, value);
        }
        
        public static readonly BindableProperty SortOptionsProperty = BindableProperty.Create(
            propertyName: nameof(SortOptions), 
            returnType: typeof(SortOption[]),
            declaringType: typeof(SortAndFilterBar));

        public object SortSelection
        {
            get => GetValue(SortSelectionProperty);
            set => SetValue(SortSelectionProperty, value);
        }
        
        public static readonly BindableProperty SortSelectionProperty = BindableProperty.Create(
            propertyName: nameof(SortSelection), 
            returnType: typeof(object),
            declaringType: typeof(SortAndFilterBar),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SortAndFilterCriteriaChanged);

        public bool SortAscending
        {
            get => (bool)GetValue(SortAscendingProperty);
            set => SetValue(SortAscendingProperty, value);
        }

        public static readonly BindableProperty SortAscendingProperty = BindableProperty.Create(
            propertyName: nameof(SortAscending),
            returnType: typeof(bool),
            declaringType: typeof(SortAndFilterBar),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: (b, o, n) =>
            {
                var sortAndFilterBar = b as SortAndFilterBar;
                sortAndFilterBar.SortDirectionLabel = sortAndFilterBar.SortAscending
                    ? sortAndFilterBar.AscendingLabel 
                    : sortAndFilterBar.DescendingLabel;
            });
        
        public string SortDirectionLabel
        {
            get => (string)GetValue(SortDirectionLabelProperty);
            set => SetValue(SortDirectionLabelProperty, value);
        }
        
        public static readonly BindableProperty SortDirectionLabelProperty = BindableProperty.Create(
            propertyName: nameof(SortDirectionLabel), 
            returnType: typeof(string),
            declaringType: typeof(SortAndFilterBar),
            defaultValueCreator: b =>
            {
                var sortAndFilterBar = b as SortAndFilterBar;
                return sortAndFilterBar.AscendingLabel;
            },
            propertyChanged: SortAndFilterCriteriaChanged);

        public FilterOption[] FilterOptions
        {
            get => (FilterOption[])GetValue(FilterOptionsProperty);
            set => SetValue(FilterOptionsProperty, value);
        }
        
        public static readonly BindableProperty FilterOptionsProperty = BindableProperty.Create(
            propertyName: nameof(FilterOptions), 
            returnType: typeof(FilterOption[]),
            declaringType: typeof(SortAndFilterBar));

        public object FilterSelection
        {
            get => GetValue(FilterSelectionProperty);
            set => SetValue(FilterSelectionProperty, value);
        }
        
        public static readonly BindableProperty FilterSelectionProperty = BindableProperty.Create(
            propertyName: nameof(FilterSelection), 
            returnType: typeof(object),
            declaringType: typeof(SortAndFilterBar),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SortAndFilterCriteriaChanged);

        public IMvxAsyncCommand SortAndFilterCommand
        {
            get => (IMvxAsyncCommand)GetValue(SortAndFilterCommandProperty);
            set => SetValue(SortAndFilterCommandProperty, value);
        }
        
        public static readonly BindableProperty SortAndFilterCommandProperty = BindableProperty.Create(
            propertyName: nameof(SortAndFilterCommand), 
            returnType: typeof(IMvxAsyncCommand),
            declaringType: typeof(SortAndFilterBar));

        static async void SortAndFilterCriteriaChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;
            var sortAndFilterBar = bindable as SortAndFilterBar;
            if ((bool)sortAndFilterBar.SortAndFilterCommand?.CanExecute())
                await sortAndFilterBar.SortAndFilterCommand?.ExecuteAsync();
        }

        void SortButtonClicked(object sender, EventArgs e) 
            => SortAscending = !SortAscending;
    }
}