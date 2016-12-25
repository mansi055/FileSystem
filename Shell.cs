using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class Shell
    {
        private Dictionary<string, string> commandsDictionary = new Dictionary<string, string>()
        {
            { "md", @".\MakeDirectory.exe"},
            { "dir", @".\ListDirectory.exe"},
            { "cd", @".\CurrentDirectory.exe"},
            { "deldir", @".\DeleteDirectory.exe"},
            { "help", @".\HelpCommand.exe"}
        };
        
        public Dictionary<string, string> GetCommandDictionary()
        {
            return commandsDictionary;
        }

        public int execute(string input)
        {
            try
            {
                string[] inputs = input.Split(' ');
                string command = inputs[0];
                string argument = null;

                if (inputs.Length == 0)
                {
                    return 0;
                }
                
                if (inputs.Length == 2)
                {
                    if (inputs[0].Equals("del") && inputs[1].Equals("dir"))
                    {
                        argument = "";
                    }
                    else
                    {
                        argument = PathInfo.IsRooted(inputs[1]) ? PathInfo.GetCorrectPath(inputs[1]) : inputs[1];
                   }
                }

                else if (inputs.Length == 3 && inputs[0].Equals("del"))
                {
                    argument = PathInfo.IsRooted(inputs[2]) ? PathInfo.GetCorrectPath(inputs[2]) : inputs[2];
                    command = inputs[0] + inputs[1];
                }
                else
                {
                    argument = "";
                }

                if (commandsDictionary.Keys.Contains(command))
                {
                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo(commandsDictionary[command])
                    {
                        UseShellExecute = false,
                        Arguments = argument
                    };

                    process.Start();
                    process.WaitForExit();

                    return 0;
                }

                Console.WriteLine($"{command} not found");
                return 1;

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return 0;
        }
    }
}
