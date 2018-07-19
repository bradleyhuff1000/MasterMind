using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public static class Extensions
    {
        public static string DisplayToString(this byte[] input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            if (input != null)
            {
                bool first = true;
                foreach (byte element in input)
                {
                    if (!first) { sb.Append(", "); }
                    sb.Append(element);
                    first = false;
                }
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static byte[] ByteArrayCopy(this byte[] input)
        {
            byte[] output = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[i];
            }
            return output;
        }

        public static byte[] ParseArray(this string input)
        {            
            input = input.Replace(" ", "");
            input = input.Replace(",", "");

            byte[] output = new byte[input.Length];
            int i = 0;
            foreach (char element in input)
            {
                if (!char.IsDigit(element)) { throw new ApplicationException("Entries must be numbers."); }
                output[i] = byte.Parse(element.ToString());
                i++;
            }
            return output;
        }

        public static string DisplayResult(this CompareResult input)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < input.CorrectPositions; i++)
            {
                sb.Append("+");
            }
            for (int i = 0; i < input.IncorrectPositions; i++)
            {
                sb.Append("-");
            }
            return sb.ToString();
        }
    }
}
