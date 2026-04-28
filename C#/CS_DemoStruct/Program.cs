using System;

namespace CS_DemoStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 20);
            p1.Display();

            MovePoint(p1);

            // Value type behavior
            p1.Display();

            Console.WriteLine(p1);
        }

        static void MovePoint(Point point)
        {
            Point newPoint = new Point(point.X + 5, point.Y + 5);
            newPoint.Display();
        }
    }
}
