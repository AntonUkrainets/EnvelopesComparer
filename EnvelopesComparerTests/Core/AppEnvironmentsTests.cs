using System;
using System.Collections.Generic;
using System.Linq;
using EnvelopesComparer.Business.Model;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.ConsoleManagers.Interfaces;
using EnvelopesComparer.Core;
using EnvelopesComparerTests.Comparer;
using Moq;
using Xunit;

namespace EnvelopesComparerTests.Core
{
    public class AppEnvironmentsTests
    {
        #region Private Members

        private readonly AppEnvironment environment;
        private readonly Mock<IConsoleManager> mockConsoleManager;

        #endregion

        public AppEnvironmentsTests()
        {
            mockConsoleManager = new Mock<IConsoleManager>();
            environment = new AppEnvironment(mockConsoleManager.Object);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, "1", "2", "3", "4")]
        [InlineData(5, 6, 7, 8, "5", "6", "7", "8")]
        public void Parse_Positive(
            double widthA,
            double heightA,
            double widthB,
            double heightB,
            params string[] args
        )
        {
            // Arrange
            var expectedEnvelopes = new RectangularEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

            // Act
            var actualEnvelopes = environment
                .Parse(args)
                .Cast< RectangularEnvelope>();

            var comparer = new RectangularEnvelopeEqualityComparer();

            // Assert
            Assert.Equal(expectedEnvelopes, actualEnvelopes, comparer);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("a", "b")]
        [InlineData("1", "2", "3")]
        [InlineData("1", "2", "3", "4", "5")]
        public void Parse_Negative(params string[] args)
        {
            // Assert
            Assert.Throws<FormatException>(() => environment.Parse(args));
        }

        [Theory]
        [InlineData("0 0 0 0", 0, 0, 0, 0)]
        [InlineData("5 10 6 12", 5, 10, 6, 12)]
        public void RequestExtraEnvelopes_Positive(
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

            var consoleUserResponses = new Queue<string>(
                new[]
                {
                    "yEs",
                    inputString
                }
            );
            
            mockConsoleManager
                .Setup(c => c.ReadLine())
                .Returns(() => consoleUserResponses.Dequeue());

            // Act
            var actualEnvelopes = environment
                .RequestExtraEnvelopes()
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
        public void RequestExtraEnvelopes_Negative(string inputString)
        {
            // Arrange
            var consoleUserResponses = new Queue<string>(
               new[]
               {
                    "yEs",
                    inputString,
                    "yes"
               }
           );

            mockConsoleManager
                .Setup(c => c.ReadLine())
                .Returns(() => consoleUserResponses.Dequeue());

            // Assert
            Assert.Throws<ArgumentException>(
                () =>
                    environment.RequestExtraEnvelopes());
        }

        [Theory]
        [InlineData(1, 1, 0, 0)]
        [InlineData(5, 6, 8, 10)]
        [InlineData(5, 3, 2, 4)]
        public void CheckEnvelopes_Positive(
            double widthA,
            double heightA,
            double widthB,
            double heightB
        )
        {
            // Arrange
            var expectedValue = true;

            var envelopes = new IEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

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
        public void CheckEnvelopes_Negative(
            double widthA,
            double heightA,
            double widthB,
            double heightB
        )
        {
            // Arrange
            var expectedValue = false;

            var envelopes = new IEnvelope[]
            {
                new RectangularEnvelope(widthA, heightA),
                new RectangularEnvelope(widthB, heightB)
            };

            // Act
            var actualValue = environment.CheckEnvelopes(envelopes);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}