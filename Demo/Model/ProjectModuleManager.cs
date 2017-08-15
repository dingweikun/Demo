using Demo.Module;
using Demo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

/*
namespace Demo.Model
{
    
    public class ProjectModuleManager
    {
        // 定义一个静态变量来保存类的实例
        private static ProjectModuleManager instance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private ProjectModuleManager()
        {
            InitModules();
        }

        /// <summary>
        /// 定义公有属性来提供全局访问点
        /// </summary>
        public static ProjectModuleManager Instance
        {
            get
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                // 双重锁定只需要一句判断就可以了
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

        //=================================


        private List<IProjectModule> modules;
        public IReadOnlyCollection<IProjectModule> Modules => modules;

        private void InitModules()
        {
            modules = new List<IProjectModule>();

            var ass = Assembly.LoadFrom(@"ProjectModule\Module.PrimaryInfo.dll");
            if(ass!=null)
            {
                var l1 = from x in ass.ExportedTypes
                         where x.GetCustomAttribute<ProjectModuleAttribute>() != null
                         select x.GetCustomAttribute<ProjectModuleAttribute>();

                foreach(var a in l1)
                {
                    modules.Add(a.Type.Assembly.CreateInstance(a.Type.FullName) as IProjectModule);
                }

            }

        }
    }

}
//*/