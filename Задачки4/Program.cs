using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Задачки4
{
    internal class Program
    {
        static void test1()
        {
            /*Создать List на 64 элемента, скачать из интернета 32 пары картинок (любых). В List
            должно содержаться по 2 одинаковых картинки. Необходимо перемешать List с
            картинками. Вывести в консоль перемешанные номера (изначальный List и полученный
            List). Перемешать любым способом.*/
            Console.WriteLine("Упражнение 1");
            
            List<string> images = new List<string>();
            
            for (int i = 1; i <= 32; i++)
            {
                string imagePath = Path.Combine("Images", $"image{i}.jpg"); 
                images.Add(imagePath);
                images.Add(imagePath);
            }

            Console.WriteLine("Оригинальный список:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"{i+1}: {images[i]}");
            }

            
            Random rng = new Random();
            int n = images.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n);
                var temp = images[n];
                images[n] = images[k];
                images[k] = temp;
            }

            Console.WriteLine("\nПеремешанный список:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"{i+1}: {images[i]}");
            }

        }
        static void Main(string[] args)
        {
            test1();
        }
    }
}
