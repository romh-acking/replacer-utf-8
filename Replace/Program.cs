using System;
using System.IO;
using System.Text;

namespace Replace
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Parameters:");
                Console.WriteLine(" 1. Path of find:replace file.");
                Console.WriteLine(" 2. Directory to replace contents of txt files or single txt file.");
            }

            var findReplaceFile = args[0];
            var txtFileOrDir = args[1];

            if (!File.Exists(findReplaceFile))
            {
                Console.WriteLine("Find replace file doesn't exist.");
                Environment.Exit(1);
            }

            var a = File.ReadAllText(findReplaceFile, Encoding.UTF8);
            a = a.Replace("\\n", "\n");
            var frLines = a.Split(Environment.NewLine);

            if (Directory.Exists(txtFileOrDir))
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(txtFileOrDir));
                ReplaceDirecory(txtFileOrDir, frLines);
            }
            else if (File.Exists(txtFileOrDir))
            {
                ReplaceFile(txtFileOrDir, frLines);
            }
            else
            {
                Console.WriteLine(".txt directory or file doesn't exist.");
                Environment.Exit(1);
            }

            Console.WriteLine("Replaced successfully.");
        }

        private static void ReplaceDirecory(string txtFileDir, string[] replaceLines)
        {
            foreach (var file in Directory.GetFiles(txtFileDir, "*.txt"))
            {
                ReplaceFile(file, replaceLines);
            }
        }

        private static void ReplaceFile(string file, string[] replaceLines)
        {
            foreach (var e in replaceLines)
            {
                if (!e.Contains("::"))
                {
                    continue;
                }
                var splitted = e.Split("::", 2);
                File.WriteAllText(file, File.ReadAllText(file).Replace(splitted[0], splitted[1]));
            }
        }
    }
}
