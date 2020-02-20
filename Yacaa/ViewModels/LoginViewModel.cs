using System;
using System.Security;
using MaterialDesignThemes.Wpf;
using Stylet;
using Yacaa.Services.DataAccess;
using Yacaa.Services.DataAccess.Configuration;
using Yacaa.Services.Settings;
using Yacaa.Shared.Encryption;
using Yacaa.ViewModels.Base;
using Yacaa.ViewModels.Dialogs;

namespace Yacaa.ViewModels
{
    public class LoginViewModel : Screen
    {
        public ISnackbarMessageQueue SnackQueue { get; set; }

        #region Private members
        private readonly MainViewModel _mainViewModel;
        private readonly IWindowManager _windowManager;
        private readonly IModelValidator<LoginViewModel> _validator;
        private readonly SettingsService _settingsService;
        private readonly DialogManager _dialogManager;
        private readonly Func<LoginDbDialogViewModel> _loginDbDialogViewModelFactory;
        private readonly DataService _dataService;

        #endregion
        
        #region Public properties
        public string Title { get; set; } = string.Empty;
        public bool IsDatabaseConnectionOpen { get; set; }
        public string Username
        {
            get => _settingsService.UserSettings.Username;
            set => _settingsService.UserSettings.Username = value;
        }
        public SecureString Password
        {
            get => _settingsService.UserSettings.PasswordKey.DecryptString();
            set => _settingsService.UserSettings.PasswordKey = value.EncryptString();
        }
        public bool SaveCredentials
        {
            get => _settingsService.UserSettings.SaveCredentials;
            set => _settingsService.UserSettings.SaveCredentials = value;
        }
        public bool IsDatabaseValidated => _dataService.IsConnectionValidated;
        public bool CanLogin => IsDatabaseValidated;

        #endregion

        public LoginViewModel(
            MainViewModel mainViewModel,
            ISnackbarMessageQueue snackQueue,
            IWindowManager windowManager,
            IModelValidator<LoginViewModel> validator,
            SettingsService settingsService,
            DialogManager dialogManager,
            Func<LoginDbDialogViewModel> loginDbDialogViewModelFactory,
            DataService dataService)
        {
            SnackQueue = snackQueue;
            _mainViewModel = mainViewModel;
            _windowManager = windowManager;
            _validator = validator;
            _settingsService = settingsService;
            _dialogManager = dialogManager;
            _loginDbDialogViewModelFactory = loginDbDialogViewModelFactory;
            _dataService = dataService;
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
            SnackQueue.Enqueue("Hello World");
        }

        public void Login(object parameter)
        {
            if (ValidateUser())
            {
                if (!SaveCredentials)
                    Password = new SecureString();
                _settingsService.Save();
                
                _windowManager.ShowWindow(_mainViewModel);
                this.CloseWindow();
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