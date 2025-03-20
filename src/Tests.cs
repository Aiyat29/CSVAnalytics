using System;
using System.Collections.Generic;

class Tests
{
    public static void RunTests()
    {
        TestMedian();
    }

    private static void TestMedian()
    {
        List<double> test1 = new List<double> { 1, 2, 3, 4, 5 };
        Console.WriteLine(Median(test1) == 3 ? "Тест 1 пройден" : "Тест 1 не пройден");

        List<double> test2 = new List<double> { 1, 2, 3, 4 };
        Console.WriteLine(Median(test2) == 2.5 ? "Тест 2 пройден" : "Тест 2 не пройден");
    }

    private static double Median(List<double> numbers)
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
