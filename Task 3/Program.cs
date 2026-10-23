<<<<<<< HEAD
﻿using System;

namespace SeriesCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            double startRange = ReadDouble("Введите a (начало отрезка): ");
            double endRange = ReadDouble("Введите b (конец отрезка): ");
            int partitionCount = ReadInt("Введите k (количество разбиений): ");
            int termCount = ReadInt("Введите n (заданное число слагаемых): ");

            double epsilon = 0.0001;
            double step = (endRange - startRange) / partitionCount;

            PrintResults(startRange, endRange, step, termCount, epsilon);

            Console.ReadLine();
        }

        static double ReadDouble(string prompt)
        {
            double parsedValue = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input != null)
                {
                    input = input.Replace('.', ',');
                }

                isValidInput = double.TryParse(input, out parsedValue);

                if (!isValidInput)
                {
                    Console.WriteLine("Ошибка: введено неверное число.");
                }
            }
            return parsedValue;
        }

        static int ReadInt(string prompt)
        {
            int parsedValue = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                bool isParsed = int.TryParse(input, out parsedValue);
                bool isPositive = parsedValue > 0;

                isValidInput = isParsed && isPositive;

                if (!isValidInput)
                {
                    Console.WriteLine("Ошибка: введите целое положительное число.");
                }
            }
            return parsedValue;
        }

        static void PrintResults(double startRange, double endRange, double step, int termCount, double epsilon)
        {
            Console.WriteLine("\nРезультаты вычислений:");

            for (double x = startRange; x <= endRange + step / 2; x += step)
            {
                double exactValue = CalculateExactValue(x);
                double sumN = CalculateSumN(x, termCount);
                double sumE = CalculateSumE(x, epsilon);

                Console.WriteLine($"X={Math.Round(x, 2):F2}\tSN={Math.Round(sumN, 5):F5}\tSE={Math.Round(sumE, 5):F5}\tY={Math.Round(exactValue, 5):F5}");
            }
        }

        static double CalculateSequenceTerm(double x, int index)
        {
            // Вычисление члена степенного ряда
            return Math.Pow(x, index) * Math.Sin(index * Math.PI / 4.0);
        }

        static double CalculateExactValue(double x)
        {
            // Аналитическая формула функции для оценки погрешности
            double quarterPi = Math.PI / 4.0;
            return (x * Math.Sin(quarterPi)) / (1 - 2 * x * Math.Cos(quarterPi) + x * x);
        }

        static double CalculateSumN(double x, int termCount)
        {
            double currentSum = 0;

            for (int i = 1; i <= termCount; i++)
            {
                currentSum += CalculateSequenceTerm(x, i);
            }

            return currentSum;
        }

        static double CalculateSumE(double x, double epsilon)
        {
            double currentSum = 0;
            int currentIndex = 1;

            // Проверка степенного множителя на достижение заданной точности.
            // Тригонометрическая часть игнорируется для исключения раннего выхода из цикла из-за нулей синуса.
            while (Math.Pow(x, currentIndex) >= epsilon)
            {
                currentSum += CalculateSequenceTerm(x, currentIndex);
                currentIndex++;
            }

            return currentSum;
        }
    }
=======
﻿using System;

namespace SeriesCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            double startRange = ReadDouble("Введите a (начало отрезка): ");
            double endRange = ReadDouble("Введите b (конец отрезка): ");
            int partitionCount = ReadInt("Введите k (количество разбиений): ");
            int termCount = ReadInt("Введите n (заданное число слагаемых): ");

            double epsilon = 0.0001;
            double step = (endRange - startRange) / partitionCount;

            PrintResults(startRange, endRange, step, termCount, epsilon);

            Console.ReadLine();
        }

        static double ReadDouble(string prompt)
        {
            double parsedValue = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input != null)
                {
                    input = input.Replace('.', ',');
                }

                isValidInput = double.TryParse(input, out parsedValue);

                if (!isValidInput)
                {
                    Console.WriteLine("Ошибка: введено неверное число.");
                }
            }
            return parsedValue;
        }

        static int ReadInt(string prompt)
        {
            int parsedValue = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                bool isParsed = int.TryParse(input, out parsedValue);
                bool isPositive = parsedValue > 0;

                isValidInput = isParsed && isPositive;

                if (!isValidInput)
                {
                    Console.WriteLine("Ошибка: введите целое положительное число.");
                }
            }
            return parsedValue;
        }

        static void PrintResults(double startRange, double endRange, double step, int termCount, double epsilon)
        {
            Console.WriteLine("\nРезультаты вычислений:");

            for (double x = startRange; x <= endRange + step / 2; x += step)
            {
                double exactValue = CalculateExactValue(x);
                double sumN = CalculateSumN(x, termCount);
                double sumE = CalculateSumE(x, epsilon);

                Console.WriteLine($"X={Math.Round(x, 2):F2}\tSN={Math.Round(sumN, 5):F5}\tSE={Math.Round(sumE, 5):F5}\tY={Math.Round(exactValue, 5):F5}");
            }
        }

        static double CalculateSequenceTerm(double x, int index)
        {
            // Вычисление члена степенного ряда
            return Math.Pow(x, index) * Math.Sin(index * Math.PI / 4.0);
        }

        static double CalculateExactValue(double x)
        {
            // Аналитическая формула функции для оценки погрешности
            double quarterPi = Math.PI / 4.0;
            return (x * Math.Sin(quarterPi)) / (1 - 2 * x * Math.Cos(quarterPi) + x * x);
        }

        static double CalculateSumN(double x, int termCount)
        {
            double currentSum = 0;

            for (int i = 1; i <= termCount; i++)
            {
                currentSum += CalculateSequenceTerm(x, i);
            }

            return currentSum;
        }

        static double CalculateSumE(double x, double epsilon)
        {
            double currentSum = 0;
            int currentIndex = 1;

            // Проверка степенного множителя на достижение заданной точности.
            // Тригонометрическая часть игнорируется для исключения раннего выхода из цикла из-за нулей синуса.
            while (Math.Pow(x, currentIndex) >= epsilon)
            {
                currentSum += CalculateSequenceTerm(x, currentIndex);
                currentIndex++;
            }

            return currentSum;
        }
    }
>>>>>>> dca2c06a0919e041f8fcf14d8e3c820762bc2ff0
}