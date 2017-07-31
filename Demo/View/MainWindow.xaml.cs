using MahApps.Metro.Controls;
using System;
using System.Threading;
using System.Windows;

namespace Demo.View
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.SplashWindow is Window sw)
            {

                //模拟主窗体处理加载消耗的时间
                Thread.Sleep(3000);
                sw.Dispatcher.Invoke((Action)(() => sw.Close()));
                //SplashWindow sw = App.Dic["SplashWindow"] as SplashWindow;
                //    sw.Dispatcher.Invoke((Action)(() => sw.Close()));//在sw的线程上关闭SplashWindow
                //}
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //var w = new MainWindow();
            //w.Owner = this;
            //w.Show();
        }
    }
}
