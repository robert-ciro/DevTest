namespace Client.Console
{
    using System;
    using Application;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadMessage()
        {
            return Console.ReadLine();
        }
    }
}