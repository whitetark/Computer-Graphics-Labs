namespace GraphicLabs.Test
{
    public class IntersectionPlaneTests
    {
        [SetUp]
        public void Setup()
        {
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);
        }

        [Test]
        public void IsIntersects_trueReturned1_3_25()
        {
            // arrange
            Vector normal = new Vector(new Point(2, 3, 3), new Point(2, 2, 3));
            Point center = new Point(2, 3, 3);
            Plane plane = new Plane(normal, center);
            Ray ray = new Ray(new Point(1, 0, 1), new Point(1, 2, 2));
            Point expected = new Point(1, 3, 2.5);

            // act
            var truth = plane.IsIntersects(ray);
            var point = plane.IntersectionPoint(ray);

            // assert
            Assert.IsTrue(truth);
            Assert.That(point.X, Is.EqualTo(expected.X));
            Assert.That(point.Y, Is.EqualTo(expected.Y));
            Assert.That(point.Z, Is.EqualTo(expected.Z));
        }

        [Test]
        public void IsIntersects_falseReturned()
        {
            // arrange
            Vector normal = new Vector(new Point(2, 3, 3), new Point(2, 2, 3));
            Point center = new Point(2, 3, 3);
            Plane plane = new Plane(normal, center);
            Ray ray = new Ray(new Point(1, 0, 1), new Point(1, 0, 2));

            // act
            var truth = plane.IsIntersects(ray);

            // assert
            Assert.IsFalse(truth);
        }
    }
}