using EnvelopesComparer.Core;
using EnvelopesComparer.Model;
using Xunit;

namespace EnvelopesComparerTests.Analysis
{
    public class AnalizeEnvelopesTests
    {
        [Theory]
        [InlineData(1, 1, 0, 0)]
        [InlineData(5, 6, 8, 10)]
        [InlineData(5, 3, 2, 4)]
        public void AnalizeEnvelopes_Positive_Test(
            double widthA,
            double heightA,
            double widthB,
            double heightB
        )
        {
            // Arrange
            var expectedValue = true;

            var envelopes = new RectangularEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

            var environment = new AppEnvironment();

            // Act
            var actualValue = environment.CheckEnvelopes(envelopes);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(5, 10, 4, 10)]
        [InlineData(5, 5, 5, 5)]
        [InlineData(10, 10, 10, 10)]
        [InlineData(3, 12, 5, 6)]
        public void AnalizeEnvelopes_Negative_Test(
            double widthA, 
            double heightA,
            double widthB,
            double heightB
        )
        {
            // Arrange
            var expectedValue = false;

            var envelopes = new RectangularEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

            var environment = new AppEnvironment();

            // Act
            var actualValue = environment.CheckEnvelopes(envelopes);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}