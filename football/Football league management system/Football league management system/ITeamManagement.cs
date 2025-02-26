using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_league_management_system
{
    interface ITeamManagement
    {
        string AddTeam(Team team); 
        string GetTeamInfo(Team team);

    }
}
