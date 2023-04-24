namespace Refactoring
{
    using System;

    public class SurfaceAreaCalculator
    {
        IGeometricShape[] geometricShapes { get; set; }
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

        public void Add(IGeometricShape geometryShape)
        {
            IGeometricShape[] arrObjects2;
            if (this.geometricShapes == null)
            {
                this.geometricShapes = new IGeometricShape[1];
                if (this.geometricShapes != null)
                {
                    this.geometricShapes[0] = geometryShape;
                }
            }
            else
            {
                if (this.geometricShapes != null)
                {
                    arrObjects2 = new IGeometricShape[this.geometricShapes.Length + 1];
                    int i;
                    for (i = 0; i < arrObjects2.Length; i++)
                    {
                        if (i == arrObjects2.Length - 1)
                        {
                            arrObjects2[i] = geometryShape;
                        }
                        else
                        {
                            arrObjects2[i] = this.geometricShapes[i];
                        }
                    }
                    this.geometricShapes = arrObjects2;
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
                            Console.WriteLine("[{0}] {1} surface area is {2}", i, geometricShapes[i].GetType().Name, arrSurfaceAreas[i]);
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
                    this.geometricShapes = null;
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
                if (this.geometricShapes != null)
                {
                    this.arrSurfaceAreas = new double[this.geometricShapes.Length];
                    for (int i = 0; i < this.geometricShapes.Length; i++)
                    {
                        if (this.geometricShapes[i].GetType().Name == "Circle")
                        {
                            this.arrSurfaceAreas[i] = ((Circle)this.geometricShapes[i]).CalculateSurfaceArea();
                        }
                        else
                        {
                            if (this.geometricShapes[i].GetType().Name == "Rectangle")
                            {
                                this.arrSurfaceAreas[i] = ((Rectangle)this.geometricShapes[i]).CalculateSurfaceArea();
                            }
                            else
                            {
                                if (this.geometricShapes[i].GetType().Name == "Square")
                                {
                                    this.arrSurfaceAreas[i] = ((Square)this.geometricShapes[i]).CalculateSurfaceArea();
                                }
                                else
                                {
                                    if (this.geometricShapes[i].GetType().Name == "Triangle")
                                    {
                                        this.arrSurfaceAreas[i] = ((Triangle)this.geometricShapes[i]).CalculateSurfaceArea();
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
                else if (this.geometricShapes == null)
                {
                    throw new Exception("arrItems is null!!");
                }

            }
            catch (Exception ex)
            {
                this.logger.Log(ex.ToString());
                this.geometricShapes = new IGeometricShape[0];
            }
        }
    }
}