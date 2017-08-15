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

            //========================================

            Assembly ass = Assembly.LoadFrom("AAA.dll");
            var t = ass.GetType("AAA.Mod1");
            var c = t.Assembly.CreateInstance(t.FullName) as UserControl;
            TabItem item = new TabItem();
            item.Header = "Extenal Module";
            item.Content = c;
            RootTab.Items.Add(item);

        }
    }
}
