
namespace UmpireBot.Core.Play.Sports.Tennis
{
    public static class ScoreConverter
    {
        public static bool PlayerAServing { get; set; }
        public static string CreateBoard(int playerAScore, int playerBScore)
        {
            int serverScore = PlayerAServing ? playerAScore : playerBScore;
            int receiverScore = PlayerAServing ? playerBScore : playerAScore;

            return serverScore.ToString() + "-" + receiverScore.ToString();
        }
        public static string CreateBoard(int playerAScore , int playerBScore, Player playerA , Player playerB)
        {
            int serverScore = PlayerAServing ? playerAScore : playerBScore;
            int receiverScore = PlayerAServing ? playerBScore : playerAScore;

            string serverName = PlayerAServing ? playerA.ToString() : playerB.ToString();
            string  receiverName = PlayerAServing ? playerB.ToString() : playerA.ToString();

            if (serverScore == receiverScore && serverScore >=3)
            {
                    return "40-40";
            }

            if (serverScore < 4 && receiverScore < 4)
            {
                return (ScoreCall(serverScore) + "-" + ScoreCall(receiverScore));
            }
            else
            {
                if (serverScore == receiverScore + 1)
                {
                    return "A-40";
                }
                else if (receiverScore == serverScore + 1)
                {
                    return "40-A";
                }
            }

            return "";
        }

         static string ScoreCall(int score)
        {
            switch (score) {
                case 0:
                    return "0";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "40";
                default:
                    return "";
            }
            
        }

    }
}
