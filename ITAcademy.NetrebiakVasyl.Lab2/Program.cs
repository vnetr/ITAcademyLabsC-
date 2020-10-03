using System;
using System.Text;
using System.Threading;

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
            Sharped=ReplaceWithSharpEqualSymbols(Sharped, Str2);
            Console.WriteLine($"Similar symbols replaced with # : {Sharped} ");

            int CounterOfStrInStr = CountStrInStr(Str1, Str2);
            Console.WriteLine($"Str2 in Str1 : {CounterOfStrInStr}");

            Console.ReadKey();
        }
        static bool ContainsAllSymbols(StringBuilder Text, StringBuilder Subtext)
        {
            int counter=0;
            for(int i = 0; i < Subtext.Length; i++)
            {
                for(int j = 0; j < Text.Length; j++)
                {
                    if (Subtext[i] == Text[j])
                    {
                        counter++;
                        break;
                    }
                }
            }
            if (counter  == Subtext.Length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static StringBuilder ReplaceWithSharpEqualSymbols(StringBuilder Text, StringBuilder Subtext)
        {
            for (int i = 0; i < Subtext.Length; i++)
            {
                for (int j = 0; j < Text.Length; j++)
                {
                    if (Subtext[i] == Text[j])
                    {
                        Text[j] = '#';
                    }
                }
            }
            return Text;
        }

        static int CountStrInStr(StringBuilder Text, StringBuilder Subtext)
        {
            int counter = 0;
            int i = 0;
            int j = 0;
            int temp = 0;
            while (i < Text.Length)
            {
                if (Text[i] != Subtext[j])
                {
                    i++;
                    j=0;
                    temp = 0;
                    continue;
                }
                if (Text[i] == Subtext[j])
                {
                    temp++;
                }
                if (temp == Subtext.Length)
                {
                    i++;
                    j = 0;
                    temp = 0;
                    counter++;
                    continue;
                }
                i++;
                j++;
            }
            return counter;
        }
    }
}
