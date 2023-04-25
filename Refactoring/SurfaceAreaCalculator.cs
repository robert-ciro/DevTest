namespace Refactoring
{
    using System;
    using System.Collections.Generic;
    using Refactoring.Entities;
    using Refactoring.ValueTypes;

    public class SurfaceAreaCalculator
    {
        private List<IGeometricShape> geometricShapes;
        private List<double> surfaceAreas;
        private readonly ILogger logger;
        
        public IReadOnlyList<double> SurfaceAreas => this.surfaceAreas.AsReadOnly();

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
                                Square square = new Square(double.Parse(arrCommands[2]));
                                this.Add(square);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Square)} created!");
                                break;
                            case "circle":
                                Circle circle = new Circle(double.Parse(arrCommands[2]));
                                this.Add(circle);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Circle)} created!");
                                break;
                            case "triangle":
                                var triangleDimension = new Dimension(height: double.Parse(arrCommands[2]), width: double.Parse(arrCommands[3]));
                                Triangle triangle = new Triangle(triangleDimension);
                                this.Add(triangle);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Triangle)} created!");
                                break;
                            case "rectangle":
                                var rectangleDimension = new Dimension(height: double.Parse(arrCommands[2]), width: double.Parse(arrCommands[3]));
                                Rectangle rectangle = new Rectangle(rectangleDimension);
                                this.Add(rectangle);
                                this.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Rectangle)} created!");
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
                    if (surfaceAreas.Count is 0)
                    {
                        Console.WriteLine("There are no surface areas to print");
                    }
                    else
                    {
                        for (int i = 0; i < surfaceAreas.Count; i++)
                        {
                            Console.WriteLine("[{0}] {1} surface area is {2}", i, geometricShapes[i].GetType().Name, surfaceAreas[i]);
                        }
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