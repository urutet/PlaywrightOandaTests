using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightTests.Model;

namespace PlaywrightTests.Service
{
    public static class UserCreator
    {
        private static string _cookiePath = "..\\..\\..\\auth.json";

        public static User userWithDefaultCookie()
        {
            return new User(_cookiePath);
        }

        public static User userWithDesirableCookie(string cookiePath)
        {
            return new User(cookiePath);
        }

        public static User userWithEmptyCookie()
        {
            return new User("");
        }
    }
}
