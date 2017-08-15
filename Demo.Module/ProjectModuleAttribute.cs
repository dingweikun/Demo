
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
        public ProjectModule.Category Category { get; }
        public ProjectModuleAttribute(Type type, ProjectModule.Category category)
        {
            Type = type;
            Category = Category;
        }
    }
}
