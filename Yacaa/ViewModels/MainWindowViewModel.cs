using Prism.Commands;
using System;
using Prism.Events;
using Prism.Regions;
using Yacaa.Shared.Commands;
using Yacaa.Shared.Interfaces;
using Yacaa.Shared.Strings;
using Yacaa.Shared.ViewModels;

namespace Yacaa.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;
        public bool IsMenuOpen { get; set; }
        private DelegateCommand<string> _navigateCommand;

        protected MainWindowViewModel(IEventAggregator ea, IRegionManager regionManager, IApplicationCommands applicationCommands) : base(ea)
        {
            _regionManager = regionManager;
            applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }
        
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigateCommand);

        private void ExecuteNavigateCommand(string path)
        {
            IsMenuOpen = false;
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException();

            _regionManager.RequestNavigate(RegionNames.Content, path);
        }
        
    }
}
