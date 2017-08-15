using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace M1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Assembly ass = Assembly.LoadFrom("C1.exe");
            Type t = ass.GetType("C1.CC1");
            var c1 = t.Assembly.CreateInstance(t.FullName) as UserControl;
            tab_item.Content = c1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string olds = LocalizeDictionary.Instance.Culture.ToString();
            LocalizeDictionary.Instance.Culture = new System.Globalization.CultureInfo("zh");
            string news = LocalizeDictionary.Instance.Culture.ToString();

            MessageBox.Show(olds + " ||| " + news);
        }
    }
}
