using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a game of mastermind.  Correctly try to guess the hidden number within 10 attempts.");
            IMasterMindGame game = MasterMindGameFactory.CreateGame();

            while (true)
            {
                int i = 1;
                game.Start();

                Answer answer = new Answer();
                do
                {
                    Console.WriteLine($"Attempt {i}");
                    byte[] input = new byte[0];
                    try
                    {
                        string entry = Console.ReadLine();
                        input = entry.ParseArray();
                    }
                    catch (ApplicationException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    answer = game.EnterGuess(input);
                    if (answer.IsError)
                    {
                        Console.WriteLine(answer.Message);
                    }
                    else
                    {
                        i++;
                        Console.WriteLine(answer.Result.DisplayResult());
                    }
                }
                while (answer.GameState == GameState.Continue);
                if (answer.GameState == GameState.Lost)
                {
                    Console.WriteLine("You lost.");
                }
                if (answer.GameState == GameState.Won)
                {
                    Console.WriteLine("You won.");
                }

                Console.WriteLine("Try again.");
                Console.ReadLine();
            }
        }
    }
}
