using System;
using System.Text;

namespace ITAcademy.NetrebiakVasyl.Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text to first string: ");
            StringBuilder Str1=new StringBuilder(Console.ReadLine());

            Console.Write("Enter text to second string: ");
            StringBuilder Str2=new StringBuilder(Console.ReadLine());

            bool result = ContainsAllSymbols(Str1, Str2);
            Console.WriteLine($"Does first string contain all symbols of second string : {result}");

            StringBuilder Sharped=new StringBuilder();
            Sharped.Append(Str1);
            Sharped=ReplaceEqualSymbols(Sharped, Str2);
            Console.WriteLine($"Similar symbols replaced with # : {Sharped} ");

            int CounterOfStrInStr =Count(Str1, Str2);
            Console.WriteLine($"Str2 in Str1 : {CounterOfStrInStr}");

            Console.ReadKey();
        }
        static bool ContainsAllSymbols(StringBuilder text, StringBuilder subtext)
        {
            int counter=0;
            for(int i = 0; i < subtext.Length; i++)
            {
                for(int j = 0; j < text.Length; j++)
                {
                    if (subtext[i] == text[j])
                    {
                        counter++;
                        break;
                    }
                }
            }
            if (counter  == subtext.Length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static StringBuilder ReplaceEqualSymbols(StringBuilder text, StringBuilder subtext)
        {
            for (int i = 0; i < subtext.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (subtext[i] == text[j])
                    {
                        text[j] = '#';
                    }
                }
            }
            return text;
        }

        static int Count(StringBuilder text, StringBuilder subtext)
        {
            int textLength = text.Length;
            int subTextLenght = subtext.Length;


            int[,] lookup = new int[textLength + 1, subTextLenght + 1];

            for (int i = 0; i <= subTextLenght; ++i)
            {
                lookup[0, i] = 0;
            }

            for (int i = 0; i <= textLength; ++i)
            {
                lookup[i, 0] = 1;
            }

            for (int i = 1; i <= textLength; i++)
            {
                for (int j = 1; j <= subTextLenght; j++)
                {

                    if (text[i - 1] == subtext[j - 1])
                    {
                        lookup[i, j] = lookup[i - 1, j - 1] +  lookup[i - 1, j];
                    }

                    else
                    {
                        lookup[i, j] = lookup[i - 1, j];
                    }
                }

            }

            return lookup[textLength, subTextLenght];
        }
    }
}
