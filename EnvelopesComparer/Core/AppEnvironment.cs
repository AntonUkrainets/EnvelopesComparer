using System;
using EnvelopesComparer.Business;
using EnvelopesComparer.Business.Model;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.ConsoleManagers.Interfaces;
using EnvelopesComparer.Parser;

namespace EnvelopesComparer.Core
{
    public class AppEnvironment
    {
        #region Private Members

        private readonly IConsoleManager consoleManager;
        private readonly RectangularEnvelopeParser rectangularEnvelopeParser;

        #endregion

        public AppEnvironment(IConsoleManager consoleManager)
        {
            this.consoleManager = consoleManager;
            rectangularEnvelopeParser = new RectangularEnvelopeParser();
        }

        public IEnvelope[] Parse(string[] args)
        {
            if (!rectangularEnvelopeParser.CanParse(args))
                throw new FormatException("Input data must be in format <WidthA> <HeightA> <WidthB> <HeightB>");

            var envelopes = rectangularEnvelopeParser.Parse(args);

            return envelopes;
        }

        public IEnvelope[] RequestExtraEnvelopes()
        {
            if (!CompareNewEnvelopesRequired())
                return null;

            var inputString = consoleManager.ReadLine();
            var sizes = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var envelopes = Parse(sizes);

            return envelopes;
        }

        public bool CheckEnvelopes(IEnvelope[] envelopes)
        {
            var analizer = new RectangularEnvelopeAnalizer();

            var envelopeA = (RectangularEnvelope)envelopes[0];
            var envelopeB = (RectangularEnvelope)envelopes[1];

            if (analizer.CanAnalize(envelopeA)
             && analizer.CanAnalize(envelopeB))
            {
                return analizer.Analize(envelopeA, envelopeB);
            }

            return false;
        }

        private bool CompareNewEnvelopesRequired()
        {
            consoleManager.WriteLine("Compare new envelopes?");

            var response = consoleManager.ReadLine();

            return CompareNewEnvelopes(response);
        }

        private bool CompareNewEnvelopes(string response)
        {
            return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}