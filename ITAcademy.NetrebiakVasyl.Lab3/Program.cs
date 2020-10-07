using System;
using System.Globalization;

namespace ITAcademy.NetrebiakVasyl.Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ROWS = 5;
            const int COLUMNS = 5;
            int MaxNumInArray = 0;
            int MinNumInArray = 0;
            bool ContainsSymbol;
            char Symb;
            Console.WriteLine("Enter range of nums to fill");
            Console.Write("Start : ");
            int StartOfRange = Convert.ToInt32(Console.ReadLine());
            Console.Write("End : ");
            int EndOfRange = Convert.ToInt32(Console.ReadLine());
            int[,] NumMassive = new int[ROWS, COLUMNS]{ {0,0,0,0,0}
                                                       ,{0,0,0,0,0}
                                                       ,{0,0,0,0,0}
                                                       ,{0,0,0,0,0}
                                                       ,{0,0,0,0,0} };
            char[,] SymbMassive = new char[ROWS, COLUMNS]{{'o','o','o','o','o'}
                                                         ,{'o','o','o','o','o'}
                                                         ,{'o','o','o','o','o'}
                                                         ,{'o','o','o','o','o'}
                                                         ,{'o','o','o','o','o'} };


            Console.WriteLine("Filling First area with random numbers:");
            FillWithRandomFirstArea(ref NumMassive);
            PrintArray(NumMassive);
            Console.WriteLine();


            Console.WriteLine($"Filling First area with even numbers from {StartOfRange} to {EndOfRange} ");
            FillWithEvenNumsFirstArea(ref NumMassive, StartOfRange, EndOfRange);
            PrintArray(NumMassive);
            Console.WriteLine();

            Console.WriteLine($"Filling First area with odd numbers from {StartOfRange} to {EndOfRange} ");
            FillWithOddNumsFirstArea(ref NumMassive, StartOfRange, EndOfRange);
            PrintArray(NumMassive);
            Console.WriteLine();


            Console.WriteLine("Filling First area with random symbols:");
            FillWithRandomCharsFirstArea(ref SymbMassive);
            Console.WriteLine();
            PrintArray(SymbMassive);
            Console.WriteLine();

            Console.WriteLine("Filling First area with random English letters:");
            FillWithRandomEngLettersFirstArea(ref SymbMassive);
            Console.WriteLine();
            PrintArray(SymbMassive);

            MaxNumInArray = FindMaxInFirstArea(NumMassive);
            Console.Write($"Max num in array of nums: {MaxNumInArray}");
            Console.WriteLine();
            MinNumInArray = FindMinInFirstArea(NumMassive);
            Console.Write($"Min num in array of nums: {MinNumInArray}");
            Console.WriteLine();

            Console.Write("Input symbol: ");
            Symb = Console.ReadKey().KeyChar;
            Console.WriteLine();
            ContainsSymbol = ContainSymbol(SymbMassive, Symb);
            Console.WriteLine($"Does array of symbols contains {Symb}: {ContainsSymbol}");

            Console.WriteLine("Transposed matrix of numbers:");
            TransposeMatrix(ref NumMassive);
            PrintArray(NumMassive);
            Console.WriteLine();

            Console.WriteLine("Transposed matrix of Symbols:");
            TransposeMatrix(ref SymbMassive);
            PrintArray(SymbMassive);
            Console.WriteLine();


            Console.WriteLine("Replacing elements of arrays from 2nd area to 3rd: ");
            NumMassive = RotateArrayNums(NumMassive);
            SymbMassive = RotateArrayChars(SymbMassive);
            PrintArray(SymbMassive);
            Console.WriteLine();
            PrintArray(NumMassive);
            Console.WriteLine();


            Console.WriteLine("Replacing elements of arrays from 3rd area to 1st: ");
            NumMassive = RotateArrayNums(NumMassive);
            SymbMassive = RotateArrayChars(SymbMassive);
            PrintArray(SymbMassive);
            Console.WriteLine();
            PrintArray(NumMassive);
            Console.WriteLine();

            Console.WriteLine("Replacing elements of arrays from 1st area to 4th: ");
            NumMassive = RotateArrayNums(NumMassive);
            SymbMassive = RotateArrayChars(SymbMassive);
            PrintArray(SymbMassive);
            Console.WriteLine();
            PrintArray(NumMassive);


            Console.ReadKey();
        }
        static void PrintArray(int[,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void PrintArray(char[,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void FillWithEvenNumsFirstArea(ref int[,] Array, int StartRange, int EndRange)
        {
            if (StartRange % 2 != 0)
            {
                StartRange++;

            }
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    if (StartRange > EndRange)
                    {
                        break;
                    }
                    Array[i, j] = StartRange;
                    StartRange += 2;

                }
                if (StartRange > EndRange)
                {
                    break;
                }

            }


        }
        static void FillWithOddNumsFirstArea(ref int[,] Array, int StartRange, int EndRange)
        {
            if (StartRange % 2 == 0)
            {
                StartRange++;

            }
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    if (StartRange > EndRange)
                    {
                        break;
                    }
                    Array[i, j] = StartRange;
                    StartRange += 2;

                }
                if (StartRange > EndRange)
                {
                    break;
                }

            }


        }
        static void FillWithRandomFirstArea(ref int[,] Array)
        {
            Random rnd = new Random();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    Array[i, j] = rnd.Next(300);
                }
            }
        }
        static void FillWithRandomCharsFirstArea(ref char[,] Array)
        {
            Random rnd = new Random();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    Array[i, j] = (char)rnd.Next(300);
                }
            }
        }
        static void FillWithRandomEngLettersFirstArea(ref char[,] Array)
        {
            Random rnd = new Random();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    Array[i, j] = (char)rnd.Next('a', 'z' + 1);
                }
            }

        }
        static int FindMaxInFirstArea(int[,] Array)
        {
            int max = Array[0, 0];
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    if (Array[i, j] > max)
                    {
                        max = Array[i, j];
                    }
                }
            }
            return max;
        }
        static int FindMinInFirstArea(int[,] Array)
        {
            int min = Array[0, 0];
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    if (Array[i, j] < min)
                    {
                        min = Array[i, j];
                    }
                }
            }
            return min;
        }
        static bool ContainSymbol(char[,] Array, char SymbolToFind)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 1))
                    {
                        break;
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        break;
                    }
                    else if ((i == 2) && (j == 3))
                    {
                        break;
                    }
                    else if ((i == 3) && (j == 4))
                    {
                        break;
                    }
                    if (Array[i, j] == SymbolToFind)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void TransposeMatrix(ref int[,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = i + 1; j < Array.GetLength(1); j++)
                {
                    int temp = Array[i, j];
                    Array[i, j] = Array[j, i];
                    Array[j, i] = temp;
                }
            }

        }
        static void TransposeMatrix(ref char[,] Array)
        {
            char temp;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = i + 1; j < Array.GetLength(1); j++)
                {
                    temp = Array[i, j];
                    Array[i, j] = Array[j, i];
                    Array[j, i] = temp;
                }
            }

        }
        static int[,] RotateArrayNums(int[,] Array)
        {
            int[,] newArray = new int[Array.GetLength(1), Array.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = Array.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < Array.GetLength(0); oldRow++)
                {
                    newArray[newRow, newColumn] = Array[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newArray;
        }
        static char[,] RotateArrayChars(char[,] Array)
        {
            char[,] newArray = new char[Array.GetLength(1), Array.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = Array.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < Array.GetLength(0); oldRow++)
                {
                    newArray[newRow, newColumn] = Array[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newArray;
        }
    }

}