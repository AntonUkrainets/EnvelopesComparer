using EnvelopesComparer.Business;
using EnvelopesComparer.Business.Interfaces;
using EnvelopesComparer.Model;
using Xunit;

namespace EnvelopesComparerTests
{
    public class RectangularEnvelopeAnalizerTests
    {
        #region Private Members

        private readonly IEnvelopeAnalizer analizer;

        #endregion

        public RectangularEnvelopeAnalizerTests()
        {
            analizer = new RectangularEnvelopeAnalizer();
        }

        [Fact]
        public void RectangularEnvelopeAnalizer_CanAnalize_Test()
        {
            // Arrange
            var rectangularEnvelope = new RectangularEnvelope(width: 0, height: 0);

            // Act
            var actualValue = analizer.CanAnalize(rectangularEnvelope);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(2, 5, 1, 4)]
        [InlineData(5, 4, 6, 10)]
        public void RectangularEnvelopeAnalizer_Analize_Positive_Test(
            double widthA,
            double heightA,
            double widthB,
            double heightB)
        {
            // Arrange
            var envelopeA = new RectangularEnvelope(widthA, heightA);
            var envelopeB = new RectangularEnvelope(widthB, heightB);

            // Act
            var actualValue = analizer.Analize(envelopeA, envelopeB);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 2, 0)]
        [InlineData(5, 5, 5, 5)]
        [InlineData(15, 11, 3, 16)]
        public void RectangularEnvelopeAnalizer_Analize_Negative_Test(
            double widthA,
            double heightA,
            double widthB,
            double heightB)
        {
            // Arrange
            var envelopeA = new RectangularEnvelope(widthA, heightA);
            var envelopeB = new RectangularEnvelope(widthB, heightB);

            // Act
            var actualValue = analizer.Analize(envelopeA, envelopeB);

            // Assert
            Assert.False(actualValue);
        }
    }
}