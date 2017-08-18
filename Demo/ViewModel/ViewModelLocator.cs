/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Demo"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Demo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<StartViewViewModel>();
            SimpleIoc.Default.Register<AppearenceViewViewModel>();
            SimpleIoc.Default.Register<ProjectViewViewModel>();
            SimpleIoc.Default.Register<ProjectModuleSelectWindowViewModel>();
        }

        public MainWindowViewModel MainWindow => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public StartViewViewModel StartView => ServiceLocator.Current.GetInstance<StartViewViewModel>();
        public AppearenceViewViewModel AppearenceView => ServiceLocator.Current.GetInstance<AppearenceViewViewModel>();
        public ProjectViewViewModel ProjectView => ServiceLocator.Current.GetInstance<ProjectViewViewModel>();
        public ProjectModuleSelectWindowViewModel ProjectModuleSelectWindow => ServiceLocator.Current.GetInstance<ProjectModuleSelectWindowViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
