using System;
using static System.Math;

namespace Dasaeva_Lab1_Var8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАЧА 1");

            Console.Write("Введите x: ");
            double x;
            if (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ошибка ввода!!!! Вы ввели не число.");
                return;
            }

            Console.Write("Введите n: ");
            double n;
            if (!double.TryParse(Console.ReadLine(), out n)) return;

            Console.Write("Введите m: ");
            double m;
            if (!double.TryParse(Console.ReadLine(), out m)) return;

            if (m == 0.0)
            {
                Console.WriteLine("Ошибка деления на 0!");
            }
            else
            {
                double result1 = n / m++;
                Console.WriteLine($"Результат операции 1: {result1}");
                Console.WriteLine($"Значения после операции: n = {n}, m = {m}");
            }

            bool isLess = m++ < --n;
            Console.WriteLine($"Результат операции 2: {isLess}");
            Console.WriteLine($"Значения после операции: m = {m} n = {n}");

            if (n == 0.0 || m == 0.0)
            {
                Console.WriteLine("Ошибка деления на 0!");
            }
            else
            {
                double midRes = m / n;
                bool isLess2 = midRes++ < n / m;
                Console.WriteLine($"Результат операции 3: {isLess2}");
                Console.WriteLine($"Значения после операции: m = {m} n = {n}");
            }

            double result4 = CalculateFormula(x);
            Console.WriteLine($"Результат операции 4: {result4}");
            Console.WriteLine($"Значения после операции: x = {x} \n");


            Console.WriteLine("ЗАДАЧА 2!!!!!");
            Console.Write("Введите координату x: ");
            double pointX;
            if (!double.TryParse(Console.ReadLine(), out pointX))
            {
                Console.WriteLine("Ошибка ввода!!!! Вы ввели не число.");
                return;
            }

            Console.Write("Введите координату y: ");
            double pointY = Convert.ToDouble(Console.ReadLine());

            bool isPointInside = CheckPoint(pointX, pointY);
            Console.WriteLine($"Результат: {isPointInside}\n");


            Console.WriteLine("ЗАДАЧА 3");

            Console.WriteLine("Подставим в формулу значения типа float");
            float aFloat = 1000f;
            float bFloat = 0.0001f;
            float result6 = CalcFloat(aFloat, bFloat);
            Console.WriteLine($"Результат вычислений: {result6}");

            Console.WriteLine("Подставим в формулу значения типа double");
            double aDouble = 1000;
            double bDouble = 0.0001;
            double result7 = CalcDouble(aDouble, bDouble);
            Console.WriteLine($"Результат вычислений: {result7}");

            Console.WriteLine("\nВывод: Тип float имеет меньший объем памяти для хранения знаков после запятой. При операциях с очень большими (a = 1000) и очень малыми (b = 0.0001) числами одновременно, малые доли отбрасываются, что приводит к искажению ответа. Тип double обладает двойной точностью и вычисляет формулу без потери данных.");
        }

        static double CalculateFormula(double x)
        {
            return Sqrt(Abs(Pow(x, 3) - 1)) - 7 * Pow(Cos(Pow(Pow(x, 4) + x, 1.0 / 3.0)), 3);
        }

        static bool CheckPoint(double pointX, double pointY)
        {
            return (Pow(pointX, 2) + Pow(pointY, 2) <= 4 && Abs(pointY) <= 2 - pointX);
        }

        static float CalcFloat(float a, float b)
        {
            return ((float)Pow(a + b, 3) - (float)Pow(a, 3)) / (float)(Pow(b, 3) + 3 * a * (float)Pow(b, 2) + 3 * (float)Pow(a, 2) * b);
        }

        static double CalcDouble(double a, double b)
        {
            return (Pow(a + b, 3) - Pow(a, 3)) / (Pow(b, 3) + 3 * a * Pow(b, 2) + 3 * Pow(a, 2) * b);
        }
    }
}