using EnvelopesComparer.Business.Model;
using EnvelopesComparer.Extensions;
using Xunit;

namespace EnvelopesComparerTests.Extensions
{
    public class RectangularEnvelopeExtensionsTests
    {
        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(1, 4, 2, 5)]
        [InlineData(5, 4, 6, 10)]
        public void IsLessThan_AToB_Positive(
            double widthA,
            double heightA,
            double widthB,
            double heightB)
        {
            // Arrange
            var envelopeA = new RectangularEnvelope(widthA, heightA);
            var envelopeB = new RectangularEnvelope(widthB, heightB);

            // Act
            var actualValue = envelopeA.IsLessThan(envelopeB);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData(3, 4, 1, 2)]
        [InlineData(2, 5, 1, 4)]
        [InlineData(6, 10, 5, 4)]
        public void IsLessThan_AToB_Negative(
            double widthA,
            double heightA,
            double widthB,
            double heightB)
        {
            // Arrange
            var envelopeA = new RectangularEnvelope(widthA, heightA);
            var envelopeB = new RectangularEnvelope(widthB, heightB);

            // Act
            var actualValue = envelopeA.IsLessThan(envelopeB);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData(3, 4, 1, 2)]
        [InlineData(2, 5, 1, 4)]
        [InlineData(6, 10, 5, 4)]
        public void IsLessThan_BToA_Positive(
            double widthA,
            double heightA,
            double widthB,
            double heightB)
        {
            // Arrange
            var envelopeA = new RectangularEnvelope(widthA, heightA);
            var envelopeB = new RectangularEnvelope(widthB, heightB);

            // Act
            var actualValue = envelopeB.IsLessThan(envelopeA);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(1, 4, 2, 5)]
        [InlineData(5, 4, 6, 10)]
        public void IsLessThan_BToA_Negative(
            double widthA,
            double heightA,
            double widthB,
            double heightB)
        {
            // Arrange
            var envelopeA = new RectangularEnvelope(widthA, heightA);
            var envelopeB = new RectangularEnvelope(widthB, heightB);

            // Act
            var actualValue = envelopeB.IsLessThan(envelopeA);

            // Assert
            Assert.False(actualValue);
        }
    }
}