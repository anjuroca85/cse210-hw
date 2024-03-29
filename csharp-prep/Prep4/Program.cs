using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int number;
        int sum = 0;
        double avg = 0.0;
        int largest = -999999999;
        int positiveNum = 999999999;


        List<int> numberList = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            numberList.Add(number);
        } while (number != 0);

        foreach (int numberL in numberList)
        {
            if (numberL != 0)
            {
                sum += numberL;
                avg = (double)sum / (numberList.Count - 1);

                if (numberL < positiveNum && numberL > 0)
                {
                    positiveNum = numberL;
                }

                if (numberL > largest)
                {
                    largest = numberL;
                }
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        //Console.WriteLine($"The average is: {avg:N15}");
        //Console.WriteLine($"The average is: {avg:F15}");
        Console.WriteLine($"The largest number is: {largest}");
        if (positiveNum != 999999999)
        {
            Console.WriteLine($"The smallest positive number is: {positiveNum}");
        }

        Console.WriteLine("The sorted list is:");
        numberList.Sort();
        foreach (int num in numberList)
        {
            if (num != 0)
            {
                Console.WriteLine(num);
            }
        }
    }
}