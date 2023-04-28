namespace Refactoring
{
    using System;
    using Application;
    using Application.Commands;
    using Application.Dtos;

    public class GeometricShapeService
    {
        private readonly ILogger logger;
        private readonly IUserInterface userInterface;
        private readonly SurfaceAreaCommandFactory commandFactory;
        
        public GeometricShapeService(ILogger logger, IUserInterface userInterface, SurfaceAreaCommandFactory commandFactory)
        {
            this.logger = logger;
            this.userInterface = userInterface;
            this.commandFactory = commandFactory;
        }
        
        public void Start()
        {
            try
            {
                Greet();
                Run();
            }
            catch
            {
                logger.Log("Something went wrong :(");
                Run();
            }
        }
        
        private void Run()
        {
            var result = ExecuteCommand(commandFactory.Create("show").command);
            
            logger.Log(result.Message);

            while (result.ShouldQuit is false)
            {
                var input = userInterface.ReadMessage();
                var (command, parameters) = commandFactory.Create(input);

                result = ExecuteCommand(command, parameters);

                if (result.ExecutedSuccessfully is false)
                    result = ExecuteCommand(commandFactory.Create("show").command);

                logger.Log(result.Message);
            }
        }

        private void Greet()
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

        private static CommandResponse ExecuteCommand(ICommand command, string parameters = null)
        {
            switch (command)
            {
                case IParameterizedCommand parameterizedCommand:
                    return parameterizedCommand.Execute(parameters);
                case INonParameterizedCommand nonParameterizedCommand:
                    return nonParameterizedCommand.Execute();
                default:
                    throw new NotSupportedException("Command not supported");
            }
        }
    }
}