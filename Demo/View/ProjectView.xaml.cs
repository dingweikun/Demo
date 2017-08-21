using Demo.Manager;
using Demo.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

           // ProjectModuleManager.ReloadModules();

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

            var vv = new View.ProjectModuleSelectWindow()
            {
                Owner = Helper.Helper.FindParentWindow(this)
            };

            var mm = vv.DataContext as ProjectModuleSelectWindowViewModel;
            mm.SelectedCategory = Module.ProjectModuleCategory.Demand;

            vv.ShowDialog();






        }
    }
}
