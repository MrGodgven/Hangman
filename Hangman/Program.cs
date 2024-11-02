using System;
using System.Diagnostics.CodeAnalysis;

class Program()
{
    public static void Main()
    {
        while (true)
        {
            Game game = new();
            game.Play();
            Console.ReadKey();
        }
    }


    class Game
    {
        string[] words = { "apple", "ocean", "mountain", "friendship", "music", "technology", "happiness", 
            "adventure", "book", "travel", "art", "nature", "science", "dream", "family", "history", "love", 
            "culture", "food", "exercise", "creativity", "peace", "knowledge", "sports", "cinema", "fashion", 
            "health", "language", "photography", "exploration", "gardening", "writing", "meditation", "innovation", 
            "wildlife", "community", "architecture", "spirituality", "design", "theater", "climate", "education", 
            "motivation", "journey", "rhythm", "beauty", "connection", "discovery" };

        List<char> triedsymbols = new List<char>();

        public void Play()
        {
            uint tries = 5;
            Random rnd = new Random();
            string word = words[rnd.Next(0, words.Length)];
            int lenght = word.Length;
            char[] our_word = new String('_', lenght).ToCharArray();

            while (tries > 0)
            {
                Console.Clear();
                Display(word, our_word, tries, triedsymbols);

                Console.WriteLine("\n     ");

                char symbol = Char.ToLower(Console.ReadKey().KeyChar);

                if (IsWrongSymbol(symbol))
                {
                    Console.Clear();
                    Console.WriteLine("Input is invalid");
                    Thread.Sleep(1000);
                    continue;
                }

                if(IsAlreadyGuessed(symbol, our_word, triedsymbols))
                {
                    Console.Clear();
                    Console.WriteLine("\n U already tried that symbol!");
                    Thread.Sleep(1000);
                    continue;
                }

                triedsymbols.Add(symbol);

                if (IsIn(symbol, word)) 
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (symbol == word[i])
                        {
                            our_word[i] = symbol;
                        }
                    }
                }
                else
                {
                    tries--;
                    continue;
                }

                if (IsEquals(word, our_word))
                {
                    Console.Clear();
                    Console.WriteLine($"Win with {tries} last tries ({word})");
                    break;
                }
            }
            if (tries == 0)
            {
                Console.WriteLine($"\n\nGoodluck next time ({word})");
            }
        }

        static void Display(string word, char[] word2, uint tries, List<char> List)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(" " + Char.ToUpper(word2[i]));
            }

            Console.Write("     " + tries + " tries left    ");

            for (int i = 0; i < List.Count; i++)
            {
                Console.Write(" " + Char.ToUpper(List[i]));
            }
        }

        static bool IsWrongSymbol(char symbol)
        {
            if (char.IsLetter(symbol) &&
                (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z')) return false;
            return true;
        }

        static bool IsAlreadyGuessed(char symbol, char[] word, List<char> List)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (symbol == word[i])
                {
                    return true;
                    
                }
            }

            for (int i = 0; i < List.Count; i++)
            {
                if (symbol == List[i])
                {
                    return true;

                }
            }

            return false;
        }

        static bool IsIn(char symbol, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (symbol == word[i])
                {
                    return true;

                }
            }
            return false;
        }

        static bool IsEquals(string word, char[] word2)
        {

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != word2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

}