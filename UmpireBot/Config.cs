using System.Configuration;
using System.IO;

namespace UmpireBot
{
    public class Config
    {
        private  string inputFileName, outputFileName;
        private  string inputFilePath, outputFilePath;
        private  string folder;


        public  string Folder { get { return folder; } }
        public string InputFileName { get { return inputFileName; } }
        public string OutputFileName { get { return outputFileName; } }
        public string InputFilePath { get { return inputFilePath; } }
        public string OutputFilePath { get { return outputFilePath; } }

         public Config()
        {
            folder = System.IO.Directory.GetCurrentDirectory();
            inputFileName = ConfigurationManager.AppSettings["InputFileName"];
            outputFileName = ConfigurationManager.AppSettings["OutputFileName"];
            inputFilePath = Path.Combine(folder, inputFileName);
            outputFilePath = Path.Combine(folder, outputFileName);

        }

        public Config(string inputFileName , string outputFileName)
        {
            folder = System.IO.Directory.GetCurrentDirectory();
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
            inputFilePath = Path.Combine(folder, inputFileName);
            outputFilePath = Path.Combine(folder, outputFileName);

        }




    }
}
