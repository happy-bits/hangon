using System;

namespace Hangon.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretWord = "M A M M A";
            char[] wordArray = secretWord.ToCharArray();
            string word = "_ _ _ _ _";
            string usedLetters = "";
            int wrong = 0;
            while (secretWord != word)
            {
                Console.WriteLine(word.ToUpper() + "\n\n");
                Console.WriteLine(usedLetters);

                Console.WriteLine("Guesses left: " + (3 - wrong));

                Console.Write("Your guess: ");
                string letter = Console.ReadLine().ToUpper();
                if (letter.Length > 1 || !char.IsLetter(Convert.ToChar(letter)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid guess.");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                }
                else if (secretWord.IndexOf(letter) != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");

                    for (int a = 0; a < secretWord.Length; a++)
                    {
                        if (wordArray[a] == Convert.ToChar(letter))
                        {
                            word = word.Remove(a, 1).Insert(a, letter.ToString());
                        }
                    }
                    letter = letter.ToUpper();
                    usedLetters = String.Format(usedLetters + letter + " ");

                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (secretWord.IndexOf(letter) == -1)
                {
                    wrong++;
                    if (wrong == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You lost!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        usedLetters = String.Format(usedLetters + letter.ToUpper() + " ");
                        Console.WriteLine("Incorrect!");
                        Console.ReadLine();
                        Console.ResetColor();
                        Console.Clear();
                    }
                }
            }
            Console.WriteLine(word.ToUpper() + "\n\n");
            Console.WriteLine(usedLetters);
            Console.WriteLine("Guesses left: " + (3 - wrong));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won!");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
