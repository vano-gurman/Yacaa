using Yacaa.Modules.Accounting.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Yacaa.Modules.Accounting.Menu;
using Yacaa.Modules.Accounting.ViewModels;
using Yacaa.Modules.Accounting.ViewModels.PartnerInteraction;
using Yacaa.Modules.Accounting.ViewModels.Sales;
using Yacaa.Modules.Accounting.Views.PartnerInteraction;
using Yacaa.Modules.Accounting.Views.Sales;
using Yacaa.Shared.Strings;

namespace Yacaa.Modules.Accounting
{
    public class AccountingModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AccountingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.Navigation, typeof(PartnerInteraction));
            _regionManager.RegisterViewWithRegion(RegionNames.Navigation, typeof(Sales));
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<PartnerInteraction, PartnerInteractionViewModel>();
            
            containerRegistry.RegisterForNavigation<Contracts, ContractsViewModel>();
            containerRegistry.RegisterForNavigation<Agreements, AgreementsViewModel>();
            containerRegistry.RegisterForNavigation<RequestAdmission, RequestAdmissionViewModel>();
            containerRegistry.RegisterForNavigation<RequestRelocation, RequestRelocationViewModel>();
            containerRegistry.RegisterForNavigation<RequestShipment, RequestShipmentViewModel>();
            containerRegistry.RegisterForNavigation<Bunkering, BunkeringViewModel>();
            containerRegistry.RegisterForNavigation<WarehouseSales, WarehouseSalesViewModel>();
            
        }
    }
}