using Demo.Model;
using GalaSoft.MvvmLight;
using MahApps.Metro;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace Demo.ViewModel
{
    public class AppearenceViewViewModel : ViewModelBase
    {
        public IEnumerable<Accent> AllAccents { get; }
        public IEnumerable<ThemeInfo> AllThemes { get; }
        public IEnumerable<LanguageInfo> AllLanguages { get; }


        private App App => Application.Current as App;

        public Accent CurrentAccent
        {
            get => App.CurrentAccent;
            set
            {
                App.CurrentAccent = value;
                RaisePropertyChanged(nameof(CurrentAccent));
            }
            //get => ThemeManager.DetectAppStyle(Application.Current).Item2 as Accent;
            //set
            //{
            //    var CurrentTheme = ThemeManager.DetectAppStyle(Application.Current).Item1 as AppTheme;
            //    ThemeManager.ChangeAppStyle(Application.Current, value, CurrentTheme);
            //    RaisePropertyChanged(nameof(CurrentAccent));
            //}
        }

        public ThemeInfo CurrentTheme
        {
            get => ThemeInfo.FindTheme(App.CurrentTheme);
            set
            {
                App.CurrentTheme = value.Theme;
                RaisePropertyChanged(nameof(CurrentTheme));
            }
            //get => ThemeInfo.FindTheme(ThemeManager.DetectAppStyle(Application.Current).Item1 as AppTheme);
            //set
            //{
            //    var CurrentAccent = ThemeManager.DetectAppStyle(Application.Current).Item2 as Accent;
            //    ThemeManager.ChangeAppStyle(Application.Current, CurrentAccent, value.Theme);
            //    RaisePropertyChanged(nameof(CurrentTheme));
            //}
        }


        public LanguageInfo CurrentLanguage
        {
            get => LanguageInfo.FindLanguage(App.CurrentCulture);
            set
            {
                App.CurrentCulture = value.Culture;
                RaisePropertyChanged(nameof(CurrentLanguage));
            }
            //get => LanguageInfo.FindLanguage(LocalizeDictionary.Instance.Culture);
            //set
            //{
            //    LocalizeDictionary.Instance.Culture = value.Culture;
            //    RaisePropertyChanged(nameof(CurrentLanguage));
            //}
        }


        public AppearenceViewViewModel()
        {
            AllAccents = ThemeManager.Accents;
            AllThemes = ThemeInfo.Themes;
            AllLanguages = LanguageInfo.Languages;
        }



    }
}