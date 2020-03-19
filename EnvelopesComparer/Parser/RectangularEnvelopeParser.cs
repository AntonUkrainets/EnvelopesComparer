using System;
using System.Collections.Generic;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.Model;
using EnvelopesComparer.Parser.Interfaces;

namespace EnvelopesComparer.Parser
{
    public class RectangularEnvelopeParser : IParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 4;
        }

        public IEnumerable<IEnvelope> Parse(string[] args)
        {
            TryConvertToDouble(args[0], out double widthA);
            TryConvertToDouble(args[1], out double heightA);
            TryConvertToDouble(args[2], out double widthB);
            TryConvertToDouble(args[3], out double heightB);

            return new IEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };
        }

        private void TryConvertToDouble(string str, out double value)
        {
            if (!double.TryParse(str, out value))
                throw new ArgumentException($"Can't convert '{value}' to double.");
        }
    }
}