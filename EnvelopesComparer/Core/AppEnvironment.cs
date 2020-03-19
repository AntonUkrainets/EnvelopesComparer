using System;
using System.Collections.Generic;
using System.Linq;
using EnvelopesComparer.Business;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.Model;
using EnvelopesComparer.Parser;
using Liba.Logger.Implements;

namespace EnvelopesComparer.Core
{
    public class AppEnvironment
    {
        #region Private Members

        private readonly AggregatedLogger logger;
        private readonly RectangularEnvelopeParser rectangularEnvelopeParser;

        #endregion

        public AppEnvironment(AggregatedLogger logger)
        {
            this.logger = logger;

            rectangularEnvelopeParser = new RectangularEnvelopeParser();
        }

        public IEnumerable<IEnvelope> Parse(string[] args)
        {
            if (!rectangularEnvelopeParser.CanParse(args))
            {
                throw new FormatException("Input data must be in format <WidthA> <HeightA> <WidthB> <HeightB>");
            }

            var envelopes = rectangularEnvelopeParser.Parse(args);

            return envelopes;
        }

        public IEnumerable<IEnvelope> RequestExtraEnvelopes()
        {
            if (!CompareNewEnvelopesRequired())
                return new IEnvelope[0];

            var str = Console.ReadLine();
            var sizes = str.Split(' ');

            var envelopes = Parse(sizes);

            return envelopes;
        }

        public bool CheckEnvelopes(IEnumerable<IEnvelope> envelopes)
        {
            var analizer = new RectangularEnvelopeAnalizer();

            var envelopeA = (RectangularEnvelope)envelopes.ElementAt(0);
            var envelopeB = (RectangularEnvelope)envelopes.ElementAt(1);

            if (analizer.CanAnalize(envelopeA)
             && analizer.CanAnalize(envelopeB)
            )
            {
                return analizer.Analize(envelopeA, envelopeB);
            }

            return false;
        }

        private bool CompareNewEnvelopesRequired()
        {
            Console.WriteLine("Compare new envelopes?");

            var response = Console.ReadLine();

            return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}