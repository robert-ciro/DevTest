using System;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            Greet(logger);
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator(logger);
            surfaceAreaCalculator.ShowCommands();
            surfaceAreaCalculator.ReadString(Console.ReadLine());
            Console.ReadKey();
        }

        private static void Greet(ILogger logger)
        {
            logger.Log(" -------------------------------------------------------------------------- ");
            logger.Log("| Greetings and salutations fellow developer :D                            |");
            logger.Log("|                                                                          |");
            logger.Log("| If you are reading this we probably want to know if you know your stuff. |");
            logger.Log("|                                                                          |");
            logger.Log("| How would you improve this code?                                         |");
            logger.Log("| We challenge you to refactor this and show us how awesome you are ;)     |");
            logger.Log("| We also really like trapezoids so could you also implement that for us?  |");
            logger.Log("|                                                                          |");
            logger.Log("|                                                               Good luck! |");
            logger.Log(" --------------------------------------------------------------------------");
        }
    }
    public class Circle
    {
        public double Radius { get; set; }

        public double CalculateSurfaceArea()
        {
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
    public class Rectangle
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double CalculateSurfaceArea()
        {
            return Height * Width;
        }
    }
    public class Square
    {
        public double Side { get; set; }

        public double CalculateSurfaceArea()
        {
            return this.Side * this.Side;
        }
    }
    public class Triangle
    {
        double height;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        double width;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 0.5 * (this.height * this.width);
        }
    }
}
