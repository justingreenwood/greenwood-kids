using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballRoster;
using BasketballRoster.Model;
using System.Collections.ObjectModel;

namespace BasketballRoster.ViewModel
{
    class LeagueViewModel
    {
        public RosterViewModel JimmysTeam { get; set; }
        public RosterViewModel AnasTeam { get; set; }
        public LeagueViewModel()
        {
            var anasRoster = new Roster("The Bombers", GetBomberPlayers());
            AnasTeam = new RosterViewModel(anasRoster);
            var jimmysRoster = new Roster("The Amazings", GetAmazingPlayers());
            JimmysTeam = new RosterViewModel(jimmysRoster);
        }

        private IEnumerable<Player> GetBomberPlayers()
        {
            return new List<Player>() 
            { 
                new Player("Ana",31,true),
                new Player("Abby",23,true),
                new Player("Aria",6,true),
                new Player("Andromeda",0,true),
                new Player("Amy",42,true),
                new Player("Amelia",32,false),
                new Player("Aurora",8,false),

            };
        }
        private IEnumerable<Player> GetAmazingPlayers()
        {
            return new List<Player>()
            {
                new Player("Jimmy",42,true),
                new Player("John",11,true),
                new Player("Jack",4,true),
                new Player("Jefferson",18,true),
                new Player("James",16,true),
                new Player("Jordan",23,false),
                new Player("Joe",21,false),

            };
        }



    }
}
