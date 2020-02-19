using Stylet;
using Yacaa.Events;

namespace Yacaa.ViewModels.Content.PartnerInteraction
{
    public class ContractsViewModel : BaseContentViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public ContractsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            DisplayName = Strings.Views.PartnerInteraction.Contracts;
        }

        public void SendMessage()
        {
            _eventAggregator.Publish(new SnackbarMessageEvent("Button Pressed"));
        }
    }
}