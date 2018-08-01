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
            new Standard(2003, CoreSet.Eight, Block.Odyssey, Block.Onslaught),
            new Standard(2004, CoreSet.Eight, Block.Onslaught, Block.Mirrodin),
            new Standard(2005, CoreSet.Ninth, Block.Kamigawa, Block.Ravnica.First()),
            new Standard(2006, CoreSet.Ninth, Block.Ravnica, Block.Coldsnap, Block.TimeSpiral.Where((s,i)=> i == 0 || i ==1).ToList()),
            new Standard(2007, CoreSet.Tenth, Block.Coldsnap, Block.TimeSpiral, Block.Lorwyn.First()),
            new Standard(2008, CoreSet.Tenth, Block.Lorwyn, Block.Shadowmoor, Block.Alara.First()),
            new Standard(2009, CoreSet.Magic2010, Block.Alara,  Block.Zendikar.First()),
            new Standard(2010, CoreSet.Magic2011, Block.Zendikar,  Block.ScarsOfMirrodin.First()),
            new Standard(2011, CoreSet.Magic2012, Block.ScarsOfMirrodin,  Block.Innistrad.First()),
            //there was no world championship with standard in 2012
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

        public Standard(int year, params IList<string>[] validCardSets)
            : this(year, validCardSets.SelectMany(v => v).ToList()) { }


        public Standard(int year, IList<string> coreSet, IList<string> block1, string block2First)
            : this(year, coreSet.Concat(block1).Concat(new List<string>() { block2First }).ToList()) { }

        public Standard(int year, IList<string> coreSet, IList<string> block1, IList<string> block2, string block3First)
    : this(year, coreSet.Concat(block1).Concat(block2).Concat(new List<string>() { block3First }).ToList()) { }

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
        public static IList<string> TimeSpiral = new List<string> { "Time Spiral", "Time Spiral \"Timeshifted\"", "Planar Chaos", "Future Sight" };
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
        public static IList<string> Fourth = new List<string> { "Fourth Edition" };
        public static IList<string> Fifth = new List<string> { "Fifth Edition" };
        public static IList<string> Six = new List<string> { "Classic Sixth Edition" };
        public static IList<string> Seven = new List<string> { "Seventh Edition" };
        public static IList<string> Eight = new List<string> { "Eighth Edition" };
        public static IList<string> Ninth = new List<string> { "Ninth Edition" };
        public static IList<string> Tenth = new List<string> { "Tenth Edition" };
        public static IList<string> Magic2010 = new List<string> { "Magic 2010", "2010 Core Set" };
        public static IList<string> Magic2011 = new List<string> { "Magic 2011", "2011 Core Set" };
        public static IList<string> Magic2012 = new List<string> { "Magic 2012", "2012 Core Set" };
        public static IList<string> Magic2013 = new List<string> { "Magic 2013", "2013 Core Set" };
        public static IList<string> Magic2014 = new List<string> { "Magic 2014", "2014 Core Set" };
        public static IList<string> Magic2015 = new List<string> { "Magic 2015", "2015 Core Set" };
        public static IList<string> MagicOrigins = new List<string> { "Magic Origins" };
        public static IList<string> CoreSet2019 = new List<string> { "Core Set 2019" };
    }
}
