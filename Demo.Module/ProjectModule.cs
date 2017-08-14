using System;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Module
{
    public class ProjectModule : UserControl, IProjectModule
    {
        public virtual string ModuleName => throw new NotImplementedException();

        #region IsInEdit
        /// <summary>
        /// 
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
                new FrameworkPropertyMetadata(false)
                {
                    PropertyChangedCallback = (d, e) => (d as IProjectModule)?.UpdateModule()
                });
        #endregion


        public virtual void UpdateModule() => throw new NotImplementedException();

    }
}
