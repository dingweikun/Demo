using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace Demo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
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



        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
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




        //public bool IsSettingViewOpen
        //{
        //    get { return }
        //    set;
        //}

        private int tabIndex;
        public int TabIndex
        {
            get => tabIndex;
            set
            {
                if (tabIndex != value)
                {
                    tabIndex = value % 2;
                    RaisePropertyChanged(nameof(TabIndex));
                }
            }
        }

        public RelayCommand<int> MainWindowHelpCommand => new RelayCommand<int>(x => TabIndex = x + 1);

    }
}