using DynamicLocalization.Utilities;
using Prism.Navigation;
using Xamarin.Forms;

namespace DynamicLocalization.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        private string _greeting;
        private string _instructions;
        private string _navigate;

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string Greeting
        {
            get => _greeting;
            set => SetProperty(ref _greeting, value, nameof(Greeting));
        }

        public string Instructions
        {
            get => _instructions;
            set => SetProperty(ref _instructions, value, nameof(Instructions));
        }

        public string Navigate
        {
            get => _navigate;
            set => SetProperty(ref _navigate, value, nameof(Navigate));
        }

        public Command UpdateCommand
        {
            get
            {
                return new Command(() => Settings.FlipCulture());
            }
        }

        public Command NavigateToAnotherPageCommand
        {
            get
            {
                return new Command(() => NavigationService.NavigateAsync("AnotherPage", useModalNavigation: true));
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        protected override void UpdateLocalizedItems()
        {
            base.UpdateLocalizedItems();

            //I'd advise using const strings for the parameters, but for my example I'll be a little lazy.
            Greeting = DynamicLocalizer.GetText("Hello");
            Instructions = DynamicLocalizer.GetText("Instructions");
            Navigate = DynamicLocalizer.GetText("Navigate");
        }
    }
}
