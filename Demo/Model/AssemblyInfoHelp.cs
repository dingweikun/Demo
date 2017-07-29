using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    public static class AssemblyInfoHelp
    {
        static AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();

        public static string Version => assembly.Version.ToString();
        public static string Name => assembly.FullName;
    }
}
