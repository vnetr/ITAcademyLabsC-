using System;
using System.Globalization;
using System.Threading;

namespace ITAcademy.NetrebiakVasyl.Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool loop = true;
                char choiceInChar;
                int choice = 0;
                int start;
                int end;
                char symbol;
                Console.Write("Input size of square matrix: ");
                var size = Convert.ToInt32(Console.ReadLine());
                dynamic[,] array = new dynamic[size, size];
                Console.WriteLine();
                while (loop)
                {
                    Console.Write("Choose area to fill(1-14): ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            FirstArea(array);
                            loop = false;
                            break;
                        case 2:
                            SecondArea(array);
                            loop = false;
                            break;
                        case 3:
                            ThirdArea(array);
                            loop = false;
                            break;
                        case 4:
                            FourthArea(array);
                            loop = false;
                            break;
                        case 5:
                            FifthArea(array);
                            loop = false;
                            break;
                        case 6:
                            SixthArea(array);
                            loop = false;
                            break;
                        case 7:
                            SeventhArea(array);
                            loop = false;
                            break;
                        case 8:
                            EightArea(array);
                            loop = false;
                            break;
                        case 9:
                            NinthArea(array);
                            loop = false;
                            break;
                        case 10:
                            TenthArea(array);
                            loop = false;
                            break;
                        case 11:
                            EleventhArea(array);
                            loop = false;
                            break;
                        case 12:
                            TwelfthArea(array);
                            loop = false;
                            break;
                        case 13:
                            ThirteenthArea(array);
                            loop = false;
                            break;
                        case 14:
                            FourteenthArea(array);
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect input!");
                            break;
                    }
                  
                }
                loop = true;
                Console.WriteLine();

                Console.WriteLine("Choose how to fill");
                Console.WriteLine("1. With random numbers");
                Console.WriteLine("2. With even numbers");
                Console.WriteLine("3. With odd numbers");
                Console.WriteLine("4. With random chars");
                Console.WriteLine("5. With random english letters");
                while (loop)
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            FillWithRandom(array);
                            loop = false;
                            break;
                        case 2:
                            while (true)
                            {
                                Console.WriteLine("Set range");
                                Console.Write("Start: ");
                                start = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                Console.Write("End: ");
                                end = Convert.ToInt32(Console.ReadLine());
                                if (end > start)
                                {
                                    FillWithEven(array, start, end);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error with start and end of range!");
                                }
                            }
                            loop = false;
                            break;
                        case 3:
                           Console.WriteLine("Set range");
                                Console.Write("Start: ");
                                start = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                Console.Write("End: ");
                                end = Convert.ToInt32(Console.ReadLine());
                                if (end > start)
                                {
                                    FillWithOdd(array, start, end);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error with start and end of range!");
                                }
                            loop = false;
                            break;
                        case 4:
                            FillWithRandomChars(array);
                            loop = false;
                            break;
                        case 5:
                            FillWithRandomEngLetters(array);
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect input!");
                            break;
                    }
                    break;
                    
                }
                PrintArray(array);
                loop = true;
                Console.WriteLine();

                if (choice <= 3)
                {
                    Console.WriteLine("Choose what to find");
                    Console.WriteLine("1. Max num");
                    Console.WriteLine("2. Min num");
                    while (loop)
                    {
                        choice= Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Max num in area" + FindMax(array)); 
                                loop = false;
                                break;
                            case 2:
                                
                                Console.WriteLine("Min num in area" + FindMin(array));
                                loop = false;
                                break;
                            default:
                                Console.WriteLine("Incorrect input!");
                                break;
                        }
                    }
                }
                else
                {
                    Console.Write("Input symbol: ");
                    symbol = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine($"Does arrea contains {symbol}: {ContainsSymbol(array, symbol)}");

                }
                loop = true;

                TransposeMatrix(array);
                Console.WriteLine("Transposed matrix: ");
                PrintArray(array);
                Console.WriteLine();
                Console.Write("Switch areas? (y/n): ");
                while (loop)
                {
                    choiceInChar = Char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    switch (choiceInChar)
                    {
                        case 'y':
                            RotateMatrix(array);
                            PrintArray(array);
                            Console.WriteLine();
                            break;
                        case 'n':
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect input!");
                            break;
                    }
                }
                break;
            }
            Console.WriteLine();
            Console.WriteLine("This is end))");
            Console.ReadKey();
        }
        
        static void PrintArray(dynamic[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        
        static void FillWithRandom(dynamic[,] array)
        {
            Random rnd = new Random();
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j <array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        array[i, j] = rnd.Next(300);
                    }
                }
            }
        }


        static void FillWithEven(dynamic[,] array, int start, int end)
        {
            if (start % 2 != 0)
            {
                start++;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        array[i, j] = start;
                        start += 2;
                    }
                }
                if (start > end)
                {
                    break;
                }
            }
        }

        static void FillWithOdd(dynamic[,] array, int start, int end)
        {
            if (start % 2 == 0)
            {
                start++;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        array[i, j] = start;
                        start += 2;
                    }
                }
                if (start > end)
                {
                    break;
                }
            }
        }

        static void FillWithRandomChars(dynamic[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null) 
                    {

                        array[i, j] = (char)rnd.Next(300);
                    } 
                }
            }
        }

        static void FillWithRandomEngLetters(dynamic[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        array[i, j] = (char)rnd.Next('a', 'z' + 1);

                    }
                }
            }

        }
        static dynamic FindMax(dynamic[,] array)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        if (array[i, j] > max)
                        {
                            max = array[i, j];
                        }
                    }
                }
            }
            return max;
        }

        static dynamic FindMin(dynamic[,] array)
        {
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        if (array[i, j] < min)
                        {
                            min = array[i, j];
                        }
                    }
                }
            }
            return min;
        }

        static bool ContainsSymbol(dynamic[,] array, dynamic SymbolToFind)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != null)
                    {
                        if (array[i, j] == SymbolToFind)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static void FirstArea(dynamic[,] array)
        {
            for (int i = 0; i< array.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    array[i, j] = ' ';
                }
            }
        }

        static void SecondArea(dynamic[,] array)
        {
            FourthArea(array);
            RotateMatrix(array);

        }
        static void ThirdArea(dynamic[,] array)
        {
            SecondArea(array);
            RotateMatrix(array);

        }

        static void FourthArea(dynamic[,] array)
        {
            FirstArea(array);
            RotateMatrix(array);

        }

        static void FifthArea(dynamic[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i >= j) && (j >= -i + array.GetLength(0) - 1))
                    {
                        array[i, j] = ' ';
                    }
                    if ((j>=i)&&(j<-i+array.GetLength(0))) 
                    {
                        array[i, j] = ' ';
                    }
                    
                }
            }
        }

        static void SixthArea(dynamic[,] array)
        {
            FifthArea(array);
            RotateMatrix(array);
        }

        static void SeventhArea(dynamic[,] array)
        {
            TenthArea(array);
            RotateMatrix(array);
        }

        static void EightArea(dynamic[,] array)
        {
            NinthArea(array);
            RotateMatrix(array);
        }

        static void NinthArea(dynamic[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i >= j)&&(j >= -i+array.GetLength(0)-1))
                    {
                        array[i, j] = ' ';
                    }
                }
            }

        }

        static void TenthArea(dynamic[,] array)
        {
            EightArea(array);
            RotateMatrix(array);
        }
        static void EleventhArea(dynamic[,] array)
        {
            ThirteenthArea(array);
            RotateMatrix(array);
        }
        static void TwelfthArea(dynamic[,] array)
        {
            FourteenthArea(array);
            RotateMatrix(array);
        }

        static void ThirteenthArea(dynamic[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!((i >= j) && (j >= -i + array.GetLength(0) - 1)))
                    {
                        array[i, j] = 1;
                    }
                }
            }

        }

        static void FourteenthArea(dynamic[,] array)
        {
            EleventhArea(array);
            RotateMatrix(array);
        }
        
        static void TransposeMatrix(dynamic[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i + 1; j < array.GetLength(1); j++)
                {
                    var temp = array[i, j];
                    array[i, j] = array[j, i];
                    array[j, i] = temp;
                }
            }

        }

        static void RotateMatrix(dynamic[,] oldMatrix)
        {
            dynamic[,] newMatrix = new dynamic[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            for(int i = 0; i < oldMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < oldMatrix.GetLength(1); j++)
                {
                    oldMatrix[i, j] = newMatrix[i, j];
                }
            }
        }


    }
}