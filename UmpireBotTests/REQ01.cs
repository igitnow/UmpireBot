using Microsoft.VisualStudio.TestTools.UnitTesting;
using UmpireBot;
using UmpireBot.Services.Peer;
using UmpireBot.Services.Simulation;
using System.Diagnostics;
using System.IO;

namespace UmpireBotTests
{
    [TestClass]
    public class REQ00
    {
        [TestMethod]
        public void TestMethod()
        {
            TennisSimulator tennisSimulator = new TennisSimulator();
            
            Peer peer = new Peer(tennisSimulator, "Input.txt", "Output.txt");
            peer.ExportAsync().Wait();

            Process.Start("notepad.exe",  peer.Config.OutputFilePath);

            string Obtained_output = File.ReadAllText(peer.Config.OutputFilePath);
            string Expected_output = Properties.Resources.Output;

            Assert.IsTrue(string.Equals(Obtained_output , Expected_output));
        }
    }
}
