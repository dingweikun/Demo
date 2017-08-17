using System.Windows;
using System.Windows.Controls;

namespace Demo.Module
{

    public abstract class ProjectModule : UserControl, IProjectModule
    {
        /// <summary>
        /// 工程模块分类
        /// </summary>
        //public enum ProjectModuleCategory
        //{
        //    Information,
        //    Resource,
        //    Demand,
        //    Support
        //}

        public abstract ProjectModuleCategory Category { get; }


        #region ModuleTitle
        /// <summary>
        /// 模块的标题名称
        /// </summary>
        public string ModuleTitle
        {
            get { return (string)GetValue(ModuleTitleProperty); }
            set { SetValue(ModuleTitleProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty ModuleTitleProperty =
            DependencyProperty.Register(
                nameof(ModuleTitle),
                typeof(string),
                typeof(ProjectModule),
                new FrameworkPropertyMetadata(string.Empty));
        #endregion

        #region IsInEdit
        /// <summary>
        /// 表示模块是否在编辑状态
        /// </summary>
        public bool IsInEdit
        {
            get { return (bool)GetValue(IsInEditProperty); }
            set { SetValue(IsInEditProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty IsInEditProperty =
            DependencyProperty.Register(
                nameof(IsInEdit),
                typeof(bool),
                typeof(ProjectModule),
                new FrameworkPropertyMetadata(false) { PropertyChangedCallback = OnIsInEditPropertyChanged });

        private static void OnIsInEditPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProjectModule module)
            {
                if ((bool)(e.NewValue))
                    module.IsInEditValueChangedToTrue();
                else
                    module.IsInEditValueChangedToFalse();
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected abstract void IsInEditValueChangedToTrue();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void IsInEditValueChangedToFalse();
    }
}