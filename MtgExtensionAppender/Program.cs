using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

/*This program was created with the intent of converting a bunch o MTG deck files in .dck format to a format 
 * tappedout.net site support and add the card set information from tappedout.
 * It this wasn't done, a dynamic object with key/value would have to be used, and I could not find a native way of doing it, 
 * only with NewtonSoft json lib
 */

namespace MtgExtensionAppender
{
    class Program
    {
        private static readonly string api = "http://tappedout.net/api/autocomplete/?name=";
        private static readonly HttpClient client = new HttpClient();
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Card[]));
        private static readonly string deckExtension = ".dck";
        private static string setsNotFound;
        private static int errorCount;

        static void Main(string[] args)
        {
            Console.WriteLine($"This app converts {deckExtension} MTG deck file to txt and adds the card set info for each card.");
            Console.WriteLine($"You need to put the deck files in the same folder as this app.\n");

            IList<string> permittedCardSets = InputOutput.AskUserForCardSets();

            foreach (string filePath in Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*" + deckExtension))
            {
                resetError();
                var deckLines = File.ReadAllLines(filePath);
                ProcessLines(deckLines, permittedCardSets);
                File.WriteAllLines(filePath.Replace(deckExtension, ".txt"), deckLines);

                Console.WriteLine($"Deck {Path.GetFileNameWithoutExtension(filePath)}.txt created"
                    + (errorCount > 0 ? $" with error" : ""));
                Console.ForegroundColor = ConsoleColor.Red;
                if (errorCount > 0) Console.WriteLine($"Total erros: {errorCount}. Could not find set infor for: {setsNotFound}");
                Console.ResetColor();
            }

            Console.WriteLine("Press y to to finish.");
            while (Console.ReadKey().KeyChar != 'y') { }

        }

        private static void resetError()
        {
            setsNotFound = "";
            errorCount = 0;
        }

        private static void ProcessLines(string[] deckLines, IList<string> permittedCardSets)
        {
            var tasks = new List<Task>();
            for (int i = 0; i < deckLines.Length; i++)
            {
                if (!HasCardName(deckLines[i]))
                {
                    deckLines[i] = deckLines[i].Insert(0, "#"); //add symbol for commentary
                }
                else
                {
                    var cardName = deckLines[i].Substring(deckLines[i].IndexOf(' ') + 1);
                    tasks.Add(GetCardInformationAsync(cardName, permittedCardSets, deckLines, i));
                }
            }
            Task.WhenAll(tasks).Wait();

        }

        private static bool HasCardName(string line)
        {
            return Regex.IsMatch(line, @"^\d+");// TODO: improve this regex. Example of line with card info: 4 Gush
        }

        private static async Task GetCardInformationAsync(string cardName, IList<string> permittedCardSets, string[] lines, int i)
        {
            try
            {
                var serverData = await client.GetStreamAsync(api + Uri.EscapeDataString(cardName));
                var cardsFound = jsonSerializer.ReadObject(serverData) as Card[];
                //TODO: ask the user which card, when more than one is found and no exact match.
                var printings = cardsFound?.FirstOrDefault()?.all_printings;
                string printCode;
                if (printings == null)
                {
                    printCode = "************NOT_FOUND";
                }
                else if (printings.Length > 1)
                {
                    printCode = printings.FirstOrDefault(p => permittedCardSets.Contains(p.name.Trim()))?.tla;
                    if (printCode == null)
                    {
                        printCode = "************BUG";
                        errorCount++;
                        setsNotFound += cardName + ", ";
                    }
                }
                else
                {
                    printCode = printings[0].tla;
                }
                lines[i] = lines[i].Insert(lines[i].Length, " (" + printCode + ")");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Could not connect with Tappedout to work on {cardName}. Error: " + e.Message);
                Console.ResetColor();
            }
        }

        private static Task<Stream> GetCardInformation(string cardName)
        {
            return client.GetStreamAsync(api + Uri.EscapeDataString(cardName));
        }
    }
}
