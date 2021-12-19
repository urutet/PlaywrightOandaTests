using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Model
{
    public class User
    {
        public string CookiePath { get; }

        public User(string cookiePath)
        {
            CookiePath = cookiePath;
        }
    }
}
