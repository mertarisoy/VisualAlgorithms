using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VisualAlgorithms.Common
{
    public class UserManager
    {
        public static UserInfo CurrentUser { get; set; }

        private static readonly string KEY_CODE = "UserInfo";
        public static bool UserLoggedIn()
        {

            var context = HttpContext.Current;
            var user = context.Session[KEY_CODE];
            if (user == null)
                return false;

            return true;
        }

        public static void CreateSession(UserInfo user)
        {
            HttpContext.Current.Session[KEY_CODE] = user;
            CurrentUser = user;
        }

        public static void DestroySession()
        {
            CurrentUser = null;
            HttpContext.Current.Session.Clear();
        }

    }
}
