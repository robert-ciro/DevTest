namespace Refactoring.Commands
{
    using System;
    using Refactoring.Entities;
    using Refactoring.ValueTypes;

    public class CreateSurfaceAreaCommand : IParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateSurfaceAreaCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public bool Execute(params string[] commands)
        {
            if(commands.Length is 0)
                return false;
            
             switch (commands[0].ToLower())
            {
                case "square":
                    CreateSquare(double.Parse(commands[1]));
                    break;
                case "circle":
                    CreateCircle(double.Parse(commands[1]));
                    break;
                case "triangle":
                    CreateTriangle(double.Parse(commands[1]), double.Parse(commands[2]));
                    break;
                case "rectangle":
                    CreateRectangle(double.Parse(commands[1]), double.Parse(commands[2]));
                    break;
                case "trapezoid":
                    CreateTrapezoid(double.Parse(commands[1]), double.Parse(commands[2]), double.Parse(commands[3]));
                    break;
                default:
                    return false;
            }
             
            return true;
        }

        private void CreateTrapezoid(double top, double bottom, double height)
        {
            var trapezoid = new Trapezoid(top, bottom, height);
            surfaceAreaCalculator.Add(trapezoid);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            logger.Log($"{nameof(Trapezoid)} created!");
        }

        private void CreateRectangle(double height, double width)
        {
            var dimension = new Dimension(height, width);
            var rectangle = new Rectangle(dimension);
            surfaceAreaCalculator.Add(rectangle);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            logger.Log($"{nameof(Rectangle)} created!");
        }

        private void CreateTriangle(double height, double width)
        {
            var dimension = new Dimension(height, width);
            var triangle = new Triangle(dimension);
            surfaceAreaCalculator.Add(triangle);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            logger.Log($"{nameof(Triangle)} created!");
        }

        private void CreateCircle(double radius)
        {
            var circle = new Circle(radius);
            surfaceAreaCalculator.Add(circle);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            Console.WriteLine($"{nameof(Circle)} created!");
        }

        private void CreateSquare(double side)
        {
            var square = new Square(side);
            surfaceAreaCalculator.Add(square);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            logger.Log($"{nameof(Square)} created!");
        }
    }
}