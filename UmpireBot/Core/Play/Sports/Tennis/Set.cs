using System;
using System.Collections.Generic;

namespace UmpireBot.Core.Play.Sports.Tennis
{
    class Set : Playable<Point>
    {
        public List<Game> Games;
        private Game currentGame;
        string finishedSetScores;

        public Set(Player playerA, Player playerB) {

            this.playerA = playerA;
            this.playerB = playerB;

            Games = new List<Game>();
            Points = new List<Point>();
            State = State.Ongoing;
        }
        public override void AddPoint(Point point)
        {
            base.AddPoint(point);

            if (Games.Count == 0 || currentGame.State == State.Finished)
            {
                currentGame= new Game(playerA, playerB);
                Games.Add(currentGame);
            }

            if (currentGame.State == State.Ongoing)
            {
                currentGame.AddPoint(point);
            }

            if (currentGame.State == State.Finished)
            {
                Points.Add(new Point(currentGame.Winner));
            }

            playerARaw = Points.FindAll(a => a.Winner == playerA).Count;
            playerBRaw = Points.FindAll(a => a.Winner == playerB).Count;

            if ((playerARaw == 6 && playerBRaw == 0)|
                (playerARaw == 0 && playerBRaw == 6)|
                ((playerARaw >= 6 || playerBRaw >= 6) & Math.Abs(playerARaw - playerBRaw) >= 2))
            {
                finishedSetScores = finishedSetScores + " " + ScoreBoard().Split(" ")[0];
                State = State.Finished;
                winner = playerARaw > playerBRaw ? playerA : playerB;
            }

        }

        public override string ScoreBoard()
        {
                return   ScoreConverter.CreateBoard(playerARaw, playerBRaw) + " " + currentGame.ScoreBoard(); 
        }



    }
}
