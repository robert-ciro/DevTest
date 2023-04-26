namespace Refactoring.Commands
{
    using System;
    using Refactoring.Entities;
    using Refactoring.ValueTypes;
    
    public class SurfaceAreaCommandExecutor
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private readonly ILogger logger;
        
        public SurfaceAreaCommandExecutor(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
            this.logger = logger;
        }

        public void ExecuteCommand(string command)
        {
            string[] arrCommands = command.Split(' ');
            switch (arrCommands[0].ToLower())
            {
                case "create":
                    if (arrCommands.Length > 1)
                    {
                        switch (arrCommands[1].ToLower())
                        {
                            case "square":
                                Square square = new Square(double.Parse(arrCommands[2]));
                                surfaceAreaCalculator.Add(square);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Square)} created!");
                                break;
                            case "circle":
                                Circle circle = new Circle(double.Parse(arrCommands[2]));
                                surfaceAreaCalculator.Add(circle);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Circle)} created!");
                                break;
                            case "triangle":
                                var triangleDimension = new Dimension(height: double.Parse(arrCommands[2]), width: double.Parse(arrCommands[3]));
                                var triangle = new Triangle(triangleDimension);
                                surfaceAreaCalculator.Add(triangle);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Triangle)} created!");
                                break;
                            case "rectangle":
                                var rectangleDimension = new Dimension(height: double.Parse(arrCommands[2]), width: double.Parse(arrCommands[3]));
                                var rectangle = new Rectangle(rectangleDimension);
                                surfaceAreaCalculator.Add(rectangle);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Rectangle)} created!");
                                break;
                            case "trapezoid":
                                var trapezoid = new Trapezoid(
                                    top: double.Parse(arrCommands[2]),
                                    bottom: double.Parse(arrCommands[3]),
                                    height: double.Parse(arrCommands[4]));
                                surfaceAreaCalculator.Add(trapezoid);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                Console.WriteLine($"{nameof(Trapezoid)} created!");
                                break;
                            default:
                                goto ShowCommands;
                        }
                    }
                    else
                    {
                        ShowCommands();
                    }
                    this.ExecuteCommand(Console.ReadLine());
                    break;
                case "calculate":
                    surfaceAreaCalculator.CalculateSurfaceAreas();
                    ExecuteCommand(Console.ReadLine());
                    break;
                case "print":
                    if (surfaceAreaCalculator.SurfaceAreas.Count is 0)
                    {
                        Console.WriteLine("There are no surface areas to print");
                    }
                    else
                    {
                        for (int i = 0; i < surfaceAreaCalculator.SurfaceAreas.Count; i++)
                        {
                            Console.WriteLine("[{0}] {1} surface area is {2}", i, surfaceAreaCalculator.GeometricShapes[i].GetType().Name, surfaceAreaCalculator.SurfaceAreas[i]);
                        }
                    }

                    ExecuteCommand(Console.ReadLine());
                    break;
                case "reset":
                    surfaceAreaCalculator.Reset();
                    Console.WriteLine("Reset state!!");
                    ExecuteCommand(Console.ReadLine());
                    break;
                case "exit":
                    break;
                case "show":
                    ShowCommands();
                    ExecuteCommand(Console.ReadLine());
                    break;
                default:
                    ShowCommands:
                    this.logger.Log("Unknown command!!!");
                    this.ShowCommands();
                    ExecuteCommand(Console.ReadLine());
                    break;
            }
        }

        private void ShowCommands()
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
    }
}