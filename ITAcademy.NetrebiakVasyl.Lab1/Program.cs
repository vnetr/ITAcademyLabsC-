using System;
namespace ITAcademy.NetrebiakVasyl.Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Lab1");
            Console.Write("Input value of N: ");


            long N;
            N = Convert.ToInt64(Console.ReadLine());


            int DigitsInNumber;
            DigitsInNumber = AmtOfNumbers(N);
            Console.WriteLine("Amount of numbers in N = " + DigitsInNumber);
            Console.WriteLine();


            const int SizeOfArray = 20;//Size 20 because of max value of 'long'
            long[] MassiveOfNumbers = new long[SizeOfArray];
            OrganizeMassive(ref MassiveOfNumbers, N);
            for (int i = 0; i < DigitsInNumber; i++)
            {
                Console.WriteLine($"MassiveOfNumbers[{i}]={MassiveOfNumbers[i]}");
            }
            Console.WriteLine();


            double ArithmeticMeanOfNNums=ArithmeticMean(N, DigitsInNumber);
            Console.WriteLine($"Arithmetic mean of digits of N = {ArithmeticMeanOfNNums}");
            Console.WriteLine();


            double GeometricMeanOfNNums=GeometricMean(N, DigitsInNumber);
            Console.WriteLine($"Geometric mean of digits of N = {GeometricMeanOfNNums}");
            Console.WriteLine();

            double FactorialOfNum = FactorialRecursion(N);
            Console.WriteLine($"Factorial of N with recursion = {FactorialOfNum}");
            FactorialOfNum = FactorialLoop(N);
            Console.WriteLine($"Factorial of N with Loop = {FactorialOfNum}");
            Console.WriteLine();

            long SumOfEvenNumbersToNum;
            SumOfEvenNumbersToNum = SumOfEvenNumbers_ForLoop(N);
            Console.WriteLine($"Sum of even numbers from 1 to N using FOR loop = {SumOfEvenNumbersToNum}");
            SumOfEvenNumbersToNum = SumOfEvenNumbers_WhileLoop(N);
            Console.WriteLine($"Sum of even numbers from 1 to N using WHILE loop = {SumOfEvenNumbersToNum}");
            SumOfEvenNumbersToNum = SumOfEvenNumbers_DoWhileLoop(N);
            Console.WriteLine($"Sum of even numbers from 1 to N using DO WHILE loop = {SumOfEvenNumbersToNum}");
            Console.WriteLine();

            long SumOfOddNumbersToNum;
            SumOfOddNumbersToNum = SumOfOddNumbers(N);
            Console.WriteLine($"Sum of odd numbers from 1 to N = {SumOfOddNumbersToNum}");

            long SumOfEvenNums;
            long SumOfOddNums;
            Console.Write("Enter first num of range: ");
            int FirsNumOfRange = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter end num of range: ");
            int SecondNumOfRange=Convert.ToInt32(Console.ReadLine());
            SumOfEvenNums = SumOfEvenNumbers(FirsNumOfRange, SecondNumOfRange);
            SumOfOddNums = SumOfOddNumbers(FirsNumOfRange, SecondNumOfRange);
            Console.WriteLine($"Sum of even numbers in range={SumOfEvenNums}, sum of odd={SumOfOddNums}");

            Console.ReadKey();
        }

        static int AmtOfNumbers(long YourNumber)//Amt.==Amount
        {
            int CounterOfNumbers = 0;
            while (YourNumber > 0)
            {
                YourNumber = YourNumber / 10;
                CounterOfNumbers++;
            }
            return CounterOfNumbers;
        }
        static void OrganizeMassive(ref long[] massive, long YourNumber)
        {
            int IndexOfMassive = 0;
            while (YourNumber > 0)
            {
                massive[IndexOfMassive] = YourNumber % 10;
                YourNumber /= 10;
                IndexOfMassive++;
            }
        }

        static double ArithmeticMean(long YourNumber, int SumOfNumbers)
        {
            double result=0;
            double temp = 0;
            while (YourNumber > 0)
            {
                temp = YourNumber % 10;
                result += temp;
                YourNumber /= 10;
            }
            result /= SumOfNumbers;
            return result;
        }

        static double GeometricMean(long YourNumber, int SumOfNumbers)
        {
            double result = 1;
            double temp = 0;
            while (YourNumber > 0)
            {
                temp = YourNumber % 10;
                result *= temp;
                YourNumber /= 10;
            }
            return Math.Pow(result, 1.0/SumOfNumbers);
        }
        static double FactorialRecursion(long YourNumber)
        {
            if (YourNumber == 1)
                return 1;
            else
                return YourNumber * FactorialRecursion(YourNumber - 1);
        }
        static double FactorialLoop(long YourNumber)
        {
            double result = 1;
            while (YourNumber != 1)
            {
                result = result * YourNumber;
                YourNumber = YourNumber - 1;
            }
            return result;
        }
        static long SumOfEvenNumbers_ForLoop(long YourNumber)
        {
            long sum = 0;
            for(int i = 0; i < YourNumber; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static long SumOfEvenNumbers_WhileLoop(long YourNumber)
        {
            long sum = 0;
            int i=0;
            while (i < YourNumber)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
                i++;
            }
            return sum;
        }
        static long SumOfEvenNumbers_DoWhileLoop(long YourNumber)
        {
            long sum = 0;
            int i = 0;
            do
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
                i++;
            }
            while (i < YourNumber);
            return sum;
        }
        static long SumOfOddNumbers(long YourNumber)
        {
            long sum = 0;
            for (int i = 0; i < YourNumber; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static long SumOfOddNumbers(int From, int To)
        {
            long sum = 0;
            for (int i = From; i < To; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static long SumOfEvenNumbers(int From, int To)
        {
            long sum = 0;
            for (int i = From; i < To; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
