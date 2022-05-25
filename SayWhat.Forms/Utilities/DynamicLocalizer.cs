using System;
using System.Diagnostics;
using System.Resources;

namespace SayWhat.Forms.Utilities
{
    internal static class DynamicLocalizer
    {
        private static Lazy<ResourceManager> resMgr = new Lazy<ResourceManager>(() => new ResourceManager($"{SayWhat.Settings.BaseName}.{SayWhat.Settings.Culture.Name}", SayWhat.Settings.ResourceAssembly));
        
        public static string GetText(string text)
        {
            if (text == null)
                return string.Empty;

            try
            {
                var value = resMgr.Value.GetString(text, SayWhat.Settings.Culture) ?? string.Empty;
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return string.Empty;
        }
    }
}
