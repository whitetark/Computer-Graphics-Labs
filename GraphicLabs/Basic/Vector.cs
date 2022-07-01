﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Basic
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        
        public Vector(Point start, Point end)
        {
            X = end.X-start.X;
            Y = end.Y-start.Y;
            Z = end.Z-start.Z;
        }
        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static Vector Cross(Vector n1, Vector n2)
        {
            double X = n1.Y * n2.Z - n1.Z * n2.Y;
            double Y = n1.Z * n2.X - n1.X * n2.Z;
            double Z = n1.X * n2.Y - n1.Y * n2.X;
            return new Vector(X, Y, Z);
        }
        public static double Dot(Vector n1, Vector n2)
        {
            return n1.X * n2.X + n1.Y * n2.Y + n1.Z * n2.Z;
        }

        public Vector Normalize()
        {
            double Length = this.Length();
            if (Length > 0)
            {
                double X = this.X / Length;
                double Y = this.Y / Length;
                double Z = this.Z / Length;
                return new Vector(X, Y, Z);
            }
            return this;
        }

        public static Vector operator +(Vector n1, Vector n2)
        {
            return new Vector(n1.X + n2.X, n1.Y+n2.Y, n1.Z+n2.Z);
        }
        public static Vector operator -(Vector n1, Vector n2)
        {
            return new Vector(n1.X - n2.X, n1.Y - n2.Y, n1.Z - n2.Z);
        }
        public static Vector operator *(Vector n1, double number)
        {
            return new Vector(n1.X * number, n1.Y * number, n1.Z * number);
        }
        public static Vector operator * (Vector v1, Vector v2) {
            return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }
        
        public Vector Transform(Matrix matrix)
        {
            Vector vector = new Vector(this.X, this.Y, this.Z);
            Vector res = matrix * vector;

            var transVector = new Vector(res.X, res.Y, res.Z);

            return transVector;
        }
    }
}
