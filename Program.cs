using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace HangMan_working_version_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new[]
            {
                "hockey",
                "soccer",
                "football",
                "tennis",
                "basketball",

             };

            var chosenWord = words[new Random().Next(0, words.Length - 1)];
            var letters = new List<string>();
            var validCharacters = new Regex("^[a-z]$");//Matches any string
            var tries = 5;
            while (tries != 0)
            {
                var charactersLeft = 0;
                foreach (var character in chosenWord)
                {
                    var letter = character.ToString();
                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        charactersLeft++;
                    }
                }
                Console.WriteLine(string.Empty);
                if (charactersLeft == 0)
                {
                    break;
                }

                Console.Write(" Type in a letter: ");
                var key = Console.ReadKey().Key.ToString().ToLower();
                Console.WriteLine(string.Empty);
                if (!validCharacters.IsMatch(key))
                {
                    Console.WriteLine($" The key you entered is invalid");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
                if (letters.Contains(key))
                {
                    Console.WriteLine(" This letter was already entered");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
                letters.Add(key);
                if (!chosenWord.Contains(key))
                {
                    tries--;
                    if (tries > 0)
                    {
                        Console.WriteLine($" The letter {key} is not in the word. You have {tries} left.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            }
            if (tries > 0)
            {
                Console.WriteLine($"You won with {tries} lives left");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"You lost! The word was {chosenWord}.");
                Thread.Sleep(2000);
                Console.Clear();

            }
            
        }
        int stage = 0;
        string[] stage1 =
        {
                "  +---+  ",
                "  |   |  ",
                "      |  ",
                "      |  ",
                "      |  ",
                "      |  ",
                "========="
        };
        string[] stage2 =
        {
                "  +---+  ",
                "  |   |  ",
                "  O   |  ",
                "      |  ",
                "      |  ",
                "      |  ",
                "========="

        };
        string[] stage3 =
        {
                "  +---+  ",
                "  |   |  ",
                "  O   |  ",
                " /|\\ |  ",
                "      |  ",
                "      |  ",
                "========="
        };
        string[] stage4 =
        {
            "  +---+  ",
            "  |   |  ",
            "  O   |  ",
            " /|\\ |  ",
            " / \\ |  ",
            "      |  ",
            "      |  ",
            "=========",
        };
    }
}
