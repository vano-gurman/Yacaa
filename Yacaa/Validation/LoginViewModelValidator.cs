using FluentValidation;
using Yacaa.ViewModels;

namespace Yacaa.Validation
{
    public  class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(vm => vm.Username).NotEmpty().WithMessage("Введите имя пользователя");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Введите пароль");
        }
    }
}