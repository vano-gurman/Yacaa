using System;
using System.ComponentModel;
using Prism.Regions;
using PropertyChanged;

namespace Yacaa.Shared.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IConfirmNavigationRequest
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DoNotNotify]
        public string Title { get; set; } = "Yacaa";
        
        protected BaseViewModel()
        {
        }
        
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }
    }
}
