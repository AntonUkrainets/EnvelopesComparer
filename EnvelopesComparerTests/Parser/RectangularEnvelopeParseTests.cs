using System;
using System.Collections.Generic;
using System.Linq;
using EnvelopesComparer.Core;
using EnvelopesComparer.Model;
using EnvelopesComparer.Parser;
using Xunit;

namespace EnvelopesComparerTests.Parser
{
    public class RectangularEnvelopeParseTests
    {
        #region Private Members

        private readonly RectangularEnvelopeParser rectangularEnvelopeParser;

        #endregion

        public RectangularEnvelopeParseTests()
        {
            rectangularEnvelopeParser = new RectangularEnvelopeParser();
        }

        [Theory]
        [InlineData("0", "0", "0", "0")]
        [InlineData("-1", "-2", "-3", "-4")]
        [InlineData("1", "2", "3", "4")]
        public void ParseArgs_Positive_Test(params string[] args)
        {
            // Act
            var actualValue = rectangularEnvelopeParser.CanParse(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("1", "2", "3")]
        [InlineData("1", "2", "3", "4", "5")]
        public void ParseArgs_Negative_Test(params string[] args)
        {
            // Act
            var actualValue = rectangularEnvelopeParser.CanParse(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, "0", "0", "0", "0")]
        [InlineData(5, 10, 4, 9, "5", "10", "4", "9")]
        public void ParseArgsToEnvelopes_Positive_Test(
            double widthA,
            double heightA,
            double widthB,
            double heightB,
            params string[] args
        )
        {
            // Arrange
            var expectedEnvelopes = new List<RectangularEnvelope>
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

            var environment = new AppEnvironment();

            // Act
            var actualEnvelopes = environment.Parse(args);

            // Assert
            Assert.Equal(
                expectedEnvelopes,
                actualEnvelopes.Cast<RectangularEnvelope>(),
                new RectangularEnvelopeEqualityComparer()
            );
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("5", "10", "4")]
        [InlineData("5", "10", "4", "6", "9")]
        public void ParseArgsToEnvelopes_Negative_Test(params string[] args)
        {
            var environment = new AppEnvironment();

            // Assert
            Assert.Throws<FormatException>(() => environment.Parse(args));
        }
    }
}