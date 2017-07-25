using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingWK.MultiLanguage
{
    public interface IStringResource
    {
        string GetString(string name);
        CultureInfo CurrentCulture { set; }
    }
}
