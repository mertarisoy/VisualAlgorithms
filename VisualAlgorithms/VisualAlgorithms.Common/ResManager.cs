using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Common
{
    public static class ResManager
    {
        public static string GetResource(string key)
        {
            
            var myManager = new ResourceManager("VisualAlgorithms.Common.Resources.Strings", Assembly.GetExecutingAssembly());
            string res = key;

            try
            {
                var o = myManager.GetString(key, CultureInfo.CurrentCulture);
                if (o != null) return o;
            }
            catch
            {
                return res; 
            }

            return res;
        }
    }
}
