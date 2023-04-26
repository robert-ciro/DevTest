namespace Refactoring.Commands
{
    using System;
    using Refactoring.Entities;
    using Refactoring.ValueTypes;
    
    public class SurfaceAreaCommandExecutor
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private readonly ILogger logger;
        private readonly IUserInterface userInterface;

        public SurfaceAreaCommandExecutor(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator, IUserInterface userInterface)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
            this.logger = logger;
            this.userInterface = userInterface;
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
                                logger.Log($"{nameof(Square)} created!");
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
                                logger.Log($"{nameof(Triangle)} created!");
                                break;
                            case "rectangle":
                                var rectangleDimension = new Dimension(height: double.Parse(arrCommands[2]), width: double.Parse(arrCommands[3]));
                                var rectangle = new Rectangle(rectangleDimension);
                                surfaceAreaCalculator.Add(rectangle);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                logger.Log($"{nameof(Rectangle)} created!");
                                break;
                            case "trapezoid":
                                var trapezoid = new Trapezoid(
                                    top: double.Parse(arrCommands[2]),
                                    bottom: double.Parse(arrCommands[3]),
                                    height: double.Parse(arrCommands[4]));
                                surfaceAreaCalculator.Add(trapezoid);
                                surfaceAreaCalculator.CalculateSurfaceAreas();
                                logger.Log($"{nameof(Trapezoid)} created!");
                                break;
                            default:
                                goto ShowCommands;
                        }
                    }
                    else
                    {
                        new HelpCommand(logger).Execute();
                    }
                    this.ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "calculate":
                    surfaceAreaCalculator.CalculateSurfaceAreas();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "print":
                    if (surfaceAreaCalculator.SurfaceAreas.Count is 0)
                    {
                        logger.Log("There are no surface areas to print");
                    }
                    else
                    {
                        for (int i = 0; i < surfaceAreaCalculator.SurfaceAreas.Count; i++)
                        {
                            logger.Log($"[{i}] {surfaceAreaCalculator.GeometricShapes[i].GetType().Name} surface area is {surfaceAreaCalculator.SurfaceAreas[i]}");
                        }
                    }

                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "reset":
                    surfaceAreaCalculator.Reset();
                    logger.Log("Reset state!!");
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "exit":
                    break;
                case "show":
                    new HelpCommand(logger).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                default:
                    ShowCommands:
                    this.logger.Log("Unknown command!!!");
                    new HelpCommand(logger).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
            }
        }
    }
}