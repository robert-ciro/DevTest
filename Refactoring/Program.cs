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
}
