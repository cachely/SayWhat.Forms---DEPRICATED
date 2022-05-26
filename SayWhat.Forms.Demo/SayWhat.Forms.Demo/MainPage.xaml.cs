using SayWhat.Forms.Controls;
using Xamarin.Forms;

namespace SayWhat.Forms.Demo
{
    public partial class MainPage : LocalizedContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            App.UpdateCulture();
        }
    }
}
