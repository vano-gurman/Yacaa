using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Stylet;
using Yacaa.Events;
using Yacaa.Interfaces.Factories;
using Yacaa.Interfaces.ViewModels;
using Yacaa.Service.Settings;
using Yacaa.ViewModels.Content;
using Yacaa.Views;
using MenuItem = Yacaa.Models.MenuItem;

namespace Yacaa.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<SnackbarMessageEvent>
    {
        #region Public properties

        

        #endregion
        
        public string Title { get; set; } = "Yacaa";
        public SnackbarMessageQueue SnackQueue { get; set; } = new SnackbarMessageQueue();
        public bool IsMenuOpen { get; set; }
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public IContentViewModel SelectedItem { get; set; }
        public int SelectedIndex { get; set; } = -1;

        private readonly IContentViewModelFactory _contentViewModelFactory;
        private readonly SettingsService _settingsService;

        public MainViewModel(IEventAggregator eventAggregator,
            IContentViewModelFactory contentViewModelFactory,
            HomeViewModel homeViewModel,
            SettingsService settingsService)
        {
            _contentViewModelFactory = contentViewModelFactory;
            _settingsService = settingsService;
            eventAggregator.Subscribe(this);
            ActivateItem(homeViewModel);
            PopulateMenu();
        }

        protected override void OnInitialActivate()
        {
            _settingsService.Load();
        }

        public sealed override void ActivateItem(IScreen item)
        {
            base.ActivateItem(item);
        }

        protected override void OnViewLoaded()
        {
            //_eventAggregator.Publish(new SnackbarMessageEvent("Welcome to Yacaa"));
        }

        public void Navigate()
        {
            IsMenuOpen = false;
            Title = SelectedItem.DisplayName + Strings.Views.Base.AppPrefix;
            ActivateItem(SelectedItem);
        }
        
        #region WindowControls
        public void WindowClose()
        {
            RequestClose();
        }
        public void WindowToggleState()
        {
            ((MainView) View).WindowState = ((MainView) View).WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }
        public void WindowMinimize()
        {
            ((MainView) View).WindowState = WindowState.Minimized;
        }
        #endregion

        #region Menu Composition

        private void PopulateMenu()
        {
            var partnerInteraction = new List<IContentViewModel>
            {
                _contentViewModelFactory.GetContractsViewModel(),
                _contentViewModelFactory.GetAgreementsViewModel()
            };
            var sales = new List<IContentViewModel>()
            {
                _contentViewModelFactory.GetBunkeringViewModel(),
                _contentViewModelFactory.GetWarehouseSalesViewModel()
            };

            MenuItems = new ObservableCollection<MenuItem>()
            {
                new MenuItem(Strings.Views.PartnerInteraction.Label, new ObservableCollection<IContentViewModel>(partnerInteraction)),
                new MenuItem(Strings.Views.Sales.Label, new ObservableCollection<IContentViewModel>(sales))
            };
            
            //Items.AddRange(partnerInteraction);
            //Items.AddRange(sales);
        }
        
        #endregion

        public void Handle(SnackbarMessageEvent e)
        {
            SnackQueue.Enqueue(e.Message);
        }
    }
}