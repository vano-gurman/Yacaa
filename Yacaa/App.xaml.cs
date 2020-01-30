using Yacaa.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using System.Windows.Controls;
using Prism.Mvvm;
using Prism.Regions;
using Yacaa.Modules.Accounting;
using Yacaa.Modules.Analytics;
using Yacaa.Modules.Login;
using Yacaa.RegionAdapters;
using Yacaa.Shared.Commands;
using Yacaa.ViewModels;

namespace Yacaa
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }
        
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AccountingModule>();
            moduleCatalog.AddModule<AnalyticsModule>();
            moduleCatalog.AddModule<LoginModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackpanelRegionAdapter>());
        }
    }
}
