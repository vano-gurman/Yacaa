using System.Collections.Generic;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Events;
using Yacaa.Shared.Navigation;
using Yacaa.Shared.ViewModels;
using Prism.Commands;
using Yacaa.Shared.Commands;

namespace Yacaa.Modules.Accounting.Menu
{
    public class PartnerInteractionViewModel : BaseViewModel
    {
        private readonly IApplicationCommands _applicationCommands;
        public ObservableCollection<ExpanderItem> ExpanderItems { get; }
        public NavigationItem SelectedItem { get; set; }
        private DelegateCommand<object[]> _selectedCommand;

        public PartnerInteractionViewModel(IEventAggregator ea, IApplicationCommands applicationCommands) : base(ea)
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
                new ExpanderItem(Shared.Strings.Views.PartnerInteraction.Label, new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem(Shared.Strings.Views.PartnerInteraction.Contracts, "Contracts"),
                    new NavigationItem(Shared.Strings.Views.PartnerInteraction.Agreements, "Agreements"),
                    new NavigationItem(Shared.Strings.Views.PartnerInteraction.RequestAdmission, "RequestAdmission"),
                    new NavigationItem(Shared.Strings.Views.PartnerInteraction.RequestRelocation, "RequestRelocation"),
                    new NavigationItem(Shared.Strings.Views.PartnerInteraction.RequestShipment, "RequestShipment"),
                })
            };
        }
    }
}