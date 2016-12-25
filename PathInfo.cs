using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    static class PathInfo
    {
        public static bool IsRooted(string path)
        {
            string[] pathName = path.Split('\\');
            if (pathName[0].ToLower().Equals("z:"))
            {
               return true;
            }
            return false;
        }

        public static string GetCorrectPath(string path)
        {
            string correctPath = path.Replace(@"z:\", @"");
            return correctPath;
        }
    }
}
