namespace Refactoring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SurfaceAreaCalculator
    {
        private List<IGeometricShape> geometricShapes;
        public List<double> surfaceAreas { get; set; }
        private readonly ILogger logger;

        public SurfaceAreaCalculator(ILogger logger)
        {
            this.geometricShapes = new List<IGeometricShape>();
            this.surfaceAreas = new List<double>();
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

        public void Add(IGeometricShape geometryShape)
        {
            this.geometricShapes.Add(geometryShape);
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
                    if (surfaceAreas != null)
                    {
                        for (int i = 0; i < surfaceAreas.Count; i++)
                        {
                            Console.WriteLine("[{0}] {1} surface area is {2}", i, geometricShapes[i].GetType().Name, surfaceAreas[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no surface areas to print");
                    }
                    this.ReadString(Console.ReadLine());
                    break;
                case "reset":
                    this.surfaceAreas = new List<double>();
                    this.geometricShapes = new List<IGeometricShape>();
                    Console.WriteLine("Reset state!!");
                    this.ReadString(Console.ReadLine());
                    break;
                case "exit":
                    break;
                default:
                    ShowCommands:
                    this.logger.Log("Unknown command!!!");
                    this.ShowCommands();
                    this.ReadString(Console.ReadLine());
                    break;
            }
        }

        public void CalculateSurfaceAreas()
        {
            try
            {
                this.surfaceAreas = new List<double>();
                foreach (var geometricShape in this.geometricShapes)
                {
                    this.surfaceAreas.Add(geometricShape.CalculateSurfaceArea());
                }
            }
            catch (Exception ex)
            {
                this.logger.Log(ex.ToString());
                this.geometricShapes = new List<IGeometricShape>();
            }
        }
    }
}