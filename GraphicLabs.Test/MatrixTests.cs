using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Test
{
    public class MatrixTests
    {
        [Test]
        public void MatrixMultiplyMatrix_returned()
        {
            // arrange
            Matrix matrix1 = new Matrix(1, 1, 1, 1, 1, 1, 1, 1, 1);
            Matrix matrix2 = new Matrix(2, 2, 2, 2, 2, 2, 2, 2, 2);
            Matrix expected = new Matrix(6, 6, 6, 6, 6, 6, 6, 6, 6);

            // act
            var result = matrix1 * matrix2;

            // assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.That(result.body[i, j], Is.EqualTo(expected.body[i, j]));
                }
            }
        }

        [Test]
        public void MatrixMultiplyVector()
        {
            // arrange
            Matrix matrix = new Matrix(1, 1, 1, 1, 1, 1, 1, 1, 1);
            Vector vector = new Vector(2, 2, 2);
            Vector expected = new Vector(6, 6, 6);

            // act
            var result = matrix * vector;

            // assert
            Assert.That(result.X, Is.EqualTo(expected.X));
            Assert.That(result.Y, Is.EqualTo(expected.Y));
            Assert.That(result.Z, Is.EqualTo(expected.Z));
        }
    }
}
