using Demo.Manager;
using Demo.Module;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Demo.ViewModel
{
    public class ProjectViewViewModel : ViewModelBase
    {
        public ProjectViewViewModel()
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


        // ��ע��
        // ���� ObservableCollection <T> ���б�����Զ�֪ͨ���ܣ� �������ƺ�ʵ��֪ͨ���� 

        private readonly ObservableCollection<ProjectModule> projectModules = new ObservableCollection<ProjectModule>();

        public ObservableCollection<ProjectModule> ProjectModules => projectModules;
        public IEnumerable<ProjectModule> InfoModules => SelectModulesByCategory(ProjectModuleCategory.Information);
        public IEnumerable<ProjectModule> ResourceModules => SelectModulesByCategory(ProjectModuleCategory.Resource);
        public IEnumerable<ProjectModule> DemandModules => SelectModulesByCategory(ProjectModuleCategory.Demand);
        public IEnumerable<ProjectModule> SupportModules => SelectModulesByCategory(ProjectModuleCategory.Support);
        public bool HasModuleLoaded => projectModules.Count > 0;

        private IEnumerable<ProjectModule> SelectModulesByCategory(ProjectModuleCategory category)
            => from module in projectModules
               where module.Category == category
               select module;



        public void LoadAllProjectModules()
        {
            //projectModules.Clear();
            foreach (var m in ProjectModuleManager.Modules)
                projectModules.Add(m);

            // ֪ͨ���Ա仯
            RaisePropertyChanged(nameof(ProjectModules));
            RaisePropertyChanged(nameof(InfoModules));
            RaisePropertyChanged(nameof(ResourceModules));
            RaisePropertyChanged(nameof(DemandModules));
            RaisePropertyChanged(nameof(SupportModules));
            RaisePropertyChanged(nameof(HasModuleLoaded));
        }



    }

}
