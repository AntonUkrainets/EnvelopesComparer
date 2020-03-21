using System;
using System.Reflection;
using EnvelopesComparer.Core;
using Xunit;

namespace EnvelopesComparerTests.Comparer
{
    public class CompareNewEnvelopesTests
    {
        [Theory]
        [InlineData("y")]
        [InlineData("Y")]
        [InlineData("yes")]
        [InlineData("YES")]
        [InlineData("yEs")]
        [InlineData("YeS")]
        public void CompareNewEnvelopes_Positive_Test(string response)
        {
            // Arrange
            var environmentType = typeof(AppEnvironment);
            var environment = Activator.CreateInstance(environmentType);

            var canCompareMethod = environmentType.GetMethod
            (
                "CanCompareNewEnvelopes",
                BindingFlags.NonPublic
              | BindingFlags.Instance
            );

            // Act
            var canCompare = (bool)canCompareMethod.Invoke
            (
                environment, 
                new object[] { response }
            );

            // Assert
            Assert.True(canCompare);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("123")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("no")]
        [InlineData("str")]
        public void CompareNewEnvelopes_Negative_Test(string response)
        {
            // Arrange
            var environmentType = typeof(AppEnvironment);
            var environment = Activator.CreateInstance(environmentType);

            var canCompareMethod = environmentType.GetMethod
            (
                "CanCompareNewEnvelopes",
                BindingFlags.NonPublic
              | BindingFlags.Instance
            );

            // Act
            var canCompare = (bool)canCompareMethod.Invoke
            (
                environment,
                new object[] { response }
            );

            // Assert
            Assert.False(canCompare);
        }
    }
}