using System;
using System.Collections.Generic;
using UmpireBot.Core.Play.Sports.Tennis;

namespace UmpireBot.Core.Play
{
    public enum State
    {
        Ongoing,
        Finished
    }

    public abstract class Playable<T>
    {
        
        protected Player playerA, playerB, winner;
        public int playerARaw, playerBRaw;

        public State State;
        public List<Point> Points;
        public Player Winner { get { return winner; } }
        public virtual void AddPoint(T point) {
            if (this.State == State.Finished)
            {
                throw new Exception($"Can't add Points to a Playable object of type {this.GetType()} when State = State.Finished.");
            }
        }

        public abstract string ScoreBoard();

    }
}
