using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Demo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public Accent CurrentAccent
        {
            get => ThemeManager.DetectAppStyle(Current).Item2 as Accent;
            set => ThemeManager.ChangeAppStyle(Current, value, CurrentTheme);
        }

        public AppTheme CurrentTheme
        {
            get => ThemeManager.DetectAppStyle(Current).Item1 as AppTheme;
            set => ThemeManager.ChangeAppStyle(Current, CurrentAccent, value);
        }






        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 配置程序


        }


        /// <summary>
        /// 设置程序主题和颜色
        /// </summary>
        public void SetAppliactionApperance(AppTheme theme, Accent accent)
        {
            ThemeManager.ChangeAppStyle(Current, accent, theme);
        }



        /// <summary>
        /// 设置程序语言
        /// </summary>
        protected void SetAppliactionLanguage()
        {

        }


    }
}
