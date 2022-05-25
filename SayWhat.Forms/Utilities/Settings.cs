using SayWhat.Messages;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace SayWhat.Forms.Utilities
{
    public static class SayWhat
    {
       private static Lazy<Settings> _settingsInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Settings
        {
            get; set; 
        }
    }
    public sealed class Settings
    {
        public  CultureInfo Culture { get; private set; }

        internal string BaseName { get; set; }
        internal Assembly ResourceAssembly { get; set; }

        internal Settings() { }

        public void Initialize(string basename, Assembly resourceAssembly, string cultureKey = "en-US")
        {
            BaseName = basename;
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