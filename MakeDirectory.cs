﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class MakeDirectory
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
    }
}
