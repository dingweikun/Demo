using Demo.Properties;
using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace Demo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {



        public Accent CurrentAccent
        {
            get => ThemeManager.DetectAppStyle(Current).Item2 as Accent;
            set => ThemeManager.ChangeAppStyle(Current, value, CurrentTheme);
        }

        public AppTheme CurrentTheme
        {
            get => ThemeManager.DetectAppStyle(Current).Item1 as AppTheme;
            set => ThemeManager.ChangeAppStyle(Current, CurrentAccent, value);
        }

        public CultureInfo CurrentCulture
        {
            get => LocalizeDictionary.Instance.Culture;
            set => LocalizeDictionary.Instance.Culture = value;
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadApplicationSettings();
            MessageBox.Show($"App argu num: {e.Args.Count()}");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            MessageBox.Show("App Shut Down !");
            UpdateApplicationSettings();
            base.OnExit(e);
        }

        public void LoadApplicationSettings()
        {
            Settings.Default.Reload();
            CurrentAccent = ThemeManager.GetAccent(Settings.Default.Accent);
            CurrentTheme = ThemeManager.GetAppTheme(Settings.Default.Theme);
            CurrentCulture = new CultureInfo(Settings.Default.Culture);
        }

        public void UpdateApplicationSettings()
        {

            Settings.Default.Accent = CurrentAccent.Name;
            Settings.Default.Theme = CurrentTheme.Name;
            Settings.Default.Culture = CurrentCulture.Name;
            Settings.Default.Save();

        }



    }
}
