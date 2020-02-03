using System.Collections.ObjectModel;
using Prism.Events;
using Yacaa.Shared.Navigation;
using Yacaa.Shared.ViewModels;
using Prism.Commands;
using Yacaa.Modules.Accounting.Views.Sales;
using Yacaa.Shared.Commands;

namespace Yacaa.Modules.Accounting.Menu
{
    public class SalesViewModel : MenuItemViewModel
    {
        protected SalesViewModel(IEventAggregator ea, IApplicationCommands applicationCommands) : base(ea, applicationCommands)
        {
            Label = Shared.Strings.Views.Sales.Label;
            NavigationItems = GenerateItems();
        }
        
        private static ObservableCollection<NavigationItem> GenerateItems()
        {
            return new ObservableCollection<NavigationItem>()
            {
                new NavigationItem(Shared.Strings.Views.Sales.Bunkering, nameof(Bunkering)),
                new NavigationItem(Shared.Strings.Views.Sales.WarehouseSales, nameof(WarehouseSales))
            };
        }
    }
}