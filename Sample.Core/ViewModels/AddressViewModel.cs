using System.Threading.Tasks;
using MvvmCross.Commands;
using Sample.Core.Models.TaxCalcStore;
using Sample.Core.Services;

namespace Sample.Core.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        readonly ICartService _cartService;
        public AddressViewModel(ICartService cartService)
            => _cartService = cartService;

        AddressType _addressType;
        public AddressType AddressType
        {
            get => _addressType;
            set
            { 
                SetProperty(ref _addressType, value);
                RefreshCurrentAddress(_addressType);
            }
        }

        async Task RefreshCurrentAddress(AddressType addressType)
            => CurrentAddress = await _cartService.GetAddress(addressType);

        Address _currentAddress;
        public Address CurrentAddress
        {
            get => _currentAddress;
            set
            { 
                SetProperty(ref _currentAddress, value);
                CopyAddress(_currentAddress);
                RaisePropertyChanged(nameof(EditAddress));
            }
        }

        void CopyAddress(Address copiedAddress)
        {
            EditAddress.City = copiedAddress.City;
            EditAddress.State = copiedAddress.State;
            EditAddress.Zip = copiedAddress.Zip;
            EditAddress.Country = copiedAddress.Country;
        }

        Address _editAddress = new();
        public Address EditAddress
        {
            get => _editAddress;
            set => SetProperty(ref _editAddress, value);
        }
        
        bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                SetProperty(ref _isEditMode, value);
                RaisePropertyChanged(nameof(CurrentAddress));
                RaisePropertyChanged(nameof(EditAddress));
                RaisePropertyChanged(nameof(FormattedAddress));
                RaisePropertyChanged(nameof(EditAddressButton));
            }
        }
        
        public string AddressTypeLabel 
            => CurrentAddress?.Type is AddressType.To 
                ? this["SendLabel"] 
                : this["ShipLabel"];
        
        public string FormattedAddress 
            => string.Format(this["AddressFormat"], 
                CurrentAddress?.City,
                CurrentAddress?.State,
                CurrentAddress?.Zip,
                CurrentAddress?.Country);
        
        public string EditAddressButton 
            => !IsEditMode 
                ? this["ChangeLabel"] 
                : this["CancelLabel"];
        
        public string CityLabel => this[nameof(CityLabel)];
        public string StateLabel => this[nameof(StateLabel)];
        public string ZipLabel => this[nameof(ZipLabel)];
        public string CountryLabel => this[nameof(CountryLabel)];
        public string SaveButton => this[nameof(SaveButton)];
        
        IMvxAsyncCommand _editAddressCommand;
        public IMvxAsyncCommand EditAddressCommand => _editAddressCommand ??= new MvxAsyncCommand(async () =>
        {
            if (IsEditMode)
                await RefreshCurrentAddress(AddressType);
            IsEditMode = !IsEditMode;
        });
        
        IMvxAsyncCommand _saveAddressCommand;
        public IMvxAsyncCommand SaveAddressCommand => _saveAddressCommand ??= new MvxAsyncCommand(async () =>
        {
            await _cartService.SetAddress(AddressType, EditAddress);
            await RefreshCurrentAddress(AddressType);
            IsEditMode = !IsEditMode;
        });
    }
}