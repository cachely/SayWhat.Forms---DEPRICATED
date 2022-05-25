using DynamicLocalization.Utilities;
using Prism.Navigation;
using Xamarin.Forms;

namespace DynamicLocalization.ViewModels
{
    internal class AnotherPageViewModel : ViewModelBase
    {
        private string _dialog;
        private string _goBack;

        public AnotherPageViewModel(INavigationService navigationService) : base (navigationService)
        {
        }

        public string Dialog
        {
            get => _dialog;
            set => SetProperty(ref _dialog, value, nameof(Dialog));
        }

        public string GoBack
        {
            get => _goBack;
            set => SetProperty(ref _goBack, value, nameof(GoBack));
        }

        public Command NavigateBack
        {
            get => new Command(() => NavigationService.GoBackAsync());
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            UpdateLocalizedItems();
        }

        protected override void UpdateLocalizedItems()
        {
            base.UpdateLocalizedItems();
            Dialog = DynamicLocalizer.GetText("Dialog");
            GoBack = DynamicLocalizer.GetText("GoBack");
        }
    }
}
