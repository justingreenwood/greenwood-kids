using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace BasketballRoster.ViewModel
{
    class RosterViewModel
    {        
        public ObservableCollection<PlayerViewModel> Starters { get; set; }
        public ObservableCollection<PlayerViewModel> Bench { get; set; }
        private Model.Roster _roster;

        private string _teamName;
        public string TeamName { get { return _teamName; } set { _teamName = value; } }
        public RosterViewModel(Model.Roster roster)
        {
           _roster = roster;
            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();

            TeamName = _roster.TeamName;
            UpdateRosters();
        }

        private void UpdateRosters()
        {
            var startingPlayers = _roster.Players.
                Where(player => player.Starter).
                Select(player => new PlayerViewModel(player.Number, player.Name));

            foreach(PlayerViewModel playerViewModel in startingPlayers)
            {
                Starters.Add(playerViewModel);
            }

            var benchPlayers = _roster.Players.
                Where(player => !player.Starter).
                Select(player => new PlayerViewModel(player.Number, player.Name));
            foreach (PlayerViewModel playerViewModel in benchPlayers)
            {
                Bench.Add(playerViewModel);
            }
        }

    }
}
