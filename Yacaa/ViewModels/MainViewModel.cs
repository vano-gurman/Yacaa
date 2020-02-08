using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Stylet;
using StyletIoC;
using Yacaa.Events;
using Yacaa.Interfaces.Factories;
using Yacaa.Interfaces.ViewModels;
using Yacaa.Models.MVVM;
using Yacaa.Strings.Views;
using Yacaa.ViewModels.Content;
using Yacaa.Views;

namespace Yacaa.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<SnackbarMessageEvent>
    {
        public string Title { get; set; } = "Yacaa";
        public SnackbarMessageQueue SnackQueue { get; set; }
        public bool IsMenuOpen { get; set; }
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public IContentViewModel SelectedItem { get; set; }

        private readonly IEventAggregator _eventAggregator;
        private IContentViewModelFactory _contentViewModelFactory;

        public MainViewModel(IEventAggregator eventAggregator, IContentViewModelFactory contentViewModelFactory, HomeViewModel homeViewModel)
        {
            _eventAggregator = eventAggregator;
            _contentViewModelFactory = contentViewModelFactory;
            _eventAggregator.Subscribe(this);
            ActivateItem(homeViewModel);
            PopulateMenu();
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
            Title = SelectedItem.DisplayName;
            SelectedItem.ConductWith(this);
            ActiveItem.RequestClose();
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
                new MenuItem(PartnerInteraction.Label, new ObservableCollection<IContentViewModel>(partnerInteraction)),
                new MenuItem(Sales.Label, new ObservableCollection<IContentViewModel>(sales))
            };
            
            Items.AddRange(partnerInteraction);
            Items.AddRange(sales);
        }
        
        #endregion

        public void Handle(SnackbarMessageEvent message)
        {
            SnackQueue.Enqueue(message);
        }
        
        
    }
}