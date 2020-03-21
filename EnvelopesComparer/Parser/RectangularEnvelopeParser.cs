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

        public IEnvelope[] Parse(string[] args)
        {
            TryConvertToDouble(args[0], out double widthA);
            CheckPositiveNumbers(widthA);

            TryConvertToDouble(args[1], out double heightA);
            CheckPositiveNumbers(heightA);

            TryConvertToDouble(args[2], out double widthB);
            CheckPositiveNumbers(widthB);

            TryConvertToDouble(args[3], out double heightB);
            CheckPositiveNumbers(heightB);

            return new IEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };
        }

        private void TryConvertToDouble(string inputString, out double value)
        {
            if (!double.TryParse(inputString, out value))
                throw new ArgumentException($"Number '{inputString}' has incorrect format");
        }

        private void CheckPositiveNumbers(double value)
        {
            if (value < 0)
                throw new ArgumentException($"Number '{value}' must be greather 0");
        }
    }
}