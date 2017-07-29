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


        public RelayCommand<object> OpenNewProjectWindowCommand => new RelayCommand<object>
            ((param) =>
            {
                var window = new NewProjectWindow() { Owner = param as Window };
                window.ShowDialog();
            });

    }

}
