using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public static class MasterMindGameFactory
    {
        public static IMasterMindGame CreateGame()
        {
            return new MasterMindGameSession();
        }
    }

    public class MasterMindGameSession: IMasterMindGame
    {
        private const int LENGTH = 4, MINIMUM = 1, MAXIMUM = 6, MAX_ATTEMPTS = 10;
        private byte[] hiddenNumber;
        private int attempts = 0;

        public void Start()
        {
            hiddenNumber = GameLogic.GenerateHiddenNumber(LENGTH, MINIMUM, MAXIMUM);
            attempts = 0;
        }

        public Answer EnterGuess(byte[] guess)
        {
            Answer output = new Answer();
            string message = GameLogic.ValidateGuess(guess, LENGTH, MINIMUM, MAXIMUM);
            if (message.Length > 0) { output.IsError = true; output.Message = message;  return output; }

            CompareResult result = GameLogic.Compare(guess, hiddenNumber);
            output.Result = result;
            if (result.CorrectPositions == LENGTH) { output.GameState = GameState.Won; }
            else
            {
                attempts++;
            }
            if (attempts >= MAX_ATTEMPTS) { output.GameState = GameState.Lost; }
            return output;
        }
    }
}
