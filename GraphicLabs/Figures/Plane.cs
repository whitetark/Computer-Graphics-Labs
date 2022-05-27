using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.Figures
{
    public class Plane
    {
        public Vector normal { get; set; }
        public Point center { get; set; }

        public Plane(Vector vector, Point center)
        {
            normal = vector.Normalize();
            this.center = center;
        }

        public Vector GetNormal(Point point)
        {
            return normal;
        }

        public bool IsIntersects(Point origin, Vector ray)
        {
            double result = ray * normal;
            if (result > 0)
            {
                Vector k = center - origin;
                double scale = -((k*normal)/(ray*normal));
                return scale >= 0;
            }

            return false;

            // if ray*normal = 0, direction&plane are parallel
            // if (p0-ray.Origin)*normal = 0, direction is the part of plane
            // if ray*normal != 0, it's intersects
        }

        public Point IntersectionPoint(Point origin, Vector ray)
        {
            Vector k = center - origin;
            double scale = -((k * normal) / (ray * normal));

            double X = origin.X + scale * ray.X;
            double Y = origin.Y + scale * ray.Y;
            double Z = origin.Z + scale * ray.Z;

            return new Point(X, Y, Z);

            // (p-p0)*normal = 0 ; plane formula
            // p = scale*ray+start ; direction formula

            // (scale*ray+start - p0)*normal = 0
            // scale*ray*normal + (start - p0)*normal = 0 ; start - p0 = k
            // scale*ray*normal + k*normal = 0
            // scale = -k*normal/ray*normal
        }
    }
}
