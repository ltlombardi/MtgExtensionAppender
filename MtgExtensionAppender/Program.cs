﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

/*This program was created with the intent of converting a bunch o MTG deck files in .dck format to a format 
 * tappedout.net site support and add the card expansion.
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

        static void Main(string[] args)
        {
            Console.WriteLine($"Put {deckExtension} files in the same folder as this app.");

            List<string> choosenCardSets = new List<string>();
            if (args.Length > 0)
            {
                choosenCardSets.AddRange(InputOutput.GetCardSetsFromArgs(args));
            }
            if (choosenCardSets.Count == 0)
            {
                choosenCardSets.AddRange(InputOutput.AskUserForCardSets());
            }

            foreach (string filePath in Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*" + deckExtension))
            {
                var lines = File.ReadAllLines(filePath);
                NewMethodAsync(lines, choosenCardSets).Wait();
                File.WriteAllLines(filePath.Replace(deckExtension, ".txt"), lines);
                Console.WriteLine($"\nDeck {filePath} created");
            }

            Console.WriteLine("Text file create. Press any key to finish.");
            Console.ReadKey();
        }

        private static async Task NewMethodAsync(string[] lines, IList<string> choosenCardSets)
        {
            var getTasks = new List<Task>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (!HasCardName(lines, i))
                {
                    lines[i] = lines[i].Insert(0, "#"); //add symbol for commentary
                }
                else
                {
                    var cardName = lines[i].Substring(lines[i].IndexOf(' ') + 1);
                    getTasks.Add(GetCardInformationAsync(cardName, choosenCardSets, lines, i));
                }
            }
            await Task.WhenAll(getTasks);
        }

        private static async Task GetCardInformationAsync(string cardName, IList<string> choosenCardSets, string[] lines, int i)
        {
            var serverData = await client.GetStreamAsync(api + Uri.EscapeDataString(cardName));
            var cards = (Card[])jsonSerializer.ReadObject(serverData);
            var printings = cards.FirstOrDefault()?.all_printings;
            string printCode;
            if (printings == null)
            {
                printCode = "DIDN'T FIND CARD";
            }
            else if (printings.Length > 0)
            {
                printCode = printings.FirstOrDefault(p => choosenCardSets.Contains(p.name))?.tla ?? "BUG";
            }
            else
            {
                printCode = printings[0].tla;
            }
            lines[i] = lines[i].Insert(lines[i].Length, " (" + printCode + ")");
        }

        private static Task<Stream> GetCardInformation(string cardName)
        {
            return client.GetStreamAsync(api + Uri.EscapeDataString(cardName));
        }

        private static bool HasCardName(string[] lines, int i)
        {
            // example of line with card info: 4 Gush
            return Regex.IsMatch(lines[i], @"^\d+");
        }
    }
}
