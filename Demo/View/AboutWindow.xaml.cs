using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Documents;

namespace Demo.View
{
    /// <summary>
    /// AboutWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWindow : MetroWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            Hyperlink link = new Hyperlink();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Hyperlink link)
            {
                System.Diagnostics.Process.Start(link.NavigateUri.ToString());
            }
        }
    }
}
