using MahApps.Metro;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Demo.Model
{
    public struct LanguageInfo
    {
        public string Name { get; private set; }
        public CultureInfo Culture { get; private set; }

        public static readonly IReadOnlyList<LanguageInfo> Languages = new List<LanguageInfo>()
        {
            new LanguageInfo{Name="English",Culture=new CultureInfo("en")},
            new LanguageInfo{Name="简体中文",Culture=new CultureInfo("zh-CN")}
        };

        public static LanguageInfo FindLanguage(CultureInfo culture)
        {
            foreach (var info in Languages)
            {
                if (info.Culture.Name == culture.Name)
                    return info;
            }
            return Languages.First();
        }

        public override string ToString() => Name;
    }

}
