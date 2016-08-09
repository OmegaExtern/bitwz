using bitwz.Types;
#if USE_NUNIT
using NUnit.Framework;
#elif USE_XUNIT
using Xunit;
#else
#if !USE_MSUNIT
#define USE_MSUNIT
#endif
using Microsoft.VisualStudio.TestTools.UnitTesting; // Use MSUnit.
#endif

// ReSharper disable ClassCanBeSealed.Global

namespace bitwz.Tests
{
#if USE_MSUNIT
    [TestClass]
#elif USE_NUNIT
    [TestFixture]
#endif
    public class BitwzInt32Tests
    {
#if USE_MSUNIT
        [TestMethod]
#elif USE_NUNIT
        [Test]
#elif USE_XUNIT
        [Theory]
#endif
        public void Test_int32_Equality()
        {
            int32 a = 123456789, b = -6543210;
            int c = 123456789, d = -6543210;
#if USE_MSUNIT
#elif USE_NUNIT
            Assert.That(a, Is.EqualTo(a));
            Assert.That(a, Is.Not.EqualTo(b));
            Assert.That((int)a, Is.EqualTo(c));
            Assert.That((int)b, Is.EqualTo(d));
            Assert.That((int)a, Is.Not.EqualTo(d));
            Assert.That((int)b, Is.Not.EqualTo(c));
#elif USE_XUNIT
#endif
        }
    }
}