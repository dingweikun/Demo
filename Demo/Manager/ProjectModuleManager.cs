using Demo.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo.Manager
{
    internal static class ProjectModuleManager
    {
        // 存储模块的内部字典
        static Dictionary<ProjectModuleAttribute, ProjectModule> modDict = new Dictionary<ProjectModuleAttribute, ProjectModule>();

        /// <summary>
        /// 已加载模块数量
        /// </summary>
        public static int ModuleCount => modDict.Count;

        /// <summary>
        /// 已加载的所有模块
        /// </summary>
        public static IReadOnlyCollection<ProjectModule> Modules
        {
            get
            {
                var list = new List<ProjectModule>();
                var keys = modDict.Keys.ToArray();
                foreach (var attr in keys)
                {
                    list.Add(GetModule(attr));
                }
                return list;
            }
        }
        
         // 构造函数，加载模块
         static ProjectModuleManager() => ReloadModules();

        /// <summary>
        /// 根据配置文件，加载程序模块
        /// </summary>
        public static void ReloadModules()
        {
            modDict.Clear();

            string path = Properties.Settings.Default.ProjectModulePath.Trim();
            string files = Properties.Settings.Default.ProjectModuleAssembly.Trim();

            foreach (string file in files.Split(new char[] { ';' }))
            {
                Assembly assembly = null;

                try
                {
                    // 加载模块程序集
                    //assembly = Assembly.LoadFrom(path + '\\' + file.Trim());
                    //MessageBox.Show(file.Trim());
                    assembly = Assembly.LoadFrom(file.Trim());
                }
                catch (System.Exception e)
                {
                    // 加载模块程序集失败
                    continue;
                }

                if (assembly != null)
                {
                    var attr = from t in assembly.ExportedTypes
                               where t.GetCustomAttribute<ProjectModuleAttribute>() != null
                               select t.GetCustomAttribute<ProjectModuleAttribute>();
                    foreach (var a in attr)
                    {
                        modDict.Add(a, null); // 延迟创建模块的实例，实际创建模块是在获取模块的 GetModule 方法中
                    }
                }
            }

        }

        /// <summary>
        /// 根据 ProjectModuleAttribute 查找模块
        /// </summary>
        private static ProjectModule GetModule(ProjectModuleAttribute attribute)
        {
            System.Diagnostics.Debug.Assert(modDict.ContainsKey(attribute));
            if (modDict[attribute] == null)
            {
                Type modType = attribute.Type;
                try
                {
                    // 创建模块实例
                    modDict[attribute] = modType.Assembly.CreateInstance(modType.FullName) as ProjectModule;
                    if (modDict[attribute] == null)
                        throw new NullReferenceException();
                }
                catch (System.Exception e)
                {
                    // 模块加载失败，日志记录异常信息（待实现），删除当前加载项
                    modDict.Remove(attribute);
                    return null;
                }
            }
            return modDict[attribute];
        }

        /// <summary>
        /// 根据类型查找模块
        /// </summary>
        public static ProjectModule GetModule(Type ProjectModuleType)
        {
            foreach (var attr in modDict.Keys)
            {
                if (attr.Type == ProjectModuleType)
                    return GetModule(attr);
            }
            return null;
        }
    }

}
