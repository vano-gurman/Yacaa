using System.Collections.ObjectModel;
using Prism.Events;
using Yacaa.Shared.Navigation;
using Yacaa.Shared.ViewModels;
using Prism.Commands;
using Yacaa.Modules.Accounting.Views.Sales;
using Yacaa.Shared.Commands;

namespace Yacaa.Modules.Accounting.Menu
{
    public class SalesViewModel : BaseViewModel
    {
        private readonly IApplicationCommands _applicationCommands;
        public ObservableCollection<ExpanderItem> ExpanderItems { get; }
        public NavigationItem SelectedItem { get; set; }
        private DelegateCommand<object[]> _selectedCommand;

        public SalesViewModel(IEventAggregator ea, IApplicationCommands applicationCommands) : base(ea)
        {
            _applicationCommands = applicationCommands;
            ExpanderItems = GenerateItems();
        }
        
        public DelegateCommand<object[]> SelectedCommand =>
            _selectedCommand ??= new DelegateCommand<object[]>(ExecuteSelectedCommand);

        void ExecuteSelectedCommand(object[] o)
        {
            if (o[0] is NavigationItem item)
            {
                _applicationCommands.NavigateCommand.Execute(item.NavigationPath);
            } 
        }

        private static ObservableCollection<ExpanderItem> GenerateItems()
        {
            return new ObservableCollection<ExpanderItem>()
            {
                new ExpanderItem(Shared.Strings.Views.Sales.Label, new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem(Shared.Strings.Views.Sales.Bunkering, nameof(Bunkering)),
                    new NavigationItem(Shared.Strings.Views.Sales.WarehouseSales, nameof(WarehouseSales))
                })
            };
        }
    }
}