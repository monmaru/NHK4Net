using System;
using NHK4Net.Internal;
using Xunit;

namespace NHK4Net.Tests
{
    public class EnsureTest
    {
        [Fact]
        public void ArgumentNotNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNull(null));
        }

        [Fact]
        public void ArgumentNotNullOrEmptyStringTest()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNullOrEmptyString(null));
            Assert.Throws<ArgumentException>(() => Ensure.ArgumentNotNullOrEmptyString(string.Empty));
        }
    }
}
