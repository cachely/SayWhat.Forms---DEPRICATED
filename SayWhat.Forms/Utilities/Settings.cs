using SayWhat.Forms.Messages;
using System;
using System.Globalization;
using System.Resources;
using Xamarin.Forms;

namespace SayWhat.Forms.Utilities
{
    public static class SayWhat
    {
       private static Lazy<Settings> _settingsInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Settings => _settingsInstance.Value;
    }

    /// <summary>
    /// Class is a singleton, please access through SayWhat.Settings property.
    /// </summary>
    public sealed class Settings
    {
        /// <summary>
        /// Turns on throwing exceptions in Release Configuration.
        /// Otherwise Exceptions are only thrown in Debug Configuration.
        /// </summary>
        public bool AlwaysThrowExceptions { get; set; } = false;

        internal  CultureInfo Culture { get; private set; }

        public void Initialize(ResourceManager resourceManager, string cultureKey = "en-US")
        {
            Culture = new CultureInfo(cultureKey);
            DynamicLocalizer.CreateResourceManager(resourceManager);
        }

        public void UpdateCulture(string cultureKey)
        {
            Culture = new CultureInfo(cultureKey);
            MessagingCenter.Send(new object(), CultureChangedMessage.Message);
        }
    }
}