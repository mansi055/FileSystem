using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class MakeDirectory : Command
    {
        static void Main(string[] args)
        {
            //Console.Write("Running Make Directory!!! \n");
            string path = DirectoryInformation.GetCurrentWorkingDirectory();

            if (args.Length == 0)
            {
                Console.Write("\nThe syntax of the command is incorrect.");
                return;
            }

            path = path + args[0];

            try
            {
                if (!Directory.Exists(path))
                {
                    System.IO.DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                }
                else
                {
                    Console.Write("\nThere is already a file with this name.");
                }

            }
            catch (IOException ioex)
            {
                Console.Write(ioex.Message);
            }

        }

        public void help()
        {
            Console.Write(@"\nCreates a directory.
                            MD[drive:]path
                            If Command Extensions are enabled MD changes as follows:
                            MD creates any intermediate directories in the path, if needed.");  
        }
    }
}
