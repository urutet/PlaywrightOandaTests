using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Utils
{
    public static class DirectoryNames
    {
        public static string GetSolutionDirectory =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static string GetProjectDirectory =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
    }
}
