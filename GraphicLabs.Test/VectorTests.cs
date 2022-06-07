namespace GraphicLabs.Test
{
    public class VectorTests
    {
        [SetUp]
        public void Setup()
        {
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);
        }

        [Test]
        public void Dot1_1_1_And1_2_3_Returned6()
        {
            // arrange
            double expected = 6;

            var vector1 = new Vector(1, 1, 1);
            var vector2 = new Vector(1, 2, 3);

            // act
            var result = Vector.Dot(vector1, vector2);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Cross1_2_3_And4_5_6_Returnedm3_6_m3()
        {
            // arrange
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(4, 5, 6);
            var expected = new Vector(-3, 6, -3);

            // act
            var result = Vector.Cross(vector1, vector2);

            // assert
            Assert.That(result.X, Is.EqualTo(expected.X));
            Assert.That(result.Y, Is.EqualTo(expected.Y));
            Assert.That(result.Z, Is.EqualTo(expected.Z));
        }

        [Test]
        public void Normalize_LengthReturned1()
        {
            // arrange
            double expected = 1;
            Vector vector = new Vector(1, 2, 3);

            // act
            var result = vector.Normalize().Length();

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
