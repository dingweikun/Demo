using Demo.Manager;
using Demo.Module;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace Demo.ViewModel
{
    //public interface ISelectWapper
    //{
    //    bool IsSelected { get; set; }
    //}

    //public class SelectWapper<T> : ViewModelBase, ISelectWapper
    //{
    //    private T target;

    //    private bool isSelected;

    //    public T Target
    //    {
    //        get => target;
    //        set
    //        {
    //            target = value;
    //            RaisePropertyChanged(nameof(Target));
    //        }
    //    }

    //    public bool IsSelected
    //    {
    //        get => IsSelected;
    //        set
    //        {
    //            isSelected = value;
    //            RaisePropertyChanged(nameof(IsSelected));
    //        }
    //    }

    //    public SelectWapper(T target, bool isSelected)
    //    {
    //        this.target = target;
    //        this.isSelected = isSelected;
    //    }
    //}



    public class ProjectModuleSelectWapper : ViewModelBase
    {
        private ProjectModule module;

        private bool isSelected;

        public ProjectModule Module
        {
            get => module;
            set
            {
                module = value;
                RaisePropertyChanged(nameof(Module));
            }
        }

        public bool IsSelected
        {
            get => IsSelected;
            set
            {
                isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }

        public ProjectModuleSelectWapper()
        {
            this.module = null;
            this.isSelected = false;
        }

        public ProjectModuleSelectWapper(ProjectModule module, bool isSelected)
        {
            this.module = module;
            this.isSelected = isSelected;
        }

    }


    public class ProjectModuleSelectWindowViewModel : ViewModelBase
    {
        private readonly List<ProjectModuleSelectWapper> projectModules;
        public IEnumerable<ProjectModuleSelectWapper> InfoModules => SelectModulesByCategory(ProjectModuleCategory.Information);
        public IEnumerable<ProjectModuleSelectWapper> ResourceModules => SelectModulesByCategory(ProjectModuleCategory.Resource);
        public IEnumerable<ProjectModuleSelectWapper> DemandModules => SelectModulesByCategory(ProjectModuleCategory.Demand);
        public IEnumerable<ProjectModuleSelectWapper> SupportModules => SelectModulesByCategory(ProjectModuleCategory.Support);

        //private readonly List<SelectWapper<ProjectModule>> projectModules;
        //public IEnumerable<SelectWapper<ProjectModule>> InfoModules => SelectModulesByCategory(ProjectModuleCategory.Information);
        //public IEnumerable<SelectWapper<ProjectModule>> ResourceModules => SelectModulesByCategory(ProjectModuleCategory.Resource);
        //public IEnumerable<SelectWapper<ProjectModule>> DemandModules => SelectModulesByCategory(ProjectModuleCategory.Demand);
        //public IEnumerable<SelectWapper<ProjectModule>> SupportModules => SelectModulesByCategory(ProjectModuleCategory.Support);

        public ProjectModuleSelectWindowViewModel()
        {
            //projectModules = new List<SelectWapper<ProjectModule>>();
            projectModules = new List<ProjectModuleSelectWapper>();
            ReloadAllProjectModules();
        }

        // 获取根据配置文件已加载的所有模块
        protected void ReloadAllProjectModules()
        {
            projectModules.Clear();
            //foreach (var m in ProjectModuleManager.Modules)
            //    projectModules.Add(new SelectWapper<ProjectModule>(m, false));           
            foreach (var m in ProjectModuleManager.Modules)
                projectModules.Add(new ProjectModuleSelectWapper() { Module = m, IsSelected = false });

            RaiseModulesSeletionChanged();
        }

        // 根据分类筛选模块
        //protected IEnumerable<SelectWapper<ProjectModule>> SelectModulesByCategory(ProjectModuleCategory category)
        //{
        //    return from module in projectModules
        //           where module.Target.Category == category
        //           select module;
        //}
        protected IEnumerable<ProjectModuleSelectWapper> SelectModulesByCategory(ProjectModuleCategory category)
        {
            return from module in projectModules
                   where module.Module.Category == category
                   select module;
        }

        // 主动通知属性变化
        protected void RaiseModulesSeletionChanged()
        {
            RaisePropertyChanged(nameof(InfoModules));
            RaisePropertyChanged(nameof(ResourceModules));
            RaisePropertyChanged(nameof(DemandModules));
            RaisePropertyChanged(nameof(SupportModules));
        }





    }

}
