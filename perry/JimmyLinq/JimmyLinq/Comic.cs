using System;
using System.Collections.Generic;
using System.Text;

namespace JimmyLinq
{
    public class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public override string ToString() => $"{Name} (Issue#{Issue})";
        public static readonly IEnumerable<Comic> Catalog =
            new List<Comic>
            {
                new Comic { Name = "Crumbled Cookies",Issue = 6},
                new Comic { Name = "Brussel Sprouts (limited edition)",Issue = 19},
                new Comic { Name = "Lasagna vs. Chicken Pot Pie",Issue = 36},
                new Comic { Name = "The Rise of the Vegetables (misprinted)",Issue = 57},
                new Comic { Name = "Burned To a Crisp (burned)",Issue = 68},
                new Comic { Name = "Sweet Defeat",Issue = 74},
                new Comic { Name = "Beaten And Whipped",Issue = 83},
                new Comic { Name = "End of the Feast",Issue = 97},

            };
        public static readonly IReadOnlyDictionary<int, decimal> Prices =
            new Dictionary<int, decimal>
            {
                { 6, 3600M },
                { 19, 500M },
                { 36, 650M },
                { 57, 13525M },
                { 68, 250M },
                { 74, 75M },
                { 83, 25.75M },
                { 97, 35.25M },

            };
        public static readonly IEnumerable<Review> Reviews = new[]
        {
            new Review() {Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6},
            new Review() {Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8},
            new Review() {Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2},
            new Review() {Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4},
            new Review() {Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1},
        };





    }
}
