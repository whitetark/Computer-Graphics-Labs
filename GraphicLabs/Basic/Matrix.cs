using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Basic
{
    public class Matrix
    {
        public double[,] body = new double[4, 4];

        public Matrix()
        {
            body = new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
        }
        public Matrix(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
        {
            body = new double[4, 4]
            {
                { m11, m12, m13, 0 },
                { m21, m22, m23, 0 },
                { m31, m32, m33, 0 },
                { 0, 0, 0, 1 }
            };
        }
        public Matrix(Vector v)
        {
            body = new double[4, 4]
            {
                { v.X, 0, 0, 0 },
                { v.Y, 0, 0, 0 },
                { v.Z, 0, 0, 0 },
                { 0, 0, 0, 1 }
            };
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix matrix = new Matrix();
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    matrix.body[r, c] = m1.body[r, c] + m2.body[r, c];
                }
            }
            return matrix;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix matrix = new Matrix();
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    matrix.body[r, c] = m1.body[r, c] - m2.body[r, c];
                }
            }
            return matrix;
        }
        public static Matrix operator *(Matrix m1, double d)
        {
            Matrix matrix = new Matrix();
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    matrix.body[r, c] = m1.body[r, c] * d;
                }
            }
            return matrix;
        }
        public static Matrix operator *(double d, Matrix m1)
        {
            Matrix matrix = new Matrix();
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    matrix.body[r, c] = d * m1.body[r, c];
                }
            }
            return matrix;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix matrix = new Matrix();
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    double sum = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += m1.body[r, i] * m2.body[i, c];
                    }
                    matrix.body[r, c] = sum;
                }
            }
            return matrix;
        }
        public static Vector operator *(Matrix matrix, Vector vector)
        {
            Vector result = new Vector();

            result.X = matrix.body[0, 0] * vector.X + matrix.body[0, 1] * vector.Y + matrix.body[0, 2] * vector.Z + matrix.body[0, 3];
            result.Y = matrix.body[1, 0] * vector.X + matrix.body[1, 1] * vector.Y + matrix.body[1, 2] * vector.Z + matrix.body[1, 3];
            result.Z = matrix.body[2, 0] * vector.X + matrix.body[2, 1] * vector.Y + matrix.body[2, 2] * vector.Z + matrix.body[2, 3];

            return result;
        }
        public Matrix RotateAroundX(double radians)
        {
            this.body = new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, Math.Cos(radians), Math.Sin(radians), 0 },
                { 0, -Math.Sin(radians), Math.Cos(radians), 0 },
                { 0, 0, 0, 1 }
            };
            return this;
        }
        public Matrix RotateAroundY(double radians)
        {
            this.body = new double[4, 4]
            {
                { Math.Cos(radians), 0, -Math.Sin(radians), 0 },
                { 0, 1, 0, 0 },
                { Math.Sin(radians), 0, Math.Cos(radians), 0 },
                { 0, 0, 0, 1 }
            };
            return this;
        }
        public Matrix RotateAroundZ(double radians)
        {
            this.body = new double[4, 4]
            {
                { Math.Cos(radians), Math.Sin(radians), 0, 0 },
                { -Math.Sin(radians), Math.Cos(radians), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            return this;
        }
    }
}
