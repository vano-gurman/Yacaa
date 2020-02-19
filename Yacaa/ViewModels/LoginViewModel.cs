using System;
using System.Security;
using Stylet;
using Yacaa.Services.Settings;
using Yacaa.Shared.Encryption;
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
            _settingsService.Load();
            Refresh();
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