using Sample.Core.Models.TaxCalcStore;

namespace Sample.Core.ViewModels
{
    public class StoreItemDetailViewModel : BaseViewModel<Item>
    {
        public override void Prepare(Item parameter) => Item = parameter;

        public string Title => GetText(nameof(Title));
        
        Item _item;
        public Item Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }
    }
}
