using Lib;
using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_Settings(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        }


        private void Button_Click_open(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();

        }

        private void Button_Click_theme(object sender, RoutedEventArgs e)
        {
            // get the current app style(theme and accent) from the application
        // you can then use the current theme and custom accent instead set a new theme
            Tuple < AppTheme, Accent > appStyle = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Green"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1

            Tuple<AppTheme, Accent> qw = ThemeManager.DetectAppStyle(Application.Current);
        }
    }
}