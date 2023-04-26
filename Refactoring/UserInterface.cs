namespace Refactoring
{
    using System;

    public interface IUserInterface
    {
        string ReadMessage();
    }
    
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadMessage()
        {
            return Console.ReadLine();
        }
    }
}