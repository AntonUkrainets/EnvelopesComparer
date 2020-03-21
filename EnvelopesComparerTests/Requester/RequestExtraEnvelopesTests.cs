using System;
using System.Linq;
using EnvelopesComparer.ConsoleManagers.Interfaces;
using EnvelopesComparer.Core;
using EnvelopesComparer.Model;
using Moq;
using Xunit;

namespace EnvelopesComparerTests.Requester
{
    public class RequestExtraEnvelopesTests
    {
        #region Private Members

        private readonly AppEnvironment environment;

        #endregion

        public RequestExtraEnvelopesTests()
        {
            environment = new AppEnvironment();
        }

        [Theory]
        [InlineData("0 0 0 0", 0, 0, 0, 0)]
        [InlineData("5 10 6 12", 5, 10, 6, 12)]
        public void RequestExtraEnvelopes_Positive_Test(
            string inputString,
            double widthA,
            double heightA,
            double widthB,
            double heightB
        )
        {
            // Arrange
            var expectedEnvelopes = new RectangularEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

            var index = 0;
            var mockConsoleManager = new Mock<IConsoleManager>();
            mockConsoleManager
                .Setup(c => c.Read())
                .Returns(() =>
                {
                    if (index == 0)
                    {
                        index++;

                        return "yEs";
                    }

                    return inputString;
                });

            // Act
            var actualEnvelopes = environment
                    .RequestExtraEnvelopes(mockConsoleManager.Object)
                    .Cast<RectangularEnvelope>();

            var equalityComparer = new RectangularEnvelopeEqualityComparer();

            Assert.Equal(
                expectedEnvelopes,
                actualEnvelopes,
                equalityComparer);
        }

        [Theory]
        [InlineData("-1 0 0 0")]
        [InlineData("0 0 0 -8")]
        [InlineData("-1 -2 -6 -12")]
        [InlineData("5 10 6 str")]
        public void RequestExtraEnvelopes_Negative_Test(string inputString)
        {
            // Arrange
            var index = 0;
            var mockConsoleManager = new Mock<IConsoleManager>();
            mockConsoleManager
                .Setup(c => c.Read())
                .Returns(() =>
                {
                    if (index == 0)
                    {
                        index++;
                        return "yes";
                    }

                    return inputString;
                });

            // Assert
            Assert.Throws<ArgumentException>(
                () => 
                    environment.RequestExtraEnvelopes(mockConsoleManager.Object));
        }
    }
}