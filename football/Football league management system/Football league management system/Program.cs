using System;

namespace Football_league_management_system
{
    class Program
    {
        static void Main()
        {
            Tournament tournament = new Tournament();
            ITeamManagement teamManager = tournament;
            IMatchManagement matchManager = tournament;
            EventManager eventManager = new EventManager();

            // 🔥 Subscribe to Events
            eventManager.OnTeamAdded += team => Console.WriteLine($"[Event] Team Added: {team.name}");
            eventManager.OnMatchScheduled += match => Console.WriteLine($"[Event] Match Scheduled: {match.Team1.name} vs {match.Team2.name}");
            eventManager.OnMatchResultUpdated += match => Console.WriteLine($"[Event] Match Result Updated: {match.Team1.name} {match.Score1} - {match.Score2} {match.Team2.name}");

            // Creating Teams
            Team teamA = new Team("Barcelona");
            Team teamB = new Team("Real Madrid");
            Team teamC = new Team("Manchester United");

            // Adding Teams to the Tournament
            Console.WriteLine(teamManager.AddTeam(teamA));
            eventManager.TriggerTeamAdded(teamA);

            Console.WriteLine(teamManager.AddTeam(teamB));
            eventManager.TriggerTeamAdded(teamB);

            Console.WriteLine(teamManager.AddTeam(teamC));
            eventManager.TriggerTeamAdded(teamC);

            // Scheduling Matches
            Console.WriteLine(matchManager.ScheduleMatch(teamA, teamB));
            eventManager.TriggerMatchScheduled(new Match(teamA, teamB));

            Console.WriteLine(matchManager.ScheduleMatch(teamA, teamC));
            eventManager.TriggerMatchScheduled(new Match(teamA, teamC));

            Console.WriteLine(matchManager.ScheduleMatch(teamB, teamC));
            eventManager.TriggerMatchScheduled(new Match(teamB, teamC));

            // Setting Match Results
            Console.WriteLine(matchManager.SetMatchResult(teamA, teamB, 2, 1)); // Barcelona wins
            eventManager.TriggerMatchResultUpdated(new Match(teamA, teamB));

            Console.WriteLine(matchManager.SetMatchResult(teamB, teamC, 3, 3)); // Draw
            eventManager.TriggerMatchResultUpdated(new Match(teamB, teamC));

            Console.WriteLine(matchManager.SetMatchResult(teamA, teamC, 1, 1)); // Draw
            eventManager.TriggerMatchResultUpdated(new Match(teamA, teamC));

            // Display Final Standings
            Console.WriteLine("\nFinal Standings:");
            tournament.DisplayTeams();

            Console.ReadLine(); // Prevent console from closing immediately
        }
    }
}
