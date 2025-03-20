using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к CSV файлу:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        List<double> numbers = new List<double>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                    {
                        numbers.Add(num);
                    }
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Файл не содержит числовых данных.");
                return;
            }

            Console.WriteLine($"Среднее: {numbers.Average():F2}");
            Console.WriteLine($"Медиана: {Median(numbers):F2}");
            Console.WriteLine($"Максимум: {numbers.Max():F2}");
            Console.WriteLine($"Минимум: {numbers.Min():F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при обработке файла: " + ex.Message);
        }
    }

    static double Median(List<double> numbers)
    {
        numbers.Sort();
        int count = numbers.Count;
        if (count % 2 == 1)
        {
            return numbers[count / 2];
        }
        else
        {
            return (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
        }
    }
}
