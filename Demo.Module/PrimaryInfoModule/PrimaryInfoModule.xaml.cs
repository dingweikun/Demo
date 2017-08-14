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

namespace Demo.Module
{
    /// <summary>
    /// Interaction logic for PrimaryInfoModule.xaml
    /// </summary>
    public partial class PrimaryInfoModule : ProjectModule
    {
        public PrimaryInfoModule()
        {
            InitializeComponent();
        }

        public override string ModuleName => nameof(PrimaryInfoModule);

        public override void UpdateModule() => MessageBox.Show("PrimaryInfoModule Update !");

    }
}
