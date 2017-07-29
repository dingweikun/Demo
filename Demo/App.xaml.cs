using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Demo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MessageBox.Show($"App argu num: {e.Args.Count()}");
            base.OnStartup(e);

            Exit += App_Exit;

        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App Shut Down !");
        }
    }
}
