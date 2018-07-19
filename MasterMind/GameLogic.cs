using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MasterMind
{
    public static class GameLogic
    {
        private static RandomNumberGenerator rng = RandomNumberGenerator.Create();

        public static byte[] GenerateHiddenNumber(int length, int min, int max)
        {
            int range = max - min + 1;
            byte[] output = new byte[length];
            rng.GetBytes(output);

            for (int i = 0; i < length; i++)
            {
                output[i] = (byte)(output[i] % range + min);
            }

            return output;
        }

        public static CompareResult Compare(byte[] a, byte[] b)
        {
            CompareResult output = new CompareResult();

            //
            // These need copied since when comparing, matching array entries gets set to 255 to avoid being counted again.
            //
            byte[] A = a.ByteArrayCopy();
            byte[] B = b.ByteArrayCopy();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == B[i])
                {
                    output.CorrectPositions++;
                    A[i] = 255;
                    B[i] = 255;
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 255) { continue; }// If it was already counted in a matching pair, continue on to avoid duplicate count.
                for (int j = 0; j < B.Length; j++)
                {
                    if (B[j] == 255) { continue; }// If it was already counted in a matching pair, continue on to avoid duplicate count.

                    if (A[i] == B[j])//A match has been found. i and j will never be equal since this case was already removed in the first loop.
                    {
                        output.IncorrectPositions++;
                        //Prevent those matching sets from being counted again.
                        A[i] = 255;
                        B[j] = 255;
                    }

                }
            }

            return output;
        }

        public static string ValidateGuess(byte[] guess, int length, int minValue, int maxValue)
        {
            if (guess.Length != length) { return $"Guess must have {length} entries"; }
            if (guess.Min() < minValue || guess.Max() > maxValue) { return $"Guess must have entries of values between {minValue} and {maxValue}"; }
            return string.Empty;
        }
    }
}
