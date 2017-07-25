using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DingWK.MultiLanguage
{
    public class StringResource : IStringResource
    { 
        public const string ResourceFileRootName = "StringResource";

        private ResourceManager resourceManager;

        //我们这样设置的时候ResourceManager会去查找MultilanguageTest.StringResource.en-us.resx,如果没有会查找MultilanguageTest.StringResource.resx
        private CultureInfo culture = new CultureInfo("en-us");


        public StringResource(Assembly assembly)
        {
            //MultilanguageTest.StringResource是根名称，该实例使用指定的System.Reflection.Assmbly查找从指定的跟名称导出的文件中包含的资源
            resourceManager = new ResourceManager(ResourceFileRootName, assembly);
        }

        /// <summary>
        /// 通过资源名称获取资源内容
        /// </summary>
        public string GetString(string name)
        {
            return resourceManager.GetString(name, culture);
        }
        /// <summary>
        /// 改变当前的区域信息，ResourceManager可以通过当前区域信息去查找.resx文件
        /// </summary>
        public CultureInfo CurrentCulture
        {
            set
            {
                culture = value;
            }
        }
    }
}
