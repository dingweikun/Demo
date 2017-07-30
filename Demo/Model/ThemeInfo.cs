using MahApps.Metro;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

namespace Demo.Model
{
    public struct ThemeInfo
    {
        public string StringKey { get; private set; }
        public AppTheme Theme { get; private set; }

        public static readonly IReadOnlyList<ThemeInfo> Themes = new List<ThemeInfo>()
        {
            new ThemeInfo{StringKey="String_LightTheme",Theme=ThemeManager.GetAppTheme("BaseLight")},
            new ThemeInfo{StringKey="String_DarkTheme",Theme=ThemeManager.GetAppTheme("BaseDark")}
        };

        public static ThemeInfo FindTheme(AppTheme theme)
        {
            foreach (var info in Themes)
            {
                if (info.Theme.Name == theme.Name)
                    return info;
            }
            return Themes.First();
        }

        public override string ToString()
        {
            return LocalizeDictionary.Instance.GetLocalizedObject(StringKey, null, LocalizeDictionary.Instance.Culture)?.ToString();
        }
    }
}