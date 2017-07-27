using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using WPFLocalizeExtension.Engine;

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

        private void Click_CN(object sender, RoutedEventArgs e)
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("zh-CN");
        }

        private void Click_US(object sender, RoutedEventArgs e)
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("en-US");
        }

        private void Button_Click_Settings(object sender, RoutedEventArgs e)
        {
            MainRootTabControl.SelectedIndex = 1;

        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Theme(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CurrentAccent = ThemeManager.GetAccent("Red");
        }
    }
}
