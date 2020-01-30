using Yacaa.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Yacaa.Modules.Accounting;
using Yacaa.Modules.Analytics;
using Yacaa.Modules.Login;

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

        }
        
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AccountingModule>();
            moduleCatalog.AddModule<AnalyticsModule>();
            moduleCatalog.AddModule<LoginModule>();
        }
    }
}
