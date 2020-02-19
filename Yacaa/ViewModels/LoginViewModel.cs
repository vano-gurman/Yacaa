using System;
using System.Security;
using MaterialDesignThemes.Wpf;
using Stylet;
using Yacaa.Service.Settings;
using Yacaa.ViewModels.Base;
using Yacaa.ViewModels.Dialogs;

namespace Yacaa.ViewModels
{
    public class LoginViewModel : Screen
    {
        #region Private members
        private readonly MainViewModel _mainViewModel;
        private readonly IWindowManager _windowManager;
        private readonly IModelValidator<LoginViewModel> _validator;
        private readonly SettingsService _settingsService;
        private readonly DialogManager _dialogManager;
        private readonly Func<LoginDbDialogViewModel> _loginDbDialogViewModelFactory;

        #endregion
        
        #region Public properties
        public string Title { get; set; } = string.Empty;
        public string Username { get; set; }
        public SecureString Password { get; set; }
        public bool SaveCredentials { get; set; }

        #endregion

        public LoginViewModel(MainViewModel mainViewModel,
            IWindowManager windowManager,
            IModelValidator<LoginViewModel> validator,
            SettingsService settingsService,
            DialogManager dialogManager,
            Func<LoginDbDialogViewModel> loginDbDialogViewModelFactory)
        {
            _mainViewModel = mainViewModel;
            _windowManager = windowManager;
            _validator = validator;
            _settingsService = settingsService;
            _dialogManager = dialogManager;
            _loginDbDialogViewModelFactory = loginDbDialogViewModelFactory;
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
        }

        public void Login(object parameter)
        {
            if (ValidateUser())
            {
                _windowManager.ShowWindow(_mainViewModel);
                RequestClose();
            }
        }

        public bool ValidateUser()
        {
            return true;
        }

        public void CloseWindow() => RequestClose();
        public async void OpenDialog()
        {
            await _dialogManager.ShowDialogAsync(_loginDbDialogViewModelFactory());
            Console.WriteLine("Sync testing");
            Refresh();
        }
    }
}