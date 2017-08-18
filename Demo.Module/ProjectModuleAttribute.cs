
using System;

namespace Demo.Module
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
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
            Category = category;
        }


        public override string ToString()
        {
            return Type.ToString() + "[" + Category.ToString() + "]";
        }
    }
}
