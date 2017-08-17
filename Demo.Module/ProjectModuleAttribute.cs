
using System;

namespace Demo.Module
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProjectModuleAttribute : Attribute
    {
        /// <summary>
        /// Module type.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Project module category.
        /// </summary>
        public ProjectModuleCategory Category { get; }


        public ProjectModuleAttribute(Type type, ProjectModuleCategory category)
        {
            Type = type;
            Category = Category;
        }
    }
}
