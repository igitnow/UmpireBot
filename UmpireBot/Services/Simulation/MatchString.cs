using System;
using System.Linq;

namespace UmpireBot.Services.Simulation
{
    public class MatchString
    {
        private string matchString;
        public MatchString(string matchString)
        {

            if (matchString.Select(x => x != 'B' && x != 'A').Where(x=>x==true).Any())
                throw new Exception($"{matchString} is invalid. MatchString can only containt letters A and/or B.");

                    this.matchString = matchString;
        }

        public override string ToString()
        {
            return matchString;
        }

    }
}
