using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class HelpCommand : Command
    {
        protected void PrintInstrucctions(string command)
        {
            switch (command)
            {
                case "cd" :  CurrentDirectory cur = new CurrentDirectory();
                    cur.help();
                    break;
                case "dir" : ListDirectory listdir = new ListDirectory();
                    listdir.help();
                    break;
                case "md" : MakeDirectory makedir = new MakeDirectory();
                    makedir.help();
                    break;
                case "del dir" : DeleteDirectory deldir = new DeleteDirectory();
                    deldir.help();
                    break;
                case "help": HelpCommand cmd = new HelpCommand();
                    cmd.help();
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
                    Console.Write("\n" + key.ToUpper() + ":");
                    cmd.PrintInstrucctions(key.ToLower());
                }
            }
            else
            {
                cmd.PrintInstrucctions(args[0]);
            }
        }

        public void help()
        {
            Console.Write("Provides information about commands.");
        }
    }
}
