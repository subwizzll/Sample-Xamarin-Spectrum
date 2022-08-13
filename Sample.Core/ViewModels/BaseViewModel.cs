using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Services;

namespace Sample.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected readonly ILogService _logService = Mvx.IoCProvider.Resolve<ILogService>();
        protected readonly ITextProviderService _textProvider = Mvx.IoCProvider.Resolve<ITextProviderService>();
        protected readonly IMvxNavigationService _navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

        IMvxAsyncCommand _backCommand;
        public virtual IMvxAsyncCommand BackCommand => _backCommand ??= new MvxAsyncCommand(async () =>
        {
            await _navigationService.Close(this);
        });

        public string this[string index] => GetText(GetType().Name, index);

        public string GetText(string key) => GetText(GetType().Name.Replace("`1", string.Empty), key);

        public string GetText(string viewModel, string key) => _textProvider.GetText(viewModel, key);

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public abstract void Prepare(TParameter parameter);
    }

    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModel, IMvxViewModel<TParameter, TResult>
    {
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public abstract void Prepare(TParameter parameter);

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted &&
                !CloseCompletionSource.Task.IsFaulted)
            {
                CloseCompletionSource?.TrySetCanceled();
            }

            base.ViewDestroy(viewFinishing);
        }
    }
    public abstract class BaseViewModelResult<TResult> : BaseViewModel, IMvxViewModelResult<TResult>
    {
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }
        public object Result { get; set; } = default(TResult);

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (CloseCompletionSource?.Task != null
                && !CloseCompletionSource.Task.IsCompleted
                && !CloseCompletionSource.Task.IsFaulted)
            {
                CloseCompletionSource?.TrySetCanceled();
            }

            base.ViewDestroy(viewFinishing);
        }
    }
}
