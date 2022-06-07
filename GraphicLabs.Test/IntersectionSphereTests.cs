namespace GraphicLabs.Test
{
    public class IntersectionSphereTests
    {
        [SetUp]
        public void Setup()
        {
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);
        }

        [Test]
        public void IsIntersects_trueReturned23_13_23()
        {
            // arrange
            Point center = new Point(3,2,2);
            double radius = 1;
            Sphere sphere = new Sphere(center, radius);
            Ray ray = new Ray(new Point(1, 0, 1), new Point(1.5, 0.5, 1.5));
            Point expected = new Point(2.333333333333333, 1.3333333333333333, 2.333333333333333);

            // act
            var truth = sphere.IsIntersects(ray);
            var point = sphere.IntersectionPoint(ray); 

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
            Point center = new Point(3, 2, 2);
            double radius = 1;
            Sphere sphere = new Sphere(center, radius);
            Ray ray = new Ray(new Point(1, 0, 1), new Point(1.5, 0.3, 1.5));

            // act
            var truth = sphere.IsIntersects(ray);

            // assert
            Assert.IsFalse(truth);
        }
    }
}