
namespace UmpireBot.Core.Play.Sports.Tennis
{
    public class Point
    {
        private Player winner;
        public Player Winner { get { return winner; } }
        public Point(Player winner)
        {
            this.winner = winner;
        }

    }
}
