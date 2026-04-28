namespace CS_DemoStruct
{
    public struct Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        // Constructor
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Method
        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }

        public override string ToString()
        {
            return $"({X}), ({Y})";
        }
    }
}