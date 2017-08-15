using Demo.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Demo.Manager
{

    /*
    public static class ProjectModuleManager
    {
        static Dictionary<ProjectModuleAttribute, ProjectModule> modDict = new Dictionary<ProjectModuleAttribute, ProjectModule>();

        public static int Count => modDict.Count;

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


        static ProjectModuleManager() => ReloadModules();


        private static ProjectModule GetModule(ProjectModuleAttribute attribute)
        {
            System.Diagnostics.Debug.Assert(modDict.ContainsKey(attribute));
            if (modDict[attribute] == null)
            {
                // 加载外部模块
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
                    // 模块加载失败，日志记录异常信息（未实现），删除当前加载项
                    modDict.Remove(attribute);
                    return null;
                }
            }
            return modDict[attribute];
        }

        public static ProjectModule GetModule(string ProjectModuleName)
        {
            foreach (var attr in modDict.Keys)
            {
                if (attr.Name == ProjectModuleName)
                    return GetModule(attr);
            }
            return null;
        }

        public static ProjectModule GetModule(Type ProjectModuleType)
        {
            foreach (var attr in modDict.Keys)
            {
                if (attr.Type == ProjectModuleType)
                    return GetModule(attr);
            }
            return null;
        }

        /// <summary>
        /// 根据配置文件，加载程序模块
        /// </summary>
        public static void ReloadModules()
        {
            modDict.Clear();

            string path = Properties.ProjectModule.Default.ProjectModulePath.Trim();
            string files = Properties.ProjectModule.Default.ProjectModules.Trim();

            foreach (string file in files.Split(new char[] { ';' }))
            {
                Assembly assembly = null;

                try
                {
                    // 加载
                    assembly = Assembly.LoadFrom(path + '\\' + file.Trim());
                }
                catch (System.Exception e)
                {
                    // 加载模块失败
                    continue;
                }

                if (assembly != null)
                {
                    var attr = from t in assembly.ExportedTypes
                               where t.GetCustomAttribute<ProjectModuleAttribute>() != null
                               select t.GetCustomAttribute<ProjectModuleAttribute>();
                    foreach (var a in attr)
                    {
                        modDict.Add(a, null); // 延迟加载模块
                    }
                }
            }
        }
    }//*/





    //*
    public class ProjectModuleManager
    {
        #region 单例模式

        //定义一个静态变量来保存类的实例
        private static ProjectModuleManager instance;

        //定义一个标识确保线程同步
        private static readonly object locker = new object();

        //定义私有构造函数，使外界不能创建该类实例
        private ProjectModuleManager()
        {
            modDict = new Dictionary<ProjectModuleAttribute, ProjectModule>();
            ReloadModules();
        }

        /// <summary>
        /// 单例实例
        /// </summary>
        public static ProjectModuleManager Instance
        {
            get
            {
                //当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                //当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                //lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                //双重锁定只需要一句判断就可以了
                if (instance == null)
                {
                    lock (locker)
                    {
                        // 如果类的实例不存在则创建，否则直接返回
                        if (instance == null)
                        {
                            instance = new ProjectModuleManager();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion

        // 存储模块的内部字典
        private Dictionary<ProjectModuleAttribute, ProjectModule> modDict;

        /// <summary>
        /// 已加载的所有模块
        /// </summary>
        public IReadOnlyCollection<ProjectModule> Modules
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

        /// <summary>
        /// 已加载模块数量
        /// </summary>
        public int ModuleCount => modDict.Count;

        /// <summary>
        /// 根据配置文件，加载程序模块
        /// </summary>
        public void ReloadModules()
        {
            modDict.Clear();

            string path = Properties.ProjectModule.Default.ProjectModulePath.Trim();
            string files = Properties.ProjectModule.Default.ProjectModules.Trim();

            foreach (string file in files.Split(new char[] { ';' }))
            {
                Assembly assembly = null;

                try
                {
                    // 加载模块程序集
                    assembly = Assembly.LoadFrom(path + '\\' + file.Trim());
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
                        modDict.Add(a, null); // 延迟创建模块的实例，真正创建模块是在获取模块的 GetModule 方法中
                    }
                }
            }
        }

        /// <summary>
        /// 根据 ProjectModuleAttribute 查找模块
        /// </summary>
        private ProjectModule GetModule(ProjectModuleAttribute attribute)
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
                    // 模块创建失败，日志记录异常信息（未实现），删除当前加载项
                    modDict.Remove(attribute);
                    return null;
                }
            }
            return modDict[attribute];
        }

        /// <summary>
        /// 根据类型查找模块
        /// </summary>
        public ProjectModule GetModule(Type ProjectModuleType)
        {
            foreach (var attr in modDict.Keys)
            {
                if (attr.Type == ProjectModuleType)
                    return GetModule(attr);
            }
            return null;
        }

    }

    //*/
}
