using EnvelopesComparer.Business.Model;
using Xunit;

namespace EnvelopesComparerTests.Business.Model
{
    public class RectangularEnvelopeTests
    {
        [Theory]
        [InlineData(5, 10)]
        public void Ctor(double width, double height)
        {
            // Act
            var actualEnvelope = new RectangularEnvelope(width, height);

            // Assert
            Assert.Equal(width, actualEnvelope.Width);
            Assert.Equal(height, actualEnvelope.Height);
        }
    }
}