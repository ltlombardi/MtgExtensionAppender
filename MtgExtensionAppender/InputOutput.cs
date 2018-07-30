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
            Console.WriteLine("Select the world championship year to define the card set to be added to the cards in the deck.");
            var firstOptionNumber = 1;
            for (int i = 0; i < WorldChampionship.Standards.Count; i++)
            {
                Console.WriteLine(i + firstOptionNumber + ". Year " + WorldChampionship.Standards[i].Year);
            }
            int selectedOption;
            while (!int.TryParse(Console.ReadLine(), out selectedOption) || selectedOption > WorldChampionship.Standards.Count || selectedOption < firstOptionNumber)
            {
                Console.WriteLine("Invalid option. Planeswalkers can't seem to write...");
            }
            Console.WriteLine("");
            return WorldChampionship.Standards[selectedOption - firstOptionNumber].ValidCardSets;
        }
    }
}
