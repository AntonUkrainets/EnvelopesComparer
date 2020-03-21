using System;
using EnvelopesComparer.ConsoleManagers.Interfaces;

namespace EnvelopesComparer.ConsoleManagers
{
    public class ConsoleManager : IConsoleManager
    {
        public string ReadLine()
        {
            var inputString = Console.ReadLine();

            return inputString;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}