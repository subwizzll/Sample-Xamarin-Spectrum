using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Sample.Core.Framework.Interfaces;
using Sample.Core.Framework.Models;
using Sample.Core.ViewModels;

namespace Sample.Core
{
    public class AppStart : MvxApplication
    {
        public override void Initialize()
        {
            // Register Service Types
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            // Register Generic Types
            Mvx.IoCProvider.RegisterType(typeof(ISortAndFilterModel<>), typeof(SortAndFilterModel<>));
            
            RegisterAppStart<StoreViewModel>();
        }
    }
}
