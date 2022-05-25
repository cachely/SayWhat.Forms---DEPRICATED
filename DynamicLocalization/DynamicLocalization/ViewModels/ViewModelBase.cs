using DynamicLocalization.Messages;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace DynamicLocalization.ViewModels
{
    internal class ViewModelBase : BindableBase, INavigationAware
    {
        public ViewModelBase(INavigationService navigationService) 
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; set; }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            MessagingCenter.Unsubscribe<object>(Application.Current, CultureChangedMessage.Message);
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            UpdateLocalizedItems();
            MessagingCenter.Subscribe<object>(Application.Current, CultureChangedMessage.Message, (s) => { UpdateLocalizedItems(); });
        }

        protected virtual void UpdateLocalizedItems()
        {
        }
    }
}
