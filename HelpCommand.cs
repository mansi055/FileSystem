using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class HelpCommand
    {
        protected void PrintInstrucctions(string command)
        {
            switch (command)
            {
                case "cd" :  
                    Console.Write(@"\nDisplays the name of or changes the current directory. CD[..] \nSpecifies that you 
                want to change to the parent directoy
                ..Specifies that you want to change to the parent directory.

                Type CD drive: to display the current directory in the specified drive.
                Type CD without parameters to display the current drive and directory.

                Use the / D switch to change current drive in addition to changing current
                directory for a drive.");
                    break;
                case "dir" :
                    Console.Write(@"\nDisplays a list of files and subdirectories in a directory.
                            DIR[drive:][path][filename]");
                    break;
                case "md" :
                    Console.Write(@"\nCreates a directory.
                            MD[drive:]path
                            If Command Extensions are enabled MD changes as follows:
                            MD creates any intermediate directories in the path, if needed.");
                    break;
                case "del dir" :
                    Console.Write(@"\nRemoves (deletes) a directory.
                            DEL DIR[/ S][/ Q][drive:]path
                            DEL DIR[/ S][/ Q][drive:]path");
                    break;
                default: Console.Write($"{command} not found.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            HelpCommand cmd = new HelpCommand();
            if (args.Length == 0)
            {
                Shell shell = new Shell();
                Dictionary<string, string>.KeyCollection keys = shell.GetCommandDictionary().Keys;
                foreach (string key in keys)
                {
                    Console.Write("\n" + key.ToUpper());
                }
            }
            else
            {
                cmd.PrintInstrucctions(args[0]);
            }
        }
    }
}
