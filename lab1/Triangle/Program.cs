using System;

namespace Triangle
{
    public class Program
    {
        private static string GetTriangleType(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a || a < 0 || b < 0 || c < 0)
            {
                return "не треугольник";
            }
            else if (a != b && a != c && b != c)
            {
                return "обычный";
            }
            else if (a == b && b == c)
            {
                return "равносторонний";
            }
            else
            {
                return "равнобедренный";
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Write("Неизвестная ошибка");
            }
            else
            {
                try
                {
                    double a = double.Parse(args[0]);
                    double b = double.Parse(args[1]);
                    double c = double.Parse(args[2]);

                    if (a > double.MaxValue || b > double.MaxValue || c > double.MaxValue)
                    {
                        Console.Write("Неизвестная ошибка");
                    }
                    else
                    {
                        Console.Write(GetTriangleType(a, b, c));
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Неизвестная ошибка");
                }
            }
        }
    }
}
