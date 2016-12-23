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
            { "dir", @".\ListDirectory.exe"}
        };

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
                    argument = inputs[1];
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
