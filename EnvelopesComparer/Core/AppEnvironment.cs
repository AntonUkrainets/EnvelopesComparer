using System;
using EnvelopesComparer.Business;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.ConsoleManagers.Interfaces;
using EnvelopesComparer.Model;
using EnvelopesComparer.Parser;

namespace EnvelopesComparer.Core
{
    public class AppEnvironment
    {
        #region Private Members

        private readonly RectangularEnvelopeParser rectangularEnvelopeParser;

        #endregion

        public AppEnvironment()
        {
            rectangularEnvelopeParser = new RectangularEnvelopeParser();
        }

        public IEnvelope[] Parse(string[] args)
        {
            if (!rectangularEnvelopeParser.CanParse(args))
                throw new FormatException("Input data must be in format <WidthA> <HeightA> <WidthB> <HeightB>");

            var envelopes = rectangularEnvelopeParser.Parse(args);

            return envelopes;
        }

        public IEnvelope[] RequestExtraEnvelopes(IConsoleManager consoleManager)
        {
            if (!CompareNewEnvelopesRequired(consoleManager))
                return null;

            var inputString = consoleManager.Read();
            var sizes = inputString.Split(' ');

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

        private bool CompareNewEnvelopesRequired(IConsoleManager consoleManager)
        {
            consoleManager.Write("Compare new envelopes?");

            var response = consoleManager.Read();

            return CanCompareNewEnvelopes(response);
        }

        private bool CanCompareNewEnvelopes(string response)
        {
            return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}