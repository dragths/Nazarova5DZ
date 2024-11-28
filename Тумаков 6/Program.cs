using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;

namespace Тумаков_6
{
    public enum MounthOfYear
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }
    internal class Program
    {
        
         static void task1()
         {
           /* Написать программу, которая вычисляет число гласных и согласных букв в
            файле.Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
            заносится в массив символов.Количество гласных и согласных букв определяется проходом
            по массиву.Предусмотреть метод, входным параметром которого является массив символов.
            Метод вычисляет количество гласных и согласных букв.*/

             Console.WriteLine("Упражнение 6.1");
             string fileName = "Text.txt";
             char[]letters = File.ReadAllText(fileName).ToCharArray();
             int countsogl,countglas;
             Count(letters, out countsogl, out countglas);
             Console.WriteLine($"Число гласных: {countglas}");
             Console.WriteLine($"Число согласных: {countsogl}");
         }
      
       
        static void task2()
        {
            /*Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).*/
            Console.WriteLine("Упражнение 6.2");
            Console.WriteLine("Введите размерность первой матрицы (строки, столбцы): ");
            int.TryParse(Console.ReadLine(),out var strA);
            int.TryParse(Console.ReadLine(),out var ctolbA);
            int[,] A = new int[strA, ctolbA];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write($"A[{i},{j}] = ");
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Ввод второй матрицы
            Console.WriteLine("Введите размерность второй матрицы (строки, столбцы): ");
            int.TryParse(Console.ReadLine(), out var strB);
            int.TryParse(Console.ReadLine(), out var ctolbB);
            int[,] B = new int[strB, ctolbB];

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"B[{i},{j}] = ");
                    B[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Проверка на возможность умножения матриц
            if (ctolbA != strB)
            {
                Console.WriteLine("Матрицы нельзя перемножить: количество столбцов первой матрицы должно совпадать с количеством строк второй.");
                return;
            }

            // Умножение матриц
            Console.WriteLine("\nМатрица A:");
            Print(A);
            Console.WriteLine("\nМатрица B:");
            Print(B);
            Console.WriteLine("\nМатрица C = A * B:");
            int[,] C = Multiplication(A, B);
            Print(C);
        }


        
        static void task3()
        {
            /*Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12,30], в котором будет храниться температура
            для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру.*/
            Console.WriteLine("Упражнение 6.3");
            int[,] temperature = RandomMass();

            double[] Temperatures = CredTemp(temperature);

         
            Console.WriteLine("Средние температуры по месяцам:");
            for (int month = 1; month < Temperatures.Length; month++)
            {
                MounthOfYear Mounth = (MounthOfYear)(month);
                Console.WriteLine($"Месяц {Mounth}: {Temperatures[month]:F2} °C");
            }

            
            Array.Sort(Temperatures);

            
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var temp in Temperatures)
            {
                Console.WriteLine($"{temp:F2} °C");
            }
        }

        

        static void task4()
        {
            /*Упражнение 6.1 выполнить с помощью коллекции List<T>.*/
            Console.WriteLine("Упражнение 6.1");
            string fileName = "Text.txt";

            // Считывание содержимого файла в список символов
            List<char> letters = new List<char>(File.ReadAllText(fileName));
            int countsogl, countglas;

            Count2(letters, out countsogl, out countglas);
            Console.WriteLine($"Число гласных: {countglas}");
            Console.WriteLine($"Число согласных: {countsogl}");
        }
       
        static void task5()
        {
            /*Упражнение 6.2 выполнить с помощью коллекций LinkedList<LinkedList<T>>.*/
            Console.WriteLine("Упражнение 6.2");
            // Ввод первой матрицы
            Console.WriteLine("Введите размерность первой матрицы (строки, столбцы): ");
            int.TryParse(Console.ReadLine(), out var strA);
            int.TryParse(Console.ReadLine(), out var ctolbA);
            var A = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < strA; i++)
            {
                var row = new LinkedList<int>();
                for (int j = 0; j < ctolbA; j++)
                {
                    Console.Write($"A[{i},{j}] = ");
                    row.AddLast(int.Parse(Console.ReadLine()));
                }
                A.AddLast(row);
            }

            // Ввод второй матрицы
            Console.WriteLine("Введите размерность второй матрицы (строки, столбцы): ");
            int.TryParse(Console.ReadLine(), out var strB);
            int.TryParse(Console.ReadLine(), out var ctolbB);
            var B = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < strB; i++)
            {
                var row = new LinkedList<int>();
                for (int j = 0; j < ctolbB; j++)
                {
                    Console.Write($"B[{i},{j}] = ");
                    row.AddLast(int.Parse(Console.ReadLine()));
                }
                B.AddLast(row);
            }

            // Проверка на возможность умножения матриц
            if (ctolbA != strB)
            {
                Console.WriteLine("Матрицы нельзя перемножить: количество столбцов первой матрицы должно совпадать с количеством строк второй.");
                return;
            }

            // Умножение матриц
            Console.WriteLine("\nМатрица A:");
            Print(A);
            Console.WriteLine("\nМатрица B:");
            Print(B);
            Console.WriteLine("\nМатрица C = A * B:");
            var C = Multiplication(A, B);
            Print(C);
        }

        static void task6()
        {
            /*Написать программу для упражнения 6.3, использовав класс
            Dictionary<TKey, TValue>. В качестве ключей выбрать строки – названия месяцев, а в
            качестве значений – массив значений температур по дням.*/
            Console.WriteLine("Упражнение 6.3");
            var temperature = RandomMas();

            var Temperatures = CredTemp1(temperature);

            Console.WriteLine("Средние температуры по месяцам:");
            foreach (var month in Temperatures.Keys)
            {
                Console.WriteLine($"Месяц {month}: {Temperatures[month]:F2} °C");
            }

            var sortedTemperatures = new List<double>(Temperatures.Values);
            sortedTemperatures.Sort();

            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var temp in sortedTemperatures)
            {
                Console.WriteLine($"{temp:F2} °C");
            }
        }
        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
            task4();
            task5();
            task6();
         
        }
        static void Count(char[] text, out int countsogl, out int countglas)
        {
            countsogl = 0;
            countglas = 0;

            string sogl = "йцкнгшщзхъждлрпвфчсмьтбЙЦКНГШЩЗХЪЖДЛРПВФЧСМТБЬ";

            foreach (char bukva in text)
            {
                if (char.IsLetter(bukva))
                {
                    if (sogl.Contains(bukva))
                    {
                        countsogl++;
                    }
                    else
                    {
                        countglas++;
                    }
                }
                if ((countglas == 0) & (countsogl == 0))
                {
                    Console.WriteLine("В тексте нет букв");
                }
            }
        }

        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static int[,] Multiplication(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        static int[,] RandomMass()
        {
            int[,] temperatures = new int[12, 30];
            Random random = new Random();

            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperatures[month, day] = random.Next(-30, 30);
                }
            }

            return temperatures;
        }

        static double[] CredTemp(int[,] temperature)
        {
            double[] averages = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double sum = 0;

                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }

                averages[month] = sum / 30; // Вычисление средней температуры
            }

            return averages;
        }
        static void Count2(List<char> text, out int countsogl, out int countglas)
        {
            countsogl = 0;
            countglas = 0;

            string sogl = "йцкнгшщзхъждлрпвфчсмьтбЙЦКНГШЩЗХЪЖДЛРПВФЧСМТБЬ";
            List<char> vowels = new List<char>(); // Список для хранения гласных
            List<char> consonants = new List<char>(); // Список для хранения согласных

            foreach (char bukva in text)
            {
                if (char.IsLetter(bukva))
                {
                    if (sogl.Contains(bukva))
                    {
                        consonants.Add(bukva);
                        countsogl++;
                    }
                    else
                    {
                        vowels.Add(bukva);
                        countglas++;
                    }
                }
            }

            // Проверка на наличие букв
            if (countglas == 0 && countsogl == 0)
            {
                Console.WriteLine("В тексте нет букв");
            }
        }
        static Dictionary<string, int[]> RandomMas()
        {
            var temperatures = new Dictionary<string, int[]>();
            var random = new Random();

            foreach (var month in Enum.GetNames(typeof(MounthOfYear)))
            {
                var days = new int[30];
                for (int day = 0; day < 30; day++)
                {
                    days[day] = random.Next(-30, 30);
                }
                temperatures.Add(month, days);
            }

            return temperatures;
        }

        static Dictionary<string, double> CredTemp1(Dictionary<string, int[]> temperature)
        {
            var averages = new Dictionary<string, double>();

            foreach (var month in temperature.Keys)
            {
                double sum = 0;
                foreach (var day in temperature[month])
                {
                    sum += day;
                }
                averages.Add(month, sum / 30);
            }

            return averages;
        }
        static LinkedList<LinkedList<int>> Multiplication(LinkedList<LinkedList<int>> A, LinkedList<LinkedList<int>> B)
        {
            int rowsA = A.Count;
            int colsA = A.First.Value.Count;
            int colsB = B.First.Value.Count;

            var C = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < rowsA; i++)
            {
                var rowC = new LinkedList<int>();
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;

                    // Получаем i-ю строку из A
                    var rowA = GetRow(A, i);

                    // Получаем j-ю колонку из B
                    var colB = GetColumn(B, j);

                    // Перемножаем элементы строки и колонки
                    var enumeratorA = rowA.GetEnumerator();
                    var enumeratorB = colB.GetEnumerator();

                    while (enumeratorA.MoveNext() && enumeratorB.MoveNext())
                    {
                        sum += enumeratorA.Current * enumeratorB.Current;
                    }

                    rowC.AddLast(sum);
                }
                C.AddLast(rowC);
            }

            return C;
        }

        static LinkedList<int> GetRow(LinkedList<LinkedList<int>> matrix, int rowIndex)
        {
            var enumerator = matrix.GetEnumerator();
            for (int i = 0; i <= rowIndex; i++)
            {
                enumerator.MoveNext();
            }
            return enumerator.Current;
        }

        static LinkedList<int> GetColumn(LinkedList<LinkedList<int>> matrix, int colIndex)
        {
            var column = new LinkedList<int>();
            foreach (var row in matrix)
            {
                var enumerator = row.GetEnumerator();
                for (int i = 0; i <= colIndex; i++)
                {
                    enumerator.MoveNext();
                }
                column.AddLast(enumerator.Current);
            }
            return column;
        }

        static void Print(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var value in row)
                {
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

