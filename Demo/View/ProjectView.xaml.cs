using Demo.Model;
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

namespace Demo.View
{
    /// <summary>
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();


            // --------------------------
            
            foreach(var md in ProjectModuleManager.Instance.Modules)
            {
                TabItem item = new TabItem();
                item.Content = md;
                item.Header = md.ModuleName;
                (md as UserControl).Visibility = Visibility.Visible;
                RootTab.Items.Add(item);
            }

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }
    }
}
