using Demo.Manager;
using GalaSoft.MvvmLight;
using MahApps.Metro;
using System.Collections.Generic;
using System.Windows;

namespace Demo.ViewModel
{
    public class AppearenceViewViewModel : ViewModelBase
    {
        private App App => Application.Current as App;

        public IEnumerable<Accent> AllAccents => ThemeManager.Accents;

        public IEnumerable<string> AllLanguages => LanguageManager.Languages;

        public Accent CurrentAccent
        {
            get => App.CurrentAccent;
            set
            {
                App.CurrentAccent = value;
                RaisePropertyChanged(nameof(CurrentAccent));
            }
        }

        public bool IsDarkTheme
        {
            get => ThemeManager.GetAppTheme("BaseDark") == App.CurrentTheme;
            set
            {
                App.CurrentTheme = value ?
                    ThemeManager.GetAppTheme("BaseDark") :
                    ThemeManager.GetAppTheme("BaseLight");
            }

        }

        public string CurrentLanguage
        {
            get => LanguageManager.GetLanguage(App.CurrentCulture);
            set
            {
                App.CurrentCulture = LanguageManager.GetCulture(value);
                RaisePropertyChanged(nameof(CurrentLanguage));
            }
        }

    }
}