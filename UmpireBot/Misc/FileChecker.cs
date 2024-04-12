using System;
using System.IO;

namespace UmpireBot.Misc
{
    static class FileChecker
    {
        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        public static void Evaluate(Config Config)
        {
            Console.WriteLine($"Input file expected at {Config.InputFilePath}");
            Console.WriteLine($"Output file expected at {Config.OutputFilePath}");

            if (File.Exists(Config.InputFilePath))
            {
                if (FileChecker.IsFileLocked(new FileInfo(Config.InputFilePath)))
                {
                    throw new Exception("File: " + Config.InputFilePath + " could not be accessed. Please close it if opened and try again.");
                }
                else
                {
                    Console.WriteLine("Input file accessible.");
                }
            }

            if (File.Exists(Config.OutputFilePath))
            {
                if (FileChecker.IsFileLocked(new FileInfo(Config.OutputFilePath)))
                {
                    throw new Exception("File: " + Config.OutputFilePath + " could not be accessed. Please close it if opened and try again.");
                }
                else
                {
                    Console.WriteLine("Output file accessible.");
                }
            }

        }
    }
}
