using System;
using System.Drawing;

namespace Geometry
{
    public abstract class Figure
    {
        string name;
        public Figure(string Name)
        {
            name = Name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected abstract double Area2 { get; }
        public abstract double Area();
        public virtual void Print()
        {
            Console.WriteLine($"Название: {name}");
        }
    }

    public class Triangle: Figure
    {
        double a;
        double b;
        double c;
        public Triangle(string Name, double A, double B, double C):base(Name)
        {
            a = A;
            b = B;
            c = C;
        }
        public void GetABC(out double A, out double B, out double C)
        {
            A = a;
            B = b;
            C = c;
        }
        public void SetABC(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }
        protected override double Area2
        {
            get
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            }
        }
        public override double Area()
        {
            return Area2;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Стороны: a = {a}, b = {b}, c = {c}");
        }
    }

    public class TriangleColor : Triangle
    {
        Color background;
        public TriangleColor(string Name, double A, double B, double C, Color BackGround):base(Name, A, B, C)
        {
            background = BackGround;
        }
        public Color BackGround
        {
            get { return background; }
            set { background = value; }
        }
        protected override double Area2 => base.Area2;
        public override double Area()
        {
            return Area2;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Фон: {background.Name}");
        }
    }
}
