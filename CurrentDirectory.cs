using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class CurrentDirectory : Command
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

                    if ((args[0].Equals("..") || args[0].Equals(".")) && DirectoryInformation.IsRootDirectory(curDir))
                    {
                        return;
                    }

                    if (args[0].Equals("..") && !DirectoryInformation.IsRootDirectory(curDir))
                    {
                        string curDirectory = DirectoryInformation.GetCurrentWorkingDirectory();
                        string parentDirectory = Directory.GetParent(Directory.GetParent(curDirectory).FullName).FullName;
                        DirectoryInformation.SetVisibleDirectoryName(parentDirectory);
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

        public void help()
        {
            Console.Write(@"Displays the name of or changes the current directory. CD[..] Specifies that you 
                want to change to the parent directoy
                ..Specifies that you want to change to the parent directory.

                Type CD drive: to display the current directory in the specified drive.
                Type CD without parameters to display the current drive and directory.

                Use the / D switch to change current drive in addition to changing current
                directory for a drive.");
        }
    }
}
