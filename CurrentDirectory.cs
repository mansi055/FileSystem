using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class CurrentDirectory
    {
        static void Main(string[] args)
        {
            try
            {
                //No path specified with the command
                if (args.Length == 0)
                {
                    string output = DirectoryInformation.GetVisibleDirectoryName();

                    Console.Write("\n" + output);
                    return;
                }
                //Path is specified wuth the command
                else if (args.Length == 1)
                {
                    string curDir = DirectoryInformation.GetCurrentWorkingDirectory();
                    string path = curDir + args[0];

                    if (args[0].Equals("..") && !DirectoryInformation.IsRootDirectory(curDir))
                    {
                        string curDirectory = DirectoryInformation.GetCurrentWorkingDirectory();
                        string parentDirectory = Directory.GetParent(Directory.GetParent(curDirectory).FullName).FullName;
                        DirectoryInformation.SetVisibleDirectoryName(parentDirectory);
                        return;
                    }
                    else if (args[0].Equals(".") && !DirectoryInformation.IsRootDirectory(curDir))
                    {
                        string curDirectory = DirectoryInformation.GetCurrentWorkingDirectory();
                        Console.WriteLine();
                    }
                    else if (Directory.Exists(path))
                    {
                        DirectoryInformation.SetVisibleDirectoryName(path);
                    }
                    else
                    {
                        Console.Write("\nThe system can't find this path.");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

    }
}
