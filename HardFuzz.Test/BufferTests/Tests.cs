using HardFuzz.HarfBuzz.Buffer;
using NUnit.Framework;

namespace HardFuzz.Test.BufferTests
{
    [TestFixture]
    public partial class Tests
    {
        [SetUp]
        public void SetUp()
        {
            Buffer = new Buffer
            {
                Direction = HarfBuzz.Direction.Ltr,
                Language = "en",
                Script = HarfBuzz.Script.Latin
            };
        }

        [TearDown]
        public void TearDown()
        {
            Buffer.Dispose();
        }

        public Buffer Buffer;
    }
}