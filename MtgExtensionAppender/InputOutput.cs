using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgExtensionAppender
{
    static class InputOutput
    {
        public static IList<string> AskUserForCardSets()
        {
            int MaxYear = WorldChampionship.Standards.Select(s => s.Year).Max();
            int MinYear = WorldChampionship.Standards.Select(s => s.Year).Min();

            Console.WriteLine("Type the world championship year to define allowed card sets in Standard Format." +
                "\nA Tappedout.net compatible Card set code will be added to the cards in the deck.");
            Console.WriteLine("Supported years: ");
            var firstOptionNumber = 1;
            for (int i = 0; i < WorldChampionship.Standards.Count; i++)
            {
                Console.WriteLine(".Year " + WorldChampionship.Standards[i].Year);
            }
            int selectedOption;

            while (!int.TryParse(Console.ReadLine(), out selectedOption)
                || selectedOption > MaxYear
                || selectedOption < MinYear)
            {
                Console.WriteLine("Invalid option. Planeswalkers can't seem to write...");
            }
            Console.WriteLine("");
            return WorldChampionship.Standards.Single(s => s.Year == selectedOption).ValidCardSets;
        }
    }
}
