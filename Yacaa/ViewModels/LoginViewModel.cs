using System;
using Stylet;

namespace Yacaa.ViewModels
{
    public class LoginViewModel : Screen
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool SaveUser { get; set; }

        private MainViewModel _mainViewModel;
        private IWindowManager _windowManager;
        private IModelValidator<LoginViewModel> _validator;

        public LoginViewModel(MainViewModel mainViewModel, IWindowManager windowManager, IModelValidator<LoginViewModel> validator)
        {
            _mainViewModel = mainViewModel;
            _windowManager = windowManager;
            _validator = validator;

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