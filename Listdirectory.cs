using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class ListDirectory
    {
        static void Main(string[] args)
        {
            string currentDirectory = null;

            //Argument is specified
            if (args.Length == 1)
            {
                string curDir = DirectoryInformation.GetCurrentWorkingDirectory();

                if (args[0].Equals("..") && DirectoryInformation.IsRootDirectory(curDir))
                {
                    currentDirectory = curDir;
                }
                else
                {
                    currentDirectory = curDir + @"\" + args[0];
                }
            }
            else
            {
                currentDirectory = DirectoryInformation.GetCurrentWorkingDirectory();
            }

            if (!Directory.Exists(currentDirectory))
            {
                Console.Write("\nThe specified path doesn't exist.");
                return;
            }

            string[] files = Directory.GetFiles(currentDirectory);
            string[] directories = Directory.GetDirectories(currentDirectory);

            foreach (string directory in directories)
            {
                string[] fileNames = directory.Split('\\');
                Console.Write("\n" + fileNames[fileNames.Length - 1]);
            }

            foreach (string file in files)
            {
                string[] fileNames = file.Split('\\');
                Console.Write("\n" + fileNames[fileNames.Length - 1]);
            }
        }
    }
}
