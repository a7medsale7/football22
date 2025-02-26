using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_league_management_system
{
    interface IMatchManagement
    {
        string SetMatchResult(Team team1, Team team2, int goals1, int goals2);
        string ScheduleMatch(Team team1, Team team2);
        string RemoveTeam(Team team);
    }
}
