using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    static class DirectoryInformation
    {
        public static string GetCurrentWorkingDirectory()
        {
            StreamReader sr = null;
            string directory = "";
            using (sr = new StreamReader("./DirectoryInfo.txt"))
            {
                directory = sr.ReadLine();
            }
            sr.Close();
            return directory;
        }

        public static string GetVisibleDirectoryName()
        {
            StreamReader sr = null;
            string directory = "";
            using (sr = new StreamReader("./DirectoryInfo.txt"))
            {
                directory = sr.ReadLine();
            }
            sr.Close();
            directory = directory.Replace(@"C:\Users\manverma\Documents\Visual Studio 2015\Projects\FileSystem\FileSystem\Z\", @"Z:\");
            return directory;
        }

        public static void SetVisibleDirectoryName(string directory)
        {
            using (StreamWriter sw = new StreamWriter("./DirectoryInfo.txt"))
            {
                sw.WriteLine(directory + @"\");
            }
            return;
        }

        public static bool IsRootDirectory(string directory)
        {
            string rootDirectory = @"C:\Users\manverma\Documents\Visual Studio 2015\Projects\FileSystem\FileSystem\Z\";
            return rootDirectory == directory;
        }
    }
}
