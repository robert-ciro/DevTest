namespace Application.Commands
{
    using Application.Dtos;

    public class HelpCommand : INonParameterizedCommand
    {
        public CommandResponse Execute()
        {
            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = true,
                Message = @"
commands:
- create square {double} (create a new square)
- create circle {double} (create a new circle)
- create rectangle {height} {width} (create a new rectangle)
- create triangle {height} {width} (create a new triangle)
- create triangle {height} {width} (create a new trapezoid)
- print (print the calculated surface areas)
- calculate (calculate the surface areas of the created shapes)
- reset (reset)
- exit (exit the loop)
"
            };
        }
    }
}