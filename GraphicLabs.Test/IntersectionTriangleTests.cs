namespace GraphicLabs.Test
{
    public class IntersectionTriangleTests
    {
        [SetUp]
        public void Setup()
        {
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);
        }

        [Test]
        public void IsIntersects_trueReturned()
        {
            // arrange
            Point A = new Point(1, 0, 0);
            Point B = new Point(0, 1, 0);
            Point C = new Point(0, 0, 1);
            Triangle triangle = new Triangle(A, B, C);
            Ray ray = new Ray(new Point(5, 0.5, 3), new Point(4, 0.5, 2.4));

            // act
            var truth = triangle.IsIntersects(ray);

            // assert
            Assert.IsTrue(truth);
        }

        [Test]
        public void IsIntersects_falseReturned()
        {
            // arrange
            Point A = new Point(1, 0, 0);
            Point B = new Point(0, 1, 0);
            Point C = new Point(0, 0, 1);
            Triangle triangle = new Triangle(A, B, C);
            Ray ray = new Ray(new Point(5, 0.5, 3), new Point(4, 0.5, 2.3));

            // act
            var truth = triangle.IsIntersects(ray);

            // assert
            Assert.IsFalse(truth);
        }
    }
}