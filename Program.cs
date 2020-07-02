using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static System.Console;

namespace SD_30_Garland
{
    class Program
    {
        static void Main(string[] args)
        {
            string garland;
            do
            {
                Clear();
                WriteLine("Pass a word to be used as garland");
                garland = ReadLine();

            } while (garland.Trim().Length <= 0);

            int garlandLength;
            do
            {
                Clear();
                WriteLine("How long resulting garland you want to be?");
                int.TryParse(ReadLine(), out int _out);
                garlandLength = _out;
            } while (garlandLength <= 0);


            int garlandIndicator = 0;
            for (int i = garland.Length; i > 0; i--)
            {
                var _rez = IsGarland(garland, i);
                garlandIndicator = garlandIndicator > _rez ? garlandIndicator : _rez;
            }

            bool isGarland = garlandIndicator > 0 ? true : false;
            if (isGarland)
            {

                WriteLine($"{garland} is garland, its indicator level is: {garlandIndicator}");
                WriteLine($"Garland of length you asked for is written below:\n{ResultingGarland(garland, garlandLength, garlandIndicator)}");
            }
            else
            {
                WriteLine($"{garland} is not a gerland.");
            }

            WriteLine($"theEnd ================ {garland}");
        }

        private static string ResultingGarland(string garland, int garlandLength, int garlandIndicator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(garland);

            if (garlandLength > 1)
            {
                var list = Enumerable.Repeat(garland.Remove(0, garlandIndicator), garlandLength - 1).ToList();
                list.ForEach(x => sb.Append(x));
            }


            return sb.ToString();
        }

        private static int IsGarland(string garland, int input)
        {
            int result = 0;
            for (int i = 0; i < garland.Length; i++)
            {
                if (input + i >= garland.Length)
                {
                    return result;
                }
                else
                {

                    if (garland[i] == garland[input + i])
                    {
                        result += 1;
                    }
                    else
                    {
                        return result;
                    }
                }
            }


            return result;
        }

    } // end of class
} // end of namespace
