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

namespace SmartEnergyDEMO
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
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(this,
                                        ThemeManager.GetAccent("Green"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1
            MessageBox.Show("::");

        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("zh-CN");
        }
    }
}
