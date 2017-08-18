using Demo.View;
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
    public class MainWindowViewModel : ViewModelBase
    {

        public enum MainWindowSubView
        {
            StartView = 0,
            Workspaceview = 1
        };


        private MainWindowSubView currentSubView;
        public MainWindowSubView CurrentSubView
        {
            get => currentSubView;
            set
            {
                if(currentSubView != value)
                {
                    currentSubView = value;
                    RaisePropertyChanged(nameof(CurrentSubView));
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowViewModel()
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


        public RelayCommand<Window> HelpButtonCommand => new RelayCommand<Window>
            ((o) => (new AboutWindow() { Owner = o }).ShowDialog());



    }
}