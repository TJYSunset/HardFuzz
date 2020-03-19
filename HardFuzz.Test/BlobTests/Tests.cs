using HardFuzz.HarfBuzz.Blob;
using NUnit.Framework;

namespace HardFuzz.Test.BlobTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var       data = new byte[] {0x01, 0x02, 0x05, 0x04, 0x06};
            using var blob = new Blob(data);
            Assert.That(blob.Length, Is.EqualTo(data.Length));
            Assert.That(blob.GetData(), Is.EquivalentTo(data));
        }
    }
}
