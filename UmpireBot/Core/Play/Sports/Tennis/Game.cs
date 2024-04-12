using System;
using System.Collections.Generic;

namespace UmpireBot.Core.Play.Sports.Tennis
{
    class Game : Playable<Point>
    {
        public List<Point> Points;
        public Game(Player playerA, Player playerB)
        {
            this.playerA = playerA;
            this.playerB = playerB;

            Points = new List<Point>();
            State = State.Ongoing;
        }
        public override void AddPoint(Point point)
        {
            base.AddPoint(point);

            Points.Add(point);

            playerARaw= Points.FindAll(a => a.Winner == playerA).Count;
            playerBRaw = Points.FindAll(a => a.Winner == playerB).Count;

            if ((playerARaw == 4  && playerBRaw == 0) ||
                (playerARaw == 0 && playerBRaw == 4) ||
                ( (playerARaw>4 || playerBRaw>4) &  Math.Abs(playerARaw-playerBRaw) >= 2))
            {
                ScoreConverter.PlayerAServing = !ScoreConverter.PlayerAServing;
                State = State.Finished;
                winner = playerARaw > playerBRaw ? playerA : playerB;
            }
        }

        public override string ScoreBoard()
        {
            return ScoreConverter.CreateBoard(playerARaw, playerBRaw, playerA , playerB);

        }

    }
    
}
