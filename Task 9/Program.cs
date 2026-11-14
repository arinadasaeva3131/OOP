using System;

namespace LabMoney
{
    // Файл UI.cs
    public static class UI
    {
        public static int ReadInt(string prompt, int min = 0)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min)
                    return result;
                Console.WriteLine($"Ошибка: введите целое число не меньше {min}.");
            }
        }
    }

    // Файл Money.cs
    public class Money
    {
        public static int ObjectCount { get; private set; } = 0;

        private int _rubles;
        private int _kopeks;

        public int Rubles
        {
            get => _rubles;
            set => _rubles = Math.Max(0, value);
        }

        public int Kopeks
        {
            get => _kopeks;
            set
            {
                if (value >= 100)
                {
                    Rubles += value / 100;
                    _kopeks = value % 100;
                }
                else if (value < 0)
                {
                    _kopeks = 0;
                }
                else
                {
                    _kopeks = value;
                }
            }
        }

        public Money()
        {
            Rubles = 0;
            Kopeks = 0;
            ObjectCount++;
        }

        public Money(int rubles, int kopeks)
        {
            Rubles = rubles;
            Kopeks = kopeks;
            ObjectCount++;
        }

        public Money Subtract(Money other)
        {
            int total1 = this.Rubles * 100 + this.Kopeks;
            int total2 = other.Rubles * 100 + other.Kopeks;
            int diff = Math.Max(0, total1 - total2);
            return new Money(diff / 100, diff % 100);
        }

        public static Money Subtract(Money m1, Money m2) => m1.Subtract(m2);

        public static Money operator ++(Money m)
        {
            int total = m.Rubles * 100 + m.Kopeks + 1;
            return new Money(total / 100, total % 100);
        }

        public static Money operator --(Money m)
        {
            int total = Math.Max(0, m.Rubles * 100 + m.Kopeks - 1);
            return new Money(total / 100, total % 100);
        }

        public static implicit operator int(Money m) => m.Rubles;

        public static explicit operator double(Money m) => m.Kopeks / 100.0;

        public static Money operator -(Money m, int kopeksToSubtract)
        {
            int total = Math.Max(0, m.Rubles * 100 + m.Kopeks - kopeksToSubtract);
            return new Money(total / 100, total % 100);
        }

        public static Money operator -(int kopeksToSubtract, Money m)
        {
            int total = Math.Max(0, kopeksToSubtract - (m.Rubles * 100 + m.Kopeks));
            return new Money(total / 100, total % 100);
        }

        public static Money operator -(Money m1, Money m2) => m1.Subtract(m2);

        public override string ToString() => $"{Rubles} руб. {Kopeks:D2} коп.";
    }

    // Файл MoneyArray.cs
    public class MoneyArray
    {
        private Money[] arr;
        public static int ArrayObjectCount { get; private set; } = 0;

        public MoneyArray()
        {
            arr = new Money[0];
            ArrayObjectCount++;
        }

        public MoneyArray(int size, bool random)
        {
            arr = new Money[size];
            if (random)
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    arr[i] = new Money(rnd.Next(0, 1000), rnd.Next(0, 100));
                }
            }
            ArrayObjectCount++;
        }

        public MoneyArray(int size)
        {
            arr = new Money[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nВвод элемента {i + 1}:");
                int r = UI.ReadInt("Введите рубли: ");
                int k = UI.ReadInt("Введите копейки: ");
                arr[i] = new Money(r, k);
            }
            ArrayObjectCount++;
        }

        public Money this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new ArgumentException("Индекс выходит за пределы массива.");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new ArgumentException("Индекс выходит за пределы массива.");
                arr[index] = value;
            }
        }

        public int Length => arr.Length;

        public void Print()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Элемент [{i}]: {arr[i]}");
            }
        }
    }

    // Файл Program.cs
    class Program
    {
        public static Money FindMax(MoneyArray array)
        {
            if (array.Length == 0) return new Money();

            Money max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                int maxKopeks = max.Rubles * 100 + max.Kopeks;
                int currentKopeks = array[i].Rubles * 100 + array[i].Kopeks;

                if (currentKopeks > maxKopeks)
                {
                    max = array[i];
                }
            }
            return max;
        }

        static void Main()
        {
            Console.WriteLine("ЧАСТЬ 1: Классы и объекты");
            Money wallet1 = new Money(5, 50);
            Money wallet2 = new Money(2, 70);

            Console.WriteLine($"Кошелек 1: {wallet1}");
            Console.WriteLine($"Кошелек 2: {wallet2}");

            Money diff1 = wallet1.Subtract(wallet2);
            Console.WriteLine($"Вычитание (метод класса): {diff1}");

            Money diff2 = Money.Subtract(wallet2, wallet1);
            Console.WriteLine($"Вычитание (статический метод): {diff2}");

            Console.WriteLine($"Создано объектов Money: {Money.ObjectCount}");


            Console.WriteLine("\nЧАСТЬ 2: Перегрузка операций");
            Money opMoney = new Money(10, 99);
            Console.WriteLine($"Исходное значение: {opMoney}");

            opMoney++;
            Console.WriteLine($"После ++: {opMoney}");

            opMoney--;
            Console.WriteLine($"После --: {opMoney}");

            int rublesOnly = opMoney;
            Console.WriteLine($"Неявное приведение к int (рубли): {rublesOnly}");

            double kopeksOnly = (double)opMoney;
            Console.WriteLine($"Явное приведение к double (копейки): {kopeksOnly}");

            Money minusInt = opMoney - 150;
            Console.WriteLine($"Вычитание 150 копеек из объекта: {minusInt}");

            Money opResult = wallet1 - wallet2;
            Console.WriteLine($"Вычитание объектов (m1 - m2): {opResult}");


            Console.WriteLine("\nЧАСТЬ 3: Класс-коллекция");
            int size = UI.ReadInt("Введите размер массива для ручного заполнения: ", 1);
            MoneyArray manualArray = new MoneyArray(size);

            Console.WriteLine("\nСгенерированный случайный массив (размер 3):");
            MoneyArray randomArray = new MoneyArray(3, true);
            randomArray.Print();

            Console.WriteLine("\nПроверка индексатора (изменение первого элемента):");
            try
            {
                randomArray[0] = new Money(999, 0);
                randomArray.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено исключение: {ex.Message}");
            }

            Money maxVal = FindMax(randomArray);
            Console.WriteLine($"\nМаксимальное значение в случайном массиве: {maxVal}");

            Console.WriteLine($"Всего создано объектов Money: {Money.ObjectCount}");
            Console.WriteLine($"Создано объектов-коллекций MoneyArray: {MoneyArray.ArrayObjectCount}");

            Console.ReadLine();
        }
    }
}