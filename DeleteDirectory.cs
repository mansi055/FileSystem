using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class DeleteDirectory
    {
        static void Main(string[] args)
        {
            try
            {
                //No path specified with the command
                if (args.Length == 0)
                {
                    Console.Write("\nThe syntax of the command is incorrect.");
                    return;
                }
                //Path is specified with the command
                else if (args.Length == 1)
                {
                    string path = DirectoryInformation.GetCurrentWorkingDirectory() + args[0];

                    if (!Directory.Exists(path))
                    {
                        Console.Write("\nThe specified path is incorrect.");
                    }
                    else if (path.Contains("..") || path.Contains("."))
                    {
                        Console.Write("\nThe process cannot access the file because it is being used by another process.");
                    }
                    else
                    {
                        Directory.Delete(path, true);
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
