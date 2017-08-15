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
        /// <summary>
        /// Module type.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Project module category.
        /// </summary>
        public ProjectModule.Category Category { get; }


        public ProjectModuleAttribute(Type type, ProjectModule.Category category)
        {
            Type = type;
            Category = Category;
        }
    }
}
