using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Test
{
    public class TransformationTests
    {
        [Test]

        public void TranslationTest_trueReturned()
        {
            // arrange
            Triangle triangle = new Triangle(new Point(1,0,0), new Point(0, 1, 0), new Point(0, 0, 1));
            var transMatrix = Transformation.CreateTransformationMatrix(0, 0, 2,
                                                                        1, 1, 1,
                                                                        0, 0, 0);
            Triangle expected = new Triangle(new Point(1, 0, 2), new Point(0, 1, 2), new Point(0, 0, 3));

            // act
            triangle = triangle.Transform(transMatrix);

            // assert
            Assert.That(triangle.A.X, Is.EqualTo(expected.A.X));
            Assert.That(triangle.A.Y, Is.EqualTo(expected.A.Y));
            Assert.That(triangle.A.Z, Is.EqualTo(expected.A.Z));

            Assert.That(triangle.B.X, Is.EqualTo(expected.B.X));
            Assert.That(triangle.B.Y, Is.EqualTo(expected.B.Y));
            Assert.That(triangle.B.Z, Is.EqualTo(expected.B.Z));

            Assert.That(triangle.C.X, Is.EqualTo(expected.C.X));
            Assert.That(triangle.C.Y, Is.EqualTo(expected.C.Y));
            Assert.That(triangle.C.Z, Is.EqualTo(expected.C.Z));
        }

        [Test]
        public void ScalingTest_trueReturned()
        {
            // arrange
            Triangle triangle = new Triangle(new Point(1, 0, 0), new Point(0, 1, 0), new Point(0, 0, 1));
            var transMatrix = Transformation.CreateTransformationMatrix(0, 0, 0,
                                                                        2, 2, 2,
                                                                        0, 0, 0);
            Triangle expected = new Triangle(new Point(2, 0, 0), new Point(0, 2, 0), new Point(0, 0, 2));

            // act
            triangle = triangle.Transform(transMatrix);

            // assert
            Assert.That(triangle.A.X, Is.EqualTo(expected.A.X));
            Assert.That(triangle.A.Y, Is.EqualTo(expected.A.Y));
            Assert.That(triangle.A.Z, Is.EqualTo(expected.A.Z));

            Assert.That(triangle.B.X, Is.EqualTo(expected.B.X));
            Assert.That(triangle.B.Y, Is.EqualTo(expected.B.Y));
            Assert.That(triangle.B.Z, Is.EqualTo(expected.B.Z));

            Assert.That(triangle.C.X, Is.EqualTo(expected.C.X));
            Assert.That(triangle.C.Y, Is.EqualTo(expected.C.Y));
            Assert.That(triangle.C.Z, Is.EqualTo(expected.C.Z));
        }

        [Test]
        public void RotatingTest_trueReturned()
        {
            // arrange
            Triangle triangle = new Triangle(new Point(1, 0, 0), new Point(0, 1, 0), new Point(0, 0, 1));
            var transMatrix = Transformation.CreateTransformationMatrix(0, 0, 0,
                                                                        1, 1, 1,
                                                                        180, 0, 0);

            Triangle expected = new Triangle(new Point(1, 0, 0), new Point(0, -1, -1.2246467991473532E-16), new Point(0, 1.2246467991473532E-16, -1));

            // act
            triangle = triangle.Transform(transMatrix);

            // assert
            Assert.That(triangle.A.X, Is.EqualTo(expected.A.X));
            Assert.That(triangle.A.Y, Is.EqualTo(expected.A.Y));
            Assert.That(triangle.A.Z, Is.EqualTo(expected.A.Z));

            Assert.That(triangle.B.X, Is.EqualTo(expected.B.X));
            Assert.That(triangle.B.Y, Is.EqualTo(expected.B.Y));
            Assert.That(triangle.B.Z, Is.EqualTo(expected.B.Z));

            Assert.That(triangle.C.X, Is.EqualTo(expected.C.X));
            Assert.That(triangle.C.Y, Is.EqualTo(expected.C.Y));
            Assert.That(triangle.C.Z, Is.EqualTo(expected.C.Z));
        }
    }
}
