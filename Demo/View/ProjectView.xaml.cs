using Demo.Manager;
using Demo.ViewModel;
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

            //Assembly ass = Assembly.LoadFrom("AAA.dll");
            //var t = ass.GetType("AAA.Mod1");
            //var c = t.Assembly.CreateInstance(t.FullName) as UserControl;
            //TabItem item = new TabItem();
            //item.Header = "Extenal Module";
            //item.Content = c;
            //RootTab.Items.Add(item);


            /*
            foreach(var mod in ProjectModuleManager.Modules)
            {
                System.Diagnostics.Debug.Assert(mod != null);
                TabItem item = new TabItem();
                //item.Header = mod.ModuleTitle;

                // 准备Binding  
                Binding binding = new Binding()
                {
                    Source = mod, // 数据源  
                    Path = new PropertyPath("ModuleTitle"),// 需绑定的数据源属性名  
                    Mode = BindingMode.OneWay,// 绑定模式  
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };

                // 连接数据源与绑定目标  
                BindingOperations.SetBinding(item, TabItem.HeaderProperty, binding);

                // 简写  
                //txt.SetBinding(TextBox.TextProperty, new Binding("Name")  
                //{  
                //    Source = stu,  
                //    Mode = BindingMode.TwoWay  
                //});  
                item.Content = mod;
                RootTab.Items.Add(item);
            }//*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (DataContext is ProjectViewViewModel vm)
            {
                    vm.LoadAllProjectModules();



                /*
                foreach (var mod in vm.ProjectModules)
                {
                    System.Diagnostics.Debug.Assert(mod != null);
                    TabItem item = new TabItem();
                    //item.Header = mod.ModuleTitle;

                    // 准备Binding  
                    Binding binding = new Binding()
                    {
                        Source = mod, // 数据源  
                        Path = new PropertyPath("ModuleTitle"),// 需绑定的数据源属性名  
                        Mode = BindingMode.OneWay,// 绑定模式  
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };

                    // 连接数据源与绑定目标  
                    BindingOperations.SetBinding(item, TabItem.HeaderProperty, binding);

                    // 简写  
                    //txt.SetBinding(TextBox.TextProperty, new Binding("Name")  
                    //{  
                    //    Source = stu,  
                    //    Mode = BindingMode.TwoWay  
                    //});  
                    item.Content = mod;
                    RootTab.Items.Add(item);
                }//*/

                MessageBox.Show(vm.ProjectModules.Count().ToString());


            }

            this.RootTab.SelectedIndex = 0;







        }
    }
}
