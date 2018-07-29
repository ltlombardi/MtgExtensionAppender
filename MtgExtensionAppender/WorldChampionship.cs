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
            new Standard(1998, CoreSet.Fifth, Block.Mirage, Block.Tempest),
            new Standard(1999, CoreSet.Six, Block.Tempest, Block.Urza),
            new Standard(2000, CoreSet.Six, Block.Urza, Block.Masques),
            new Standard(2001, CoreSet.Seven,  Block.Masques, Block.Invasion),
            new Standard(2002, CoreSet.Seven, Block.Invasion, Block.Odyssey),
            new Standard(2003, CoreSet.Seven, Block.Odyssey, Block.Onslaught),
            new Standard(2004, CoreSet.Eight, Block.Onslaught, Block.Mirrodin),
            new Standard(2005, CoreSet.Ninth, Block.Kamigawa, Block.Ravnica.First()),
            new Standard(2006, CoreSet.Ninth, Block.Ravnica, Block.Coldsnap, Block.TimeSpiral.First()),
            new Standard(2007, CoreSet.Tenth, Block.Coldsnap, Block.TimeSpiral, Block.Lorwyn.First()),
            new Standard(2008, CoreSet.Tenth, Block.Lorwyn, Block.Shadowmoor, Block.Alara.First()),
            new Standard(2009, CoreSet.Magic2010, Block.Alara,  Block.Zendikar.First()),
            new Standard(2010, CoreSet.Magic2011, Block.Zendikar,  Block.ScarsOfMirrodin.First()),
            new Standard(2011, CoreSet.Magic2012, Block.ScarsOfMirrodin,  Block.Innistrad.First()),
            //there was no world championship with standar in 2012
            new Standard(2013, CoreSet.Magic2013, Block.Innistrad, Block.ReturnToRavnica, CoreSet.Magic2014),
            new Standard(2014, CoreSet.Magic2015, Block.Theros, Block.KhansOfTarkir.First()),
            new Standard(2015, CoreSet.Magic2015, Block.Theros, Block.KhansOfTarkir, CoreSet.MagicOrigins),
            new Standard(2016, CoreSet.MagicOrigins, new List<string> (){ Block.KhansOfTarkir.Last() }, Block.BattleForZendikar, Block.ShadowsOverInnistrad ),
            new Standard(2017, Block.Kaladesh, Block.Amonkhet, Block.Ixalan.First()),
            };

    }

    class Standard
    {
        public int Year { get; set; }
        public IList<string> ValidCardSets { get; private set; }

        public Standard(int year, IList<string> validCardSets)
        {
            Year = year;
            ValidCardSets = validCardSets;
        }

        public Standard(int year, string coreSet, params IList<string>[] validCardSets)
        {
            Year = year;
            var list = new List<string>() { coreSet };
            foreach (var i in validCardSets) list.AddRange(i);
            ValidCardSets = list;
        }


        public Standard(int year, IList<string> block1, IList<string> block2, string block3First) // No coreSet in 2017
        {
            Year = year;
            var list = new List<string>() { block3First };
            list.AddRange(block1);
            list.AddRange(block2);
            ValidCardSets = list;
        }

        public Standard(int year, string coreSet, IList<string> block1, string block2First) // 2005, 2009-2011, 2014
        {
            Year = year;
            var list = new List<string>() { coreSet, block2First };
            list.AddRange(block1);
            ValidCardSets = list;
        }

        public Standard(int year, string coreSet, IList<string> block1, IList<string> block2, string block3FirstORCoreSet2) // 2006-2008, 2013, 2015
        {
            Year = year;
            var list = new List<string>() { coreSet, block3FirstORCoreSet2 };
            list.AddRange(block1);
            list.AddRange(block2);
            ValidCardSets = list;
        }
    }

    static class Block
    {
        public static IList<string> Mirage = new List<string> { "Mirage", "Visions", "Weatherlight" };
        public static IList<string> Tempest = new List<string> { "Tempest", "Stronghold", "Exodus" };
        public static IList<string> Urza = new List<string> { "Urza's Saga", "Urza's Legacy", "Urza's Destiny" };
        public static IList<string> Masques = new List<string> { "Mercadian Masques", "Nemesis", "Prophecy" };
        public static IList<string> Invasion = new List<string> { "Invasion", "Planeshift", "Apocalypse" };
        public static IList<string> Odyssey = new List<string> { "Odyssey", "Torment", "Judgment" };
        public static IList<string> Onslaught = new List<string> { "Onslaught", "Legions", "Scourge" };
        public static IList<string> Mirrodin = new List<string> { "Mirrodin", "Darksteel", "Fifth Dawn" };
        public static IList<string> Kamigawa = new List<string> { "Champions of Kamigawa", "Betrayers of Kamigawa", "Saviors of Kamigawa" };
        public static IList<string> Ravnica = new List<string> { "Ravnica: City of Guilds", "Guildpact", "Dissension" };
        public static IList<string> Coldsnap = new List<string> { "Coldsnap" };
        public static IList<string> TimeSpiral = new List<string> { "Time Spiral", "Planar Chaos", "Future Sight" };
        public static IList<string> Lorwyn = new List<string> { "Lorwyn", "Morningtide" };
        public static IList<string> Shadowmoor = new List<string> { "Shadowmoor", "Eventide" };
        public static IList<string> Alara = new List<string> { "Shards of Alara", "Conflux", "Alara Reborn" };
        public static IList<string> Zendikar = new List<string> { "Zendikar", "Worldwake", "Rise of the Eldrazi" };
        public static IList<string> ScarsOfMirrodin = new List<string> { "Scars of Mirrodin", "Mirrodin Besieged", "New Phyrexia" };
        public static IList<string> Innistrad = new List<string> { "Innistrad", "Dark Ascension", "Avacyn Restored" };
        public static IList<string> ReturnToRavnica = new List<string> { "Return to Ravnica", "Gatecrash", "Dragon's Maze" };
        public static IList<string> Theros = new List<string> { "Theros", "Born of the Gods", "Journey into Nyx" };
        public static IList<string> KhansOfTarkir = new List<string> { "Khans of Tarkir", "Fate Reforged", "Dragons of Tarkir" };
        public static IList<string> BattleForZendikar = new List<string> { "Battle for Zendikar", "Oath of the Gatewatch" };
        public static IList<string> ShadowsOverInnistrad = new List<string> { "Shadows over Innistrad", "Eldritch Moon" };
        public static IList<string> Kaladesh = new List<string> { "Kaladesh", "Aether Revolt" };
        public static IList<string> Amonkhet = new List<string> { "Amonkhet", "Hour of Devastation" };
        public static IList<string> Ixalan = new List<string> { "Ixalan", "Rivals of Ixalan" };
    }

    static class CoreSet
    {
        public static string Fourth = "Fourth Edition";
        public static string Fifth = "Fifth Edition";
        public static string Six = "Classic Sixth Edition";
        public static string Seven = "Seventh Edition";
        public static string Eight = "Eighth Edition";
        public static string Tenth = "Ninth Edition";
        public static string Ninth = "Tenth Edition";
        public static string Magic2010 = "Magic 2010";
        public static string Magic2011 = "Magic 2011";
        public static string Magic2012 = "Magic 2012";
        public static string Magic2013 = "Magic 2013";
        public static string Magic2014 = "Magic 2014";
        public static string Magic2015 = "Magic 2015";
        public static string MagicOrigins = "Magic Origins";
        public static string CoreSet2019 = "Core Set 2019";
    }
}
