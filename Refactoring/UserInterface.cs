namespace Refactoring
{
    using System;

    public interface IUserInterface
    {
        string ReadMessage(string message);
    }
    
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadMessage(string message)
        {
            return Console.ReadLine();
        }
    }
}