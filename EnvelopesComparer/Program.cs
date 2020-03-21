using System;
using System.Linq;
using EnvelopesComparer.ConsoleManagers;
using EnvelopesComparer.ConsoleManagers.Interfaces;
using EnvelopesComparer.Core;
using Liba.Logger;

namespace EnvelopesComparer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logPath = "application.log";

            var logger = new AggregatedLogger(
                new FileLogger(logPath),
                new ConsoleLogger()
            );

            IConsoleManager consoleManager = new ConsoleManager();
            var environment = new AppEnvironment(consoleManager);

            try
            {
                var envelopes = environment.Parse(args);

                var analysis = environment.CheckEnvelopes(envelopes);

                do
                {
                    consoleManager.WriteLine($"{analysis}");

                    envelopes = environment.RequestExtraEnvelopes();

                    if (envelopes == null)
                        break;

                    analysis = environment.CheckEnvelopes(envelopes);
                }
                while (envelopes.Any());
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
        }
    }
}