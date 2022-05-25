using SayWhat.Forms.Messages;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace SayWhat.Forms.Utilities
{
    public static class SayWhat
    {
       private static Lazy<Settings> _settingsInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Settings => _settingsInstance.Value;
    }

    public sealed class Settings
    {
        public  CultureInfo Culture { get; private set; }

        internal Assembly ResourceAssembly { get; set; }

        internal Settings() { }

        public void Initialize(Assembly resourceAssembly, string cultureKey = "en-US")
        {
            ResourceAssembly = resourceAssembly;
            Culture = new CultureInfo(cultureKey);
        }

        public void UpdateCulture(string cultureKey)
        {
            Culture = new CultureInfo(cultureKey);
            MessagingCenter.Send(new object(), CultureChangedMessage.Message);
        }
    }
}