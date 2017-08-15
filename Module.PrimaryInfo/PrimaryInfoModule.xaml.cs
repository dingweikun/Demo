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
using WPFLocalizeExtension.Engine;

namespace Demo.Module.PrimaryInfo
{
    /// <summary>
    /// Interaction logic for PrimaryInfoModule.xaml
    /// </summary>
    [ProjectModule(typeof(PrimaryInfoModule), Category.Information)]
    public partial class PrimaryInfoModule : ProjectModule
    {
        public PrimaryInfoModule()
        {
            InitializeComponent();
        }


        protected override void IsInEditValueChangedToTrue()
        {
        }

        protected override void IsInEditValueChangedToFalse()
        {
        }

        private void ToggleButton_Click2(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(LocalizeDictionary.Instance.Culture.ToString());
        }

        private void ToggleButton_Click1(object sender, RoutedEventArgs e)
        {
            LocalizeDictionary.Instance.Culture = new System.Globalization.CultureInfo("zh-Hans");
        }
    }
}
