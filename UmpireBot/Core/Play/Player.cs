
namespace UmpireBot.Core.Play
{
    public class Player
    {
        protected string name;
        public Player(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name; 
        }

    }
}
