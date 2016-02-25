using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.PerimeterArea
{
    class PerimeterArea
    {
        class Point
        {
            private int x;
            private int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X
            {
                get { return x; }
                set { x = value; }
            }

            public int Y
            {
                get { return y; }
                set { y = value; }
            }
        }

        class Polygon
        {
            private double perimeter;
            private double area;

            public Polygon(List<Point> vertices)
            {
                for (int i = 0; i < vertices.Count - 1; i++)
                {
                    perimeter 
                        += Math.Sqrt(Math.Pow(vertices[i].X - vertices[i + 1].X, 2)
                        + Math.Pow(vertices[i].Y - vertices[i + 1].Y, 2));
                }
                for (int i = 0; i < vertices.Count - 1; i++)
                {
                    area += ((double)vertices[i].X * vertices[i + 1].Y
                        - (double)vertices[i].Y * vertices[i + 1].X) / 2;
                }
            }

            public double Perimeter
            {
                get { return perimeter; }
            }

            public double Area
            {
                get { return Math.Abs(area); }
            }            
        }

        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(-2, 1));                    
            points.Add(new Point(1, 3));
            points.Add(new Point(5, 1));
            points.Add(new Point(1, 2));
            points.Add(new Point(1, 1));
            points.Add(new Point(3, -2));
            points.Add(new Point(-2, 1));
            Polygon shape = new Polygon(points);

            Console.WriteLine("Perimeter: {0:0.00}", shape.Perimeter);
            Console.WriteLine("Area: {0:0.00}", shape.Area);
        }
    }
}
