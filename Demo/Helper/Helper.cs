using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo.Helper
{
    internal class Helper
    {

        public static Window FindParentWindow(DependencyObject elemet)
        {
            var parent = LogicalTreeHelper.GetParent(elemet);
            if (parent == null || parent is Window)
                return parent as Window;
            else
                return FindParentWindow(parent);
        }


    }
}
