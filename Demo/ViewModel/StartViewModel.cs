using Demo.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace Demo.ViewModel
{
    public class StartViewModel : ViewModelBase
    {

        public StartViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }


        private RelayCommand<object> openNewProjectWindowCommand;
        public RelayCommand<object> OpenNewProjectWindowCommand
        {
            get
            {
                if (openNewProjectWindowCommand == null)
                {
                    openNewProjectWindowCommand = new RelayCommand<object>(OpenNewProjectWindow);
                }
                return openNewProjectWindowCommand;
            }
        }


        private void OpenNewProjectWindow(object obj)
        {
            NewProjectWindow window = new NewProjectWindow();
            if (window.Owner == null)
            {
                window.Owner = obj as Window;
            }
            window.ShowDialog();
            window.Owner = null;
            window = null;
        }


        //public RelayCommand<object> OpenNewProjectWindowCommand 
        //    => new RelayCommand<object>((o)=>
        //{
        //    var window = new NewProjectWindow();
        //    window.Owner = o as Window;
        //    MessageBox.Show(window.Owner.ToString());
        //    MessageBox.Show(window.ShowDialog().ToString());
        //});

        //public RelayCommand<NewProjectWindow> OpenNewProjectWindowCommand
        //    => new RelayCommand<NewProjectWindow>((window) =>
        //{
        //    MessageBox.Show(window.Owner.ToString());
        //    MessageBox.Show(window.ShowDialog().ToString());
        //});
    }
}