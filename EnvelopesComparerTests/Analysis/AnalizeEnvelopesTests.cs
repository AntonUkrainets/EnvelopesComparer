using System.Collections.Generic;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.Core;
using EnvelopesComparer.Model;
using Liba.Logger.Implements;
using Xunit;

namespace EnvelopesComparerTests.Analysis
{
    public class AnalizeEnvelopesTests
    {
        [Fact]
        public void CanAnalizeEnvelopes_51049Test()
        {
            // Arrange
            var expectedValue = true;

            var envelopes = new List<RectangularEnvelope>
            {
                new RectangularEnvelope(5, 10),
                new RectangularEnvelope(4, 9)
            };

            var environment = new AppEnvironment(new AggregatedLogger());

            // Act
            var actualValue = environment.CheckEnvelopes(envelopes);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CantAnalizeEnvelopes_510410Test()
        {
            // Arrange
            var expectedValue = false;

            var envelopes = new List<IEnvelope>
            {
                new RectangularEnvelope(5, 10),
                new RectangularEnvelope(4, 10)
            };

            var environment = new AppEnvironment(new AggregatedLogger());

            // Act
            var actualValue = environment.CheckEnvelopes(envelopes);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}