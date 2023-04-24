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

    public class SurfaceAreaCalculator
    {
        object[] arrObjects { get; set; }
        public double[] arrSurfaceAreas { get; set; }
        private readonly ILogger logger;

        public SurfaceAreaCalculator(ILogger logger)
        {
            this.logger = logger;
        }

        public void ShowCommands()
        {
            this.logger.Log("commands:");
            this.logger.Log("- create square {double} (create a new square)");
            this.logger.Log("- create circle {double} (create a new circle)");
            this.logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            this.logger.Log("- create triangle {height} {width} (create a new triangle)");
            this.logger.Log("- print (print the calculated surface areas)");
            this.logger.Log("- calculate (calulate the surface areas of the created shapes)");
            this.logger.Log("- reset (reset)");
            this.logger.Log("- exit (exit the loop)");
        }

        public void Add(object pObject)
        {
            object[] arrObjects2;
            if (this.arrObjects == null)
            {
                this.arrObjects = new object[1];
                if (this.arrObjects != null)
                {
                    this.arrObjects[0] = pObject;
                }
            }
            else
            {
                if (this.arrObjects != null)
                {
                    arrObjects2 = new object[this.arrObjects.Length + 1];
                    int i;
                    for (i = 0; i < arrObjects2.Length; i++)
                    {
                        if (i == arrObjects2.Length - 1)
                        {
                            arrObjects2[i] = pObject;
                        }
                        else
                        {
                            arrObjects2[i] = this.arrObjects[i];
                        }
                    }
                    this.arrObjects = arrObjects2;
                }
            }
        }

        public void ReadString(string pCommand)
        {
            string[] arrCommands = pCommand.Split(' ');
            switch (arrCommands[0].ToLower())
            {
                case "create":
                    if (arrCommands.Length > 1)
                    {
                        switch (arrCommands[1].ToLower())
                        {
                            case "square":
                                Square square = new Square();
                                square.Side = double.Parse(arrCommands[2]);
                                this.Add(square);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", square.GetType().Name);
                                break;
                            case "circle":
                                Circle circle = new Circle();
                                circle.Radius = double.Parse(arrCommands[2]);
                                this.Add(circle);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", circle.GetType().Name);
                                break;
                            case "triangle":
                                Triangle triangle = new Triangle();
                                triangle.Height = double.Parse(arrCommands[2]);
                                triangle.Width = double.Parse(arrCommands[3]);
                                this.Add(triangle);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", triangle.GetType().Name);
                                break;
                            case "rectangle":
                                Rectangle rectangle = new Rectangle();
                                rectangle.Height = double.Parse(arrCommands[2]);
                                rectangle.Width = double.Parse(arrCommands[3]);
                                this.Add(rectangle);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", rectangle.GetType().Name);
                                break;
                            default:
                                goto ShowCommands;
                        }
                    }
                    else
                    {
                        ShowCommands();
                    }
                    this.ReadString(Console.ReadLine());
                    break;
                case "calculate":
                    this.CalculateSurfaceAreas();
                    this.ReadString(Console.ReadLine());
                    break;
                case "print":
                    if (arrSurfaceAreas != null)
                    {
                        for (int i = 0; i < arrSurfaceAreas.Length; i++)
                        {
                            Console.WriteLine("[{0}] {1} surface area is {2}", i, arrObjects[i].GetType().Name, arrSurfaceAreas[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no surface areas to print");
                    }
                    this.ReadString(Console.ReadLine());
                    break;
                case "reset":
                    this.arrSurfaceAreas = null;
                    this.arrObjects = null;
                    Console.WriteLine("Reset state!!");
                    this.ReadString(Console.ReadLine());
                    break;
                case "exit":
                    break;
                default:
                    ShowCommands:
                    this.logger.Log("Unknown command!!!");
                    this.logger.Log("commands:");
                    this.logger.Log("- create square {double} (create a new square)");
                    this.logger.Log("- create circle {double} (create a new circle)");
                    this.logger.Log("- create rectangle {height} {width} (create a new rectangle)");
                    this.logger.Log("- create triangle {height} {width} (create a new triangle)");
                    this.logger.Log("- print (print the calculated surface areas)");
                    this.logger.Log("- calculate (calulate the surface areas of the created shapes)");
                    this.logger.Log("- reset (reset)");
                    this.logger.Log("- exit (exit the loop)");
                    this.ReadString(Console.ReadLine());
                    break;
            }
        }

        public void CalculateSurfaceAreas()
        {
            try
            {
                if (this.arrObjects != null)
                {
                    this.arrSurfaceAreas = new double[this.arrObjects.Length];
                    for (int i = 0; i < this.arrObjects.Length; i++)
                    {
                        if (this.arrObjects[i].GetType().Name == "Circle")
                        {
                            this.arrSurfaceAreas[i] = ((Circle)this.arrObjects[i]).CalculateSurfaceArea();
                        }
                        else
                        {
                            if (this.arrObjects[i].GetType().Name == "Rectangle")
                            {
                                this.arrSurfaceAreas[i] = ((Rectangle)this.arrObjects[i]).CalculateSurfaceArea();
                            }
                            else
                            {
                                if (this.arrObjects[i].GetType().Name == "Square")
                                {
                                    this.arrSurfaceAreas[i] = ((Square)this.arrObjects[i]).CalculateSurfaceArea();
                                }
                                else
                                {
                                    if (this.arrObjects[i].GetType().Name == "Triangle")
                                    {
                                        this.arrSurfaceAreas[i] = ((Triangle)this.arrObjects[i]).CalculateSurfaceArea();
                                    }
                                    else
                                    {
                                        throw new Exception("Cannot calculate surface area of unkown object!!!");
                                    }
                                }
                            }
                        }
                    }
                }
                else if (this.arrObjects == null)
                {
                    throw new Exception("arrItems is null!!");
                }

            }
            catch (Exception ex)
            {
                this.logger.Log(ex.ToString());
                this.arrObjects = new object[0];
            }
        }
    }

    internal class Logger
    {
        public Logger()
        {
        }

        public void Log(string pLog)
        {
            Console.WriteLine(pLog);
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
