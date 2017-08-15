using Demo.Module;
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

namespace AAA
{
    /// <summary>
    /// Interaction logic for Mod1.xaml
    /// </summary>
    public partial class Mod1 : ProjectModule
    {
        public Mod1()
        {
            InitializeComponent();
        }

        protected override void IsInEditValueChangedToFalse()
        {
            MessageBox.Show("IsInEditValueChangedToFalse");
        }

        protected override void IsInEditValueChangedToTrue()
        {
            MessageBox.Show("IsInEditValueChangedToTrue");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.IsInEdit.ToString());
        }
    }
}
