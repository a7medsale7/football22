using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_league_management_system
{
    class Tournament : IMatchManagement , ITeamManagement
    {
       public List<Team> teams = new List<Team>();
       public List<Match> matches = new List<Match>();

        public IEnumerable<Team> Teams
        {
            get { return teams.AsReadOnly(); }
        }
        public IEnumerable<Match> Matches
        {
            get { return matches.AsReadOnly(); }

        }



        public string GetTeamInfo(Team team)
        {
            if (teams.Contains(team))
            {
                return team.GetTeamInfo(); // Call the method from the `Team` class
            }
            else return "The team does not exist!";
        }


        public string RemoveTeam(Team team)
        {
            if (teams.Contains(team))
            {
                teams.Remove(team);
                return $"Team {team.name} removed successfully!";
            }
            else
            {
                return "The team does not exist!";
            }
        }





        public string SetMatchResult(Team team1, Team team2, int goals1, int goals2)
        {
            Match match = null;

            foreach (var m in matches)
            {
                if ((m.Team1 == team1 && m.Team2 == team2) || (m.Team1 == team2 && m.Team2 == team1))
                {
                    match = m;
                    break;
                }
            }

            if (match == null)
            {
                return "Match not found!";
            }

            match.SetMatchResult(goals1, goals2);

            string winner = match.Winner;

            return $"Match result set: {team1.name} {goals1} - {goals2} {team2.name} | Winner: {winner}";
        }


        string ITeamManagement.AddTeam(Team team)
        {
            if (!teams.Contains(team))
            {
                teams.Add(team);
                return $"Team {team.name} Added successfully!";
            }
            else return"the team already exist!!";
        }

        string IMatchManagement.ScheduleMatch(Team team1, Team team2)
        {
            if (teams.Contains(team1) && teams.Contains(team2))
            {
                matches.Add(new Match(team1, team2));
                return $"the match has been added ";
            }
            else
            {
                return "One or both teams are not in the tournament!";
            }
        }
        public void DisplayTeams()
        {
            foreach (var team in teams.OrderByDescending(t => t.Points))
            {
                Console.WriteLine(team.GetTeamInfo());
            }
        }
    }
}
