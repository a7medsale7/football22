using System;

namespace Football_league_management_system
{
    class EventManager
    {
        // 🔥 Define Delegates
        public delegate void TeamAddedHandler(Team team);
        public delegate void TeamRemovedHandler(Team team);
        public delegate void MatchScheduledHandler(Match match);
        public delegate void MatchResultUpdatedHandler(Match match);

        // 🔥 Define Events
        public event TeamAddedHandler? OnTeamAdded;
        public event TeamRemovedHandler? OnTeamRemoved;
        public event MatchScheduledHandler? OnMatchScheduled;
        public event MatchResultUpdatedHandler? OnMatchResultUpdated;

        // 🔥 Methods to Trigger Events
        public void TriggerTeamAdded(Team team) => OnTeamAdded?.Invoke(team);
        public void TriggerTeamRemoved(Team team) => OnTeamRemoved?.Invoke(team);
        public void TriggerMatchScheduled(Match match) => OnMatchScheduled?.Invoke(match);
        public void TriggerMatchResultUpdated(Match match) => OnMatchResultUpdated?.Invoke(match);
    }
}
