using System;
using System.IO;
using System.Diagnostics;
using UmpireBot.Services.Simulation;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;

namespace UmpireBot.Services.Peer
{
    public class Peer : BackgroundService
    {
        Process outputProcess;

        FileSystemWatcher watcher;

        ISimulatable<MatchString> tennisSimulator;

        public Config Config { get; set; }


        public Peer(ISimulatable<MatchString> tennisSimulator, string inputFileName, string outputFileName)
        {
            Config = new Config(inputFileName, outputFileName);
            this.tennisSimulator = tennisSimulator;
            File.WriteAllText(Config.InputFilePath, Properties.Resources.Input);
            Process.Start("notepad.exe", Config.InputFilePath);
        }

        public Peer(ISimulatable<MatchString> tennisSimulator)
        {
            Config = new Config();
            this.tennisSimulator = tennisSimulator;
            File.WriteAllText(Config.InputFilePath, Properties.Resources.Input);
            Process.Start("notepad.exe", Config.InputFilePath);
        }

        public async Task ExportAsync()
        {
            if (File.Exists(Config.OutputFilePath))
            { File.Delete(Config.OutputFilePath); }

            foreach (string line in File.ReadLines(Config.InputFilePath))
            {
                try
                {
                    await File.AppendAllTextAsync(Config.OutputFilePath, tennisSimulator.RunAsync(new MatchString(line)).Result.Trim() + Environment.NewLine);
                }
                catch (Exception e)
                {
                    await File.AppendAllTextAsync(Config.OutputFilePath, e.Message.Trim() + Environment.NewLine);
                }
            }
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            if (e.Name == Path.GetFileName(Config.InputFilePath))
            {
                if (outputProcess != null)
                {
                    outputProcess.Kill();
                }
                Console.WriteLine($"Input file is changed.");
                ExportAsync().Wait();
                Console.WriteLine($"Output file is generated.");
                outputProcess = Process.Start("notepad.exe", Config.OutputFilePath);

            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            watcher = new FileSystemWatcher(Config.Folder);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += OnChanged;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;

            ExportAsync().Wait();
            Console.WriteLine($"Output file is generated for the very first time.");
            outputProcess = Process.Start("notepad.exe", Config.OutputFilePath);

            return;

        }
    }
}
