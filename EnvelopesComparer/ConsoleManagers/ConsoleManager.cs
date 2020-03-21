using System;
using EnvelopesComparer.ConsoleManagers.Interfaces;

namespace EnvelopesComparer.ConsoleManagers
{
    public class ConsoleManager : IConsoleManager
    {
        public string Read()
        {
            var inputString = Console.ReadLine();

            return inputString;
        }

        public void Write(object text)
        {
            Console.WriteLine($"{text}");
        }
    }
}