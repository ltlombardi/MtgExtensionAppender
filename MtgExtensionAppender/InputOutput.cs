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
            Console.WriteLine("Select the world championship year to define the card set to be added to the card list, " +
                "if multiple printings exist for the card");
            var firstOptionIndexShift = 1;
            for (int i = 0; i < WorldChampionship.Standards.Count; i++)
            {
                Console.WriteLine(i + firstOptionIndexShift + ". Year " + WorldChampionship.Standards[i].Year);
            }
            var userInput = Console.ReadLine();
            int selectedOption;
            while (!int.TryParse(userInput, out selectedOption) || selectedOption > WorldChampionship.Standards.Count || selectedOption < firstOptionIndexShift)
            {
                Console.WriteLine("Invalid option. Planeswalkers can't seem to write...");
                userInput = Console.ReadLine();
            }
            return WorldChampionship.Standards[selectedOption - firstOptionIndexShift].ValidCardSets;
        }

        public static IList<string> GetCardSetsFromArgs(string[] args)
        {
            var listOfCards = new List<string>();
            int inputedYear;
            if (int.TryParse(args[0], out inputedYear))
            {
                var validCardSets = WorldChampionship.Standards.FirstOrDefault(s => s.Year == inputedYear)?.ValidCardSets;
                if (validCardSets != null) listOfCards.AddRange(validCardSets);
            }
            return listOfCards;
        }
    }
}
