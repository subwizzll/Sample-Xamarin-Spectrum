using MvvmCross;
using MvvmCross.Commands;
using System.Linq;
using System.Windows.Input;
using Sample.Core.Framework.Effects;
using Sample.Core.Services;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class NavBar
    {
        readonly ITextProviderService _textProvider = Mvx.IoCProvider.Resolve<ITextProviderService>();
        
        public NavBar()
        {
            InitializeComponent();
            CornerRadius = 0;
            Padding = new Thickness{ Left = 12, Right = 12 };
            SafeAreaInsetEffect.SetInsetType(this, InsetType.Top);
            SetSafeAreaInsetEffect(SafeAreaInsetEffectEnabled);
        }

        public string this[string index] => GetText(GetType().Name, index);

        string GetText(string model, string key) => _textProvider.GetText(model, key);

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            child.BindingContext = this;
        }

        public bool SafeAreaInsetEffectEnabled
        {
            get => (bool)GetValue(SafeAreaInsetEffectEnabledProperty);
            set => SetValue(SafeAreaInsetEffectEnabledProperty, value);
        }

        public static readonly BindableProperty SafeAreaInsetEffectEnabledProperty = BindableProperty.Create(
            propertyName: nameof(SafeAreaInsetEffectEnabled),
            returnType: typeof(bool),
            declaringType: typeof(NavBar),
            defaultValue: true,
            propertyChanged: (b, o, n) =>
            {
                var navBar = b as NavBar;
                var isEnabled = (bool)n;
                navBar.SetSafeAreaInsetEffect(isEnabled);
            });

        void SetSafeAreaInsetEffect(bool isEnabled)
        {
            if (isEnabled)
                Effects.Add(new SafeAreaInsetEffect());
            else
                Effects.Remove(Effects.First(x => x.GetType() == typeof(SafeAreaInsetEffect)));
        }

        public ImageSource NavigationIcon
        {
            get => (ImageSource)GetValue(NavigationIconProperty);
            set => SetValue(NavigationIconProperty, value);
        }

        public static readonly BindableProperty NavigationIconProperty = BindableProperty.Create(
          propertyName: nameof(NavigationIcon),
          returnType: typeof(ImageSource),
          declaringType: typeof(NavBar),
          defaultValue: null);

        public NavigationType NavigationState
        {
            get => (NavigationType)GetValue(NavigationStateProperty);
            set => SetValue(NavigationStateProperty, value);
        }

        public static readonly BindableProperty NavigationStateProperty = BindableProperty.Create(
          propertyName: nameof(NavigationState),
          returnType: typeof(NavigationType),
          declaringType: typeof(NavBar),
          defaultValue: NavigationType.None,
          propertyChanged: (b, o, n) =>
          {
              var navBar = (NavBar)b; 
              switch ((NavigationType)n)
              {
                  case NavigationType.Back:
                      navBar.NavigationIcon = "LeftArrow";
                      break;
                  case NavigationType.Close:
                      navBar.NavigationIcon = "CloseCross";
                      break;
              }
           });

        public IMvxAsyncCommand NavigationCommand
        {
            get => (IMvxAsyncCommand)GetValue(NavigationCommandProperty);
            set => SetValue(NavigationCommandProperty, value);
        }

        public static readonly BindableProperty NavigationCommandProperty = BindableProperty.Create(
            propertyName: nameof(NavigationCommand),
            returnType: typeof(IMvxAsyncCommand),
            declaringType: typeof(NavBar));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(NavBar),
            defaultValue: string.Empty);

        public ImageSource QuickActionIcon
        {
            get => (ImageSource)GetValue(QuickActionIconProperty);
            set => SetValue(QuickActionIconProperty, value);
        }

        public static readonly BindableProperty QuickActionIconProperty = BindableProperty.Create(
            propertyName: nameof(QuickActionIcon),
            returnType: typeof(ImageSource),
            declaringType: typeof(NavBar),
            defaultValue: null);

        public QuickActionType QuickActionState
        {
            get => (QuickActionType)GetValue(QuickActionStateProperty);
            set => SetValue(QuickActionStateProperty, value);
        }

        public static readonly BindableProperty QuickActionStateProperty = BindableProperty.Create(
            propertyName: nameof(QuickActionState),
            returnType: typeof(QuickActionType),
            declaringType: typeof(NavBar),
            defaultValue: QuickActionType.None,
            propertyChanged: (b, o, n) =>
            {
                var navBar = (NavBar)b; 
                switch ((QuickActionType)n)
                {
                    case QuickActionType.Info:
                        navBar.QuickActionIcon = "InfoIcon";
                        break;
                    case QuickActionType.Shop:
                        navBar.QuickActionIcon = "ShoppingCartIcon";
                        break;
                }
            });

        public ICommand QuickActionCommand
        {
            get => (ICommand)GetValue(QuickActionCommandProperty);
            set => SetValue(QuickActionCommandProperty, value);
        }

        public static readonly BindableProperty QuickActionCommandProperty = BindableProperty.Create(
            propertyName: nameof(QuickActionCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(NavBar),
            defaultValue: null);

        public bool IsQuickActionVisible
        {
            get => (bool)GetValue(IsQuickActionVisibleProperty);
            set => SetValue(IsQuickActionVisibleProperty, value);
        }

        public static readonly BindableProperty IsQuickActionVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsQuickActionVisible),
            returnType: typeof(bool),
            declaringType: typeof(NavBar),
            defaultValue: true);

        public string QuickActionLabel
        {
            get => (string)GetValue(QuickActionLabelProperty);
            set => SetValue(QuickActionLabelProperty, value);
        }

        public static readonly BindableProperty QuickActionLabelProperty = BindableProperty.Create(
            propertyName: nameof(QuickActionLabel),
            returnType: typeof(string),
            declaringType: typeof(NavBar),
            defaultValue: string.Empty,
            propertyChanged: (b, o, n) =>
            {
                var navBar = b as NavBar;
                var newString = n as string;
                if (newString.Length >= 3 && navBar.QuickActionState == QuickActionType.Shop)
                    navBar.QuickActionLabel = navBar["OverOneHundred"];
            });

        public enum NavigationType
        {
            None,
            Back,
            Close
        }

        public enum QuickActionType
        {
            None,
            Info,
            Shop
        }
    }
}