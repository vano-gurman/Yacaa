using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Yacaa.Shared.Commands;
using Yacaa.Shared.Navigation;

namespace Yacaa.Shared.ViewModels
{
    public class MenuItemViewModel : BaseViewModel
    {
        private readonly IApplicationCommands _applicationCommands;
        private DelegateCommand<object[]> _selectedCommand;
        public string Label { get; set; } = "Default Menu";
        public ObservableCollection<NavigationItem> NavigationItems { get; set; }
        
        protected MenuItemViewModel(IEventAggregator ea, IApplicationCommands applicationCommands) : base(ea)
        {
            _applicationCommands = applicationCommands;
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
    }
}