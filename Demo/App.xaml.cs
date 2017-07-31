using Demo.Properties;
using Demo.View;
using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPFLocalizeExtension.Engine;

namespace Demo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static Window SplashWindow;

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

            //Thread t = new Thread(() =>
            //{
            //    SplashWindow = new SplashWindow();
            //    SplashWindow.ShowDialog(); //不能用Show
            //});
            //t.SetApartmentState(ApartmentState.STA); //设置单线程
            //t.Start();

            SplashWindow = new SplashWindow();
            //4     mCounterWindow.ControlWindow = this;
            SplashWindow.Show();
            SplashWindow.Closed += (s, arg) =>
            SplashWindow.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
            Dispatcher.Run();
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
