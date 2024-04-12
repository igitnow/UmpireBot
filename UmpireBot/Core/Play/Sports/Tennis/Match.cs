using System;
using System.Collections.Generic;

namespace UmpireBot.Core.Play.Sports.Tennis
{
    class Match : Playable<Point>
    {
        private const int minSetToWin = 3;
        
        private Set currentSet;
        public List<Set> Sets;
        public string Comments;

        public Match(Player playerA, Player playerB)
        {
            ScoreConverter.PlayerAServing = true;

            this.playerA = playerA;
            this.playerB = playerB;

            Sets = new List<Set>();
            Points = new List<Point>();

            State = State.Ongoing;
        }

        public override void AddPoint(Point point)
        {
            if(State == State.Finished)
            {
                Comments = " --One or more points could not be added due to Match termination.";
                return;
            }

            if (Sets.Count == 0)
            {
                currentSet = new Set(playerA, playerB); Sets.Add(currentSet);
            }

            if (currentSet.State == State.Finished)
            {
                currentSet = new Set(playerA, playerB); Sets.Add(currentSet);
            }

            if (currentSet.State == State.Ongoing)
            {
                currentSet.AddPoint(point);
            }

            if (currentSet.State == State.Finished)
            {
                Points.Add(new Point(currentSet.Winner));
            }

            playerARaw = Points.FindAll(a => a.Winner == playerA).Count;
            playerBRaw = Points.FindAll(a => a.Winner == playerB).Count;

            if (playerARaw + playerBRaw == minSetToWin)
            {
                winner = playerARaw > playerBRaw ? playerA : playerB;
                State = State.Finished;
            }

        }

        public override string ScoreBoard()
        {
            string finishedSets = string.Empty;

            if (winner != null)
            {
                Comments += " --Winner:" + winner.ToString();
            }

            foreach (Set set in Sets)
            {
                if (set.State == State.Finished)
                finishedSets+= ScoreConverter.CreateBoard(set.playerARaw, set.playerBRaw) +" ";
            }

            if (currentSet == null || currentSet.State == State.Finished)
            {
                return finishedSets + "0-0" + Comments;
            }
            else
            {
                if (String.IsNullOrEmpty(finishedSets))
                {
                    return currentSet.ScoreBoard() + Comments;
                }
                else
                {
                    return finishedSets + currentSet.ScoreBoard() + Comments;
                }

            }

        }

    }
}
