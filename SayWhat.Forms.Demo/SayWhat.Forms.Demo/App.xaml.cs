using Xamarin.Forms;
using System.Reflection;

namespace SayWhat.Forms.Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Initialization
            Utilities.SayWhat.Settings.Initialize(Assembly.GetAssembly(typeof(MainPage)), "en-US");

            MainPage = new MainPage();
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
