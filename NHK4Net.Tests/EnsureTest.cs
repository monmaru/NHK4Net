using System;
using NHK4Net.Internal;
using Xunit;
// ReSharper disable ExpressionIsAlwaysNull

namespace NHK4Net.Tests
{
    public class EnsureTest
    {
        [Fact]
        public void ArgumentNotNullTest()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNull(obj, nameof(obj)));
        }

        [Fact]
        public void ArgumentNotNullOrEmptyStringTest()
        {
            string nullString = null;
            var emptyString = string.Empty;
            Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNullOrEmptyString(nullString, nameof(nullString)));
            Assert.Throws<ArgumentException>(() => Ensure.ArgumentNotNullOrEmptyString(emptyString, nameof(emptyString)));
        }
    }
}
