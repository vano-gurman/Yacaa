using System;
using Stylet;

namespace Yacaa.ViewModels
{
    public class LoginViewModel : Screen
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool SaveUser { get; set; }

        private readonly MainViewModel _mainViewModel;
        private readonly IWindowManager _windowManager;
        private readonly IModelValidator<LoginViewModel> _validator;

        public LoginViewModel(MainViewModel mainViewModel, IWindowManager windowManager, IModelValidator<LoginViewModel> validator)
        {
            this._mainViewModel = mainViewModel;
            this._windowManager = windowManager;
            this._validator = validator;

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

        public void Close()
        {
            RequestClose();
        }
    }
}