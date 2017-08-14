using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProjectModuleAttribute : System.Attribute
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}
