using Xamarin.Forms;
using System.Reflection;
using System.Resources;

namespace SayWhat.Forms.Demo
{
    public partial class App : Application
    {
        public static string CurrentCulture = "en-US";
        
        public App()
        {
            InitializeComponent();

            //Initialization
            var resourceManager = new ResourceManager("SayWhat.Forms.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
            Utilities.SayWhat.Settings.Initialize(resourceManager, CurrentCulture);
            MainPage = new NavigationPage(new MainPage());
        }

        public static void UpdateCulture()
        {
            CurrentCulture = CurrentCulture.Equals("en-US") ? "es-US" : "en-US";
            Utilities.SayWhat.Settings.UpdateCulture(CurrentCulture);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
