using System;

namespace Refactoring
{
    using System.Linq;
    using Refactoring.Commands;

    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var surfaceAreaCalculator = new SurfaceAreaCalculator(logger);
            var consoleUserInterface = new ConsoleUserInterface();
            var commandFactory = new SurfaceAreaCommandFactory(logger, surfaceAreaCalculator);
            
            Greet(logger);

            var result = ExecuteCommand(commandFactory.Create("show"));

            while (result.shouldQuit is false)
            {
                var input = consoleUserInterface.ReadMessage();
                var commands = input.Split(' ');
                var command = commandFactory.Create(commands[0]);

                result = ExecuteCommand(command, commands);

                if(result.executedSuccesfully is false)
                   result = ExecuteCommand(commandFactory.Create("show"));
            }
            Console.ReadKey();
        }

        private static (bool shouldQuit, bool executedSuccesfully) ExecuteCommand(ICommand command, params string[] commands)
        {
            (bool shouldQuit, bool executedSuccesfully) result;
            switch (command)
            {
                case IParameterizedCommand parameterizedCommand:
                    result = parameterizedCommand.Execute(commands.Skip(1).ToArray());
                    break;
                case INonParameterizedCommand nonParameterizedCommand:
                    result = nonParameterizedCommand.Execute();
                    break;
                default:
                    throw new NotSupportedException("Command not supported");
            }

            return result;
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
