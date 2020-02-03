using System.Collections.ObjectModel;
using Prism.Events;
using Yacaa.Shared.Navigation;
using Yacaa.Shared.ViewModels;
using Yacaa.Modules.Accounting.Views.PartnerInteraction;
using Yacaa.Shared.Commands;

namespace Yacaa.Modules.Accounting.Menu
{
    public class PartnerInteractionViewModel : MenuItemViewModel
    {

        protected PartnerInteractionViewModel(IEventAggregator ea, IApplicationCommands applicationCommands) : base(ea, applicationCommands)
        {
            Label = Shared.Strings.Views.PartnerInteraction.Label;
            NavigationItems = GenerateItems();
        }
        
        private static ObservableCollection<NavigationItem> GenerateItems()
        {
            return new ObservableCollection<NavigationItem>()
            {
                new NavigationItem(Shared.Strings.Views.PartnerInteraction.Contracts, nameof(Contracts)),
                new NavigationItem(Shared.Strings.Views.PartnerInteraction.Agreements, nameof(Agreements)),
                new NavigationItem(Shared.Strings.Views.PartnerInteraction.RequestAdmission, nameof(RequestAdmission)),
                new NavigationItem(Shared.Strings.Views.PartnerInteraction.RequestRelocation, nameof(RequestRelocation)),
                new NavigationItem(Shared.Strings.Views.PartnerInteraction.RequestShipment, nameof(RequestShipment)),
            };
        }
    }
}