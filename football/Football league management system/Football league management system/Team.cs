using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_league_management_system
{
    class Team : IComparable<Team>
    {
        public string name { get; }
        public Team(string Name)
        {
            name = Name;
        }

        int wins, losses, draws, points;

        public int Wins
        {
            get { return wins; }

            private set
            {
                wins = value;
            }
        }
        public int Losses
        {
            get { return losses; }

            private set
            {
                losses = value;
                
            }
        }
        public int Draws
        {
            get { return draws; }

            private set
            {
                draws = value;
            }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Team Name { get; private set; }

        public void UpdateStats(int goalsFor, int goalsAgainst)
        {
            if (goalsFor > goalsAgainst)
            {
                wins++;
                Points += 3; 
            }
            else if (goalsFor < goalsAgainst)
            {
                losses++;
            }
            else
            {
                draws++;
                Points += 1; 
            }
        }

        public string GetTeamInfo()
        {
            return $"The name of team is :{name}\n the points are :{Points}\n Wins : {Wins} , Draws : {Draws} , Loses : {Losses}";
        }
        public int CompareTo(Team other)
        {
            return other.Points.CompareTo(this.Points);
        }

    }
}
