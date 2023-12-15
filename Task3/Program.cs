using System;
using System.Drawing;
using Geometry;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr1 = new Triangle("Равносторонний", 5, 5, 5);
            tr1.Print();
            Console.WriteLine("Площадь: " + Math.Round(tr1.Area(), 2));
            TriangleColor tr2 = new TriangleColor("Прямоугольный", 3, 4, 5, Color.Red);
            Console.WriteLine();
            tr2.Print();
            Console.WriteLine("Площадь: " + Math.Round(tr2.Area(), 2));
        }
    }
}
