using System;
using System.Collections.Generic;
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

            //Running shell until user enter "exit"
            do
            {
                //Console.Write(DirectoryInformation.GetvisibleDirectoryName());
                userInput = Console.ReadLine();
                Console.WriteLine(userInput);
                shell.execute(userInput);

            } while (userInput != "exit");
        }
    }
}
