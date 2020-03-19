using System;
using System.Collections.Generic;
using System.Linq;
using EnvelopesComparer.Core;
using EnvelopesComparer.Model;
using Xunit;

namespace EnvelopesComparerTests.Parser
{
    public class RectangularEnvelopeTests
    {
        [Fact]
        public void ParseArgsToEnvelopes_Positive()
        {
            // Arrange
            var args = new string[] { "5", "10", "4", "9" };

            var expectedEnvelopes = new List<RectangularEnvelope>
            {
                new RectangularEnvelope(5, 10),
                new RectangularEnvelope(4, 9)
            };

            var environment = new AppEnvironment(null);

            // Act
            var actualEnvelopes = environment.Parse(args);

            // Assert
            Assert.Equal(
                expectedEnvelopes,
                actualEnvelopes.Cast<RectangularEnvelope>(), 
                new RectangularEnvelopeEqualityComparer()
            );
        }

        [Fact]
        public void ParseArgsToEnvelopes_Negative()
        {
            // Arrange
            var args = new string[] { "5", "10", "4"};

            var environment = new AppEnvironment(null);

            // Assert
            Assert.Throws<FormatException>(() => environment.Parse(args));
        }
    }
}