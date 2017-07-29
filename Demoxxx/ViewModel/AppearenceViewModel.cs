using Demo.Model;
using GalaSoft.MvvmLight;
using MahApps.Metro;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace Demo.ViewModel
{
    public class AppearenceViewModel : ViewModelBase
    {
        public IEnumerable<Accent> Accents { get; }
        public IEnumerable<ThemeInfo> Themes { get; }
        public IEnumerable<LanguageInfo> Languages { get; }



        public Accent CurrentAccent
        {
            get => ThemeManager.DetectAppStyle(Application.Current).Item2 as Accent;
            set
            {
                var CurrentTheme = ThemeManager.DetectAppStyle(Application.Current).Item1 as AppTheme;
                ThemeManager.ChangeAppStyle(Application.Current, value, CurrentTheme);
                RaisePropertyChanged(nameof(CurrentAccent));
            }
        }

        public ThemeInfo CurrentTheme
        {
            get => ThemeInfo.FindTheme(ThemeManager.DetectAppStyle(Application.Current).Item1 as AppTheme);
            set
            {
                var CurrentAccent = ThemeManager.DetectAppStyle(Application.Current).Item2 as Accent;
                ThemeManager.ChangeAppStyle(Application.Current, CurrentAccent, value.Theme);
                RaisePropertyChanged(nameof(CurrentTheme));
            }
        }


        public LanguageInfo CurrentLanguage
        {
            get => LanguageInfo.FindLanguage(LocalizeDictionary.Instance.Culture);
            set
            {
                LocalizeDictionary.Instance.Culture = value.Culture;
                RaisePropertyChanged(nameof(CurrentLanguage));
            }
        }


        public AppearenceViewModel()
        {
            Accents = ThemeManager.Accents;
            Themes = ThemeInfo.Themes;
            Languages = LanguageInfo.Languages;
        }



    }
}