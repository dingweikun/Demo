using Demo.Manager;
using Demo.Module;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ViewModel
{
    public class ProjectModuleSelectWindowViewModel : ViewModelBase
    {
        public IEnumerable<ProjectModule> InfoModules => ProjectModuleManager.SelectModule(ProjectModuleManager.Modules, ProjectModuleCategory.Information);
        public IEnumerable<ProjectModule> ResourceModules => ProjectModuleManager.SelectModule(ProjectModuleManager.Modules, ProjectModuleCategory.Resource);
        public IEnumerable<ProjectModule> DemandModules => ProjectModuleManager.SelectModule(ProjectModuleManager.Modules, ProjectModuleCategory.Demand);
        public IEnumerable<ProjectModule> SupportModules => ProjectModuleManager.SelectModule(ProjectModuleManager.Modules, ProjectModuleCategory.Support);

        public ProjectModuleSelectWindowViewModel()
        {
        }

        // 主动通知属性变化
        protected void RaiseModulesSeletionChanged()
        {
            RaisePropertyChanged(nameof(InfoModules));
            RaisePropertyChanged(nameof(ResourceModules));
            RaisePropertyChanged(nameof(DemandModules));
            RaisePropertyChanged(nameof(SupportModules));
        }

        private ProjectModuleCategory selectedCategory;
        public ProjectModuleCategory SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                RaisePropertyChanged(nameof(SelectedCategory));
            }
        }


    }

}
