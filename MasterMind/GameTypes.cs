using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public enum GameState { Continue, IncorrectGuess, Won, Lost}

    public struct CompareResult { 
        public int CorrectPositions { get; set; }
        public int IncorrectPositions { get; set; }

        public override string ToString()
        {
            return $"Correct Positions: {CorrectPositions} Incorrect Positions: {IncorrectPositions}";
        }
    }

    public class Answer
    {
        public CompareResult Result { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public GameState GameState { get; set; }
    }
}
