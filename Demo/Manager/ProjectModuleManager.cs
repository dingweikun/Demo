using Demo.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Manager
{
    public static class ProjectModuleManager
    {
        static List<ProjectModule> infoModules = new List<ProjectModule>();
        static List<ProjectModule> resourceModules = new List<ProjectModule>();
        static List<ProjectModule> demandModules = new List<ProjectModule>();
        static List<ProjectModule> supportModules = new List<ProjectModule>();

        public static IReadOnlyCollection<ProjectModule> InfoModules => infoModules;
        public static IReadOnlyCollection<ProjectModule> ResourceModules => resourceModules;
        public static IReadOnlyCollection<ProjectModule> DemandModules => demandModules;
        public static IReadOnlyCollection<ProjectModule> SupportModules => supportModules;

        /// <summary>
        /// 根据配置文件，加载程序模块
        /// </summary>
        public static void ReloadModules()
        {
            string dir = Properties.ProjectModule.Default.ProjectModulePath.Trim();
            string mod = Properties.ProjectModule.Default.InfoModules.Trim();

            //分割字符串
            var files = mod.Split(new char[] { ';' });

            foreach (string s in files)
            {
                // 加载
                var ass = Assembly.LoadFrom(dir + '\\' + s.Trim());

            }
        }
    }
}
