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

#if DEBUG
            // Splash Window Test
            Loaded += (sender, e) =>
            {
                if ((Application.Current as App)?.SplashWindow is Window sw)
                {
                    // pretend to be busy ;)
                    //Thread.Sleep(2000);
                    sw.Dispatcher.Invoke(() => sw.Close());
                    Activate();
                }
            };
#endif
        }

    }
}
