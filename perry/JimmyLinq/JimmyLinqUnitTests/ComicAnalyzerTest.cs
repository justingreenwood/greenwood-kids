using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JimmyLinqUnitTests
{
    using JimmyLinq;
    using System.Linq;
    using System.Collections.Generic;

    [TestClass]
    public class ComicAnalyzerTest
    {
        IEnumerable<Comic> testComics = new[]
        {
            new Comic(){Issue = 1, Name = "Issue 1"},
            new Comic(){Issue = 2, Name = "Issue 2"},
            new Comic(){Issue = 3, Name = "Issue 3"},
        };


        [TestMethod]
        public void ComicAnalyerShouldGroupComics()
        {
            var prices = new Dictionary<int, decimal>()
            {
                { 1, 20M },
                { 2, 10M },
                { 3, 1000M },

            };

            var groups = ComicAnalyzer.GroupComicsByPrice(testComics, prices);

            Assert.AreEqual(2, groups.Count());
            Assert.AreEqual(PriceRange.Cheap,groups.First().Key);
            Assert.AreEqual(2, groups.First().First().Issue);
            Assert.AreEqual("Issue 2", groups.First().First().Name);

        }

        public void ComicAnalyzerShouldGenerateAListOfReviews()
        {

            var testReviews = new[]
            {
                new Review(){Issue = 1,Critic = Critics.MuddyCritic, Score = 14.5},
                new Review(){Issue = 1,Critic = Critics.RottenTornadoes, Score = 59.93},
                new Review(){Issue = 2,Critic = Critics.MuddyCritic, Score = 40.3},
                new Review(){Issue = 2,Critic = Critics.RottenTornadoes, Score = 95.11},
            };

            var expectedResults = new[]
            {
                "MuddyCritic rated #1 'Issue 1' 14.50",
                "RottenTornadoes rated #1 'Issue 1' 59.93",
                "MuddyCritic rated #2 'Issue 2' 40.30",
                "RottenTornadoes rated #2 'Issue 2' 95.11",
            };

            var actualResults = ComicAnalyzer.GetReviews(testComics, testReviews).ToList();
            CollectionAssert.AreEqual(expectedResults, actualResults);

        }


    }
}
