using System.Threading.Tasks;

namespace UmpireBot.Services
{


    public delegate void Notification();
    public interface ISimulatable <T>
    {
        public event Notification Started;
        public event Notification Terminated;

        public void Initialise();
        public Task<string> RunAsync(T RunParams) ;
        public Task<string> Run(T RunParams);
        public void OnStarted();
        public void OnTerminated();


    }
}
