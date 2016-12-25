using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class CommandPrompt
    {
        static void Main(string[] args)
        {
            string userInput = null;
            Shell shell = new Shell();

            using (StreamWriter sw = new StreamWriter("./DirectoryInfo.txt"))
            {
                sw.WriteLine(@"C:\Users\manverma\Documents\Visual Studio 2015\Projects\FileSystem\FileSystem\Z\");
            }

            //Running shell until user enter "exit"
            do
            {
                Console.WriteLine();
                Console.Write(DirectoryInformation.GetVisibleDirectoryName() + ">");
                userInput = Console.ReadLine();
                shell.execute(userInput);
                Console.WriteLine();
               
            } while (userInput != "exit");
        }
    }
}
