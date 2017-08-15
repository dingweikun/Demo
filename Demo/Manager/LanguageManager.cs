using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Demo.Manager
{
    internal static class LanguageManager
    {
        static Dictionary<string, CultureInfo> dict = new Dictionary<string, System.Globalization.CultureInfo>
        {
            { "English", new CultureInfo("en") },
            { "简体中文", new CultureInfo("zh-Hans") }
        };

        public static IReadOnlyList<string> Languages => dict.Keys.ToList();

        public static CultureInfo GetCulture(string language)
        {
            foreach (var key in dict.Keys)
            {
                if (language == key)
                    return dict[key];
            }
            return dict.First().Value;
        }

        public static string GetLanguage(CultureInfo culture)
        {
            foreach (var key in dict.Keys)
            {
                if (culture.Name == dict[key].Name)
                    return key;
            }
            return dict.First().Key;
        }
    }
}
