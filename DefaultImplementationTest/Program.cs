using System;

namespace DefaultImplementation
{
    #region Displaying
    interface IDisplayable
    {
        string Description { get; }
        void Display();
    }

    interface IDisplayToConsole : IDisplayable
    {   
        void IDisplayable.Display()
        {
            Console.WriteLine(this.Description);
        }
    }

    interface IWriteToFile : IDisplayable
    {
        void IDisplayable.Display()
        {
            System.IO.File.AppendAllText("output.txt", this.Description + Environment.NewLine);
        }
    }
    #endregion

    interface IPolygon
    {
        int NumberOfSides { get; }
        int SideLength { get; set; }
        int Circumference
        {
            get => this.SideLength * this.NumberOfSides;
            set => this.SideLength = value / this.NumberOfSides;
        }
    }


    class Square: IPolygon, IWriteToFile
    {
        public int NumberOfSides { get; } = 4;
        public int SideLength { get; set; } = 10;

        public string Description => $"Square with side length {this.SideLength} and circumference {(this as IPolygon).Circumference}";

        public Square(int initialSideLength)
        {
            this.SideLength = initialSideLength;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var p = new Square(initialSideLength: 10);

            Display(p);
            (p as IPolygon).Circumference = 20;
            Display(p);
        }

        static void Display(IDisplayable displayable)
        {
            displayable.Display();
        }
    }
}
