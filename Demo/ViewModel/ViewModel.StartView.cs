using Demo.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace Demo.ViewModel
{
    public class StartViewViewModel : ViewModelBase
    {

        public StartViewViewModel()
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


        public RelayCommand<Window> NewProjectCommand => new RelayCommand<Window>
            ((w) => (new NewProjectWindow() { Owner = w }).ShowDialog());

        public RelayCommand<Window> OpenProjectCommand => new RelayCommand<Window>
            ((w) => (new OpenProjectWindow() { Owner = w }).ShowDialog());

    }

}
