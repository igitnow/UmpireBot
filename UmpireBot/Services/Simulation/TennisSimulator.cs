using System.Threading.Tasks;
using UmpireBot.Core.Play;
using UmpireBot.Core.Play.Sports.Tennis;

namespace UmpireBot.Services.Simulation
{
    public enum State
    {
        Created,
        Initialised,
        Running,
        Terminated
    }

    public class TennisSimulator : ISimulatable<MatchString>
    {
        private State state;
        
        public event Notification Started;
        public event Notification Terminated;
        public State State { get { return state; }}
        public TennisSimulator()
        {
            state = State.Created;
        }
        public void Initialise()
        {
            state = State.Initialised;
        }

        public async Task<string> RunAsync(MatchString matchString )
        {
            OnStarted();
            return await Run(matchString);
        }

        public Task<string> Run(MatchString matchString)
        {
            Player PlayerA = new Player("A");
            Player PlayerB = new Player("B");

            Match m = new Match(PlayerA, PlayerB);

            foreach (char c in matchString.ToString())
            {
                if (c.ToString() == PlayerA.ToString())
                {
                    m.AddPoint(new Point(PlayerA));
                }
                if (c.ToString() == PlayerB.ToString())
                {
                    m.AddPoint(new Point(PlayerB));
                }
            }

            OnTerminated();

            return Task.FromResult(m.ScoreBoard());
        }

        public void OnStarted()
        {
            state = State.Running;
            Started?.Invoke();
        }

        public void OnTerminated()
        {
            state = State.Terminated;
            Terminated?.Invoke();
        }




    }
}
