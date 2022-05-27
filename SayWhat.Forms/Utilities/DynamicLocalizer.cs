using System;
using System.Diagnostics;
using System.Resources;

namespace SayWhat.Forms.Utilities
{
    internal static class DynamicLocalizer
    {
        private static bool _throwExceptions = true;
        private static Lazy<ResourceManager> _resMgr;
        
        public static string GetText(string text)
        {
            if (text == null)
                return string.Empty;

            try
            {
                var value = _resMgr.Value.GetString(text, SayWhat.Settings.Culture) ?? string.Empty;
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);

#if RELEASE
                _throwExceptions = SayWhat.Settings.AlwaysThrowExceptions;
#endif
                if (_throwExceptions)
                {
                    throw e;
                }
            }

            return string.Empty;
        }

        internal static void CreateResourceManager(ResourceManager resourceManager)
        {
            _resMgr = new Lazy<ResourceManager>(() => resourceManager);
        }
    }
}
