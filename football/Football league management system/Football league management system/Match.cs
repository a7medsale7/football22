using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_league_management_system
{
    class Match 
    {
        public Match(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
            team1Goals = 0;
            team2Goals = 0;
        }

        int team1Goals, team2Goals;
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }
        public int Score1
        {
            get { return team1Goals; }
            private set
            {
                team1Goals = value;
            }
        }
        public int Score2
        {
            get { return team2Goals; }
            private set
            {
                team2Goals = value;
            }
        }
        public string Winner
        {
            get
            {
                if (team1Goals > team2Goals)
                    return Team1.name;
                else if (team2Goals > team1Goals)
                    return Team2.name;
                else
                    return "Draw";
            }
        }
        private bool isResultSet = false;

        public void SetMatchResult(int goals1, int goals2)
        {
            if (isResultSet)
            {
                Console.WriteLine("Match result has already been set!");
                return;
            }

            Score1 = goals1;
            Score2 = goals2;

            Team1.UpdateStats(goals1, goals2);
            Team2.UpdateStats(goals2, goals1);

            isResultSet = true; 
        }

       
    }
}
