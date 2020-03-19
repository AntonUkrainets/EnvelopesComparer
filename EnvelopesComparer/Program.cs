using System;
using System.Linq;
using EnvelopesComparer.Core;
using Liba.Logger.Implements;

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

            AppEnvironment environment = new AppEnvironment(logger);

            try
            {
                var envelopes = environment.Parse(args);

                do
                {
                    var analysis = environment.CheckEnvelopes(envelopes);

                    Console.WriteLine(analysis);

                    envelopes = environment.RequestExtraEnvelopes();
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