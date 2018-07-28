using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// had dificult deciding between static and instace. Instace would give me trouble having to select by name to buil the years

namespace MtgExtensionAppender
{
    static class WorldChampionship
    {
        public static IList<Standard> Standards { get; set; } = new List<Standard> {
            new Standard(1998, AgregateListOfCardSets(Block.Mirage, Block.Tempest, CoreSet.Fifth)),
            new Standard(1999, AgregateListOfCardSets(Block.Tempest, Block.Urza, CoreSet.Six)),

            new Standard(2000, AgregateListOfCardSets(Block.Urza, Block.Masques, CoreSet.Six)),
            new Standard(2001, AgregateListOfCardSets(Block.Masques, Block.Invasion, CoreSet.Seven)),
            new Standard(2002, AgregateListOfCardSets(Block.Invasion, Block.Odyssey, CoreSet.Seven))
            };

        private static IList<string> AgregateListOfCardSets(IList<string> firstExpansion, IList<string> secondExpansion, string coreSet)
        {
            var list = new List<string>() { coreSet };
            list.AddRange(firstExpansion);
            list.AddRange(secondExpansion);
            return list;
        }
    }

    class Standard
    {
        public int Year { get; set; }
        public IList<string> ValidCardSets { get; set; }

        public Standard(int year, IList<string> validCardSets)
        {
            Year = year;
            ValidCardSets = validCardSets;
        }
    }

    static class Block
    {
        public static IList<string> Mirage = new List<string> { "Mirage", "Visions", "Weatherlight" };
        public static IList<string> Tempest = new List<string> { "Urza's Saga", "Urza's Legacy", "Urza's Destiny" };
        public static IList<string> Urza = new List<string> { "Tempest", "Stronghold", "Exodus" };
        public static IList<string> Masques = new List<string> { "Mercadian Masques", "Nemesis", "Prophecy" };
        public static IList<string> Invasion = new List<string> { "Invasion", "Planeshift", "Apocalypse" };
        public static IList<string> Odyssey = new List<string> { "Odyssey", "Torment", "Judgment" };
    }

    static class CoreSet
    {
        public static string Fourth = "Fourth Edition";
        public static string Fifth = "Fifth Edition";
        public static string Six = "Classic Sixth Edition";
        public static string Seven = "Seventh Edition";
        public static string Eight = "Eighth Edition";
    }
}
