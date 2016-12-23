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
        public CommandPrompt()
        {
            using (StreamWriter sw = new StreamWriter("./DirectoryInfo.txt"))
            {
                sw.WriteLine(@"C:\Users\manverma\Documents\Visual Studio 2015\Projects\FileSystem\FileSystem\Z\");
            }
        }
        static void Main(string[] args)
        {
            string userInput = null;
            Shell shell = new Shell();

            //Running shell until user enter "exit"
            do
            {
                Console.Write(DirectoryInformation.GetVisibleDirectoryName() + ">");
                userInput = Console.ReadLine();
                Console.WriteLine(userInput);
                shell.execute(userInput);

            } while (userInput != "exit");
        }
    }
}
