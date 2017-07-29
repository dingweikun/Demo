using Demo.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace Demo.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private bool isWorkapeceActive;
        public bool IsWorkspaceActive
        {
            get => isWorkapeceActive;
            set
            {
                if (isWorkapeceActive != value)
                {
                    isWorkapeceActive = value;
                    RaisePropertyChanged(nameof(IsWorkspaceActive));
                }
            }
        }



         public MainViewModel()
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


        public RelayCommand<AboutWindow> MainWindowHelpCommand => new RelayCommand<AboutWindow>((window) => window.Show());


        //private int tabIndex;
        //public int TabIndex
        //{
        //    get => tabIndex;
        //    set
        //    {
        //        if (tabIndex != value)
        //        {
        //            tabIndex = value % 2;
        //            RaisePropertyChanged(nameof(TabIndex));
        //        }
        //    }
        //}

        //public RelayCommand<int> MainWindowHelpCommand => new RelayCommand<int>(x => TabIndex = x + 1);

    }
}