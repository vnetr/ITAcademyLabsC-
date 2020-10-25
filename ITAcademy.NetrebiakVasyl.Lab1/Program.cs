using System;
namespace ITAcademy.NetrebiakVasyl.Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input value of N: ");


            long N;
            N = Convert.ToInt64(Console.ReadLine());


            int digitsInNumber;
            digitsInNumber = AmountOfNumberss(N);
            Console.WriteLine("Amount of numbers in N = " + digitsInNumber);
            Console.WriteLine();


          
            long[] massiveOfNumbers = new long[digitsInNumber];
            OrganizeMassive(massiveOfNumbers, N);
            for (int i = digitsInNumber-1; i>=0; i--)
            {
                Console.WriteLine($"{massiveOfNumbers[i]}");
            }
            Console.WriteLine();


            double arithmeticMeanOfNNums=ArithmeticMean(N, digitsInNumber);
            Console.WriteLine($"Arithmetic mean of digits of N = {arithmeticMeanOfNNums}");
            Console.WriteLine();


            double geometricMeanOfNNums=GeometricMean(N, digitsInNumber);
            Console.WriteLine($"Geometric mean of digits of N = {geometricMeanOfNNums}");
            Console.WriteLine();

            double factorialOfNum = FactorialRecursion(N);
            Console.WriteLine($"Factorial of N with recursion = {factorialOfNum}");
            factorialOfNum = FactorialLoop(N);
            Console.WriteLine($"Factorial of N with Loop = {factorialOfNum}");
            Console.WriteLine();

            long sumOfEvenNumbersToNum;
            sumOfEvenNumbersToNum = SumOfEvenNumbers_ForLoop(N);
            Console.WriteLine($"Sum of even numbers from 1 to N using FOR loop = {sumOfEvenNumbersToNum}");
            sumOfEvenNumbersToNum = SumOfEvenNumbers_WhileLoop(N);
            Console.WriteLine($"Sum of even numbers from 1 to N using WHILE loop = {sumOfEvenNumbersToNum}");
            sumOfEvenNumbersToNum = SumOfEvenNumbers_DoWhileLoop(N);
            Console.WriteLine($"Sum of even numbers from 1 to N using DO WHILE loop = {sumOfEvenNumbersToNum}");
            Console.WriteLine();

            long sumOfOddNumbersToNum;
            sumOfOddNumbersToNum = SumOfOddNumbers(N);
            Console.WriteLine($"Sum of odd numbers from 1 to N = {sumOfOddNumbersToNum}");

            long sumOfEvenNums;
            long sumOfOddNums;
            Console.Write("Enter first num of range: ");
            int firsNumOfRange = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter end num of range: ");
            int secondNumOfRange=Convert.ToInt32(Console.ReadLine());
            sumOfEvenNums = SumOfEvenNumbers(firsNumOfRange, secondNumOfRange);
            sumOfOddNums = SumOfOddNumbers(firsNumOfRange, secondNumOfRange);
            Console.WriteLine($"Sum of even numbers in range={sumOfEvenNums}, sum of odd={sumOfOddNums}");

            Console.ReadKey();
        }

        static int AmountOfNumberss(long yourNumber)
        {
            int counterOfNumbers = 0;
            while (yourNumber > 0)
            {
                yourNumber = yourNumber / 10;
                counterOfNumbers++;
            }
            return counterOfNumbers;
        }
        static void OrganizeMassive(long[] massive, long yourNumber)
        {
            int indexOfMassive = 0;
            while (yourNumber > 0)
            {
                massive[indexOfMassive] = yourNumber % 10;
                yourNumber /= 10;
                indexOfMassive++;
            }
        }

        static double ArithmeticMean(long yourNumber, int sumOfNumbers)
        {
            double result=0;
            double temp = 0;
            while (yourNumber > 0)
            {
                temp = yourNumber % 10;
                result += temp;
                yourNumber /= 10;
            }
            result /= sumOfNumbers;
            return result;
        }

        static double GeometricMean(long yourNumber, int sumOfNumbers)
        {
            double result = 1;
            double temp = 0;
            while (yourNumber > 0)
            {
                temp = yourNumber % 10;
                result *= temp;
                yourNumber /= 10;
            }
            return Math.Pow(result, 1.0/sumOfNumbers);
        }
        static double FactorialRecursion(long yourNumber)
        {
            if (yourNumber == 0)
            {
                return 1;
            }
            if (yourNumber == 1)
                return 1;
            else
                return yourNumber * FactorialRecursion(yourNumber - 1);
        }
        static double FactorialLoop(long yourNumber)
        {
            double result = 1;
            if (yourNumber == 0)
            {
                return 1;
            }
            while (yourNumber != 1)
            {
                result = result * yourNumber;
                yourNumber = yourNumber - 1;
            }
            return result;
        }
        static long SumOfEvenNumbers_ForLoop(long yourNumber)
        {
            long sum = 0;
            for(int i = 0; i < yourNumber; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static long SumOfEvenNumbers_WhileLoop(long yourNumber)
        {
            long sum = 0;
            int i=0;
            while (i < yourNumber)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
                i++;
            }
            return sum;
        }
        static long SumOfEvenNumbers_DoWhileLoop(long yourNumber)
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
            while (i < yourNumber);
            return sum;
        }
        static long SumOfOddNumbers(long yourNumber)
        {
            long sum = 0;
            for (int i = 0; i < yourNumber; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static long SumOfOddNumbers(int from, int to)
        {
            long sum = 0;
            for (int i = from; i < to; i++)
            {
                if ((i % 2 == 1)&&(to>from))
                {
                    sum += i;
                }
            }
            return sum;
        }
        static long SumOfEvenNumbers(int from, int to)
        {
            long sum = 0;
            for (int i = from; i < to; i++)
            {
                if ((i % 2 == 0) && (to > from))
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
