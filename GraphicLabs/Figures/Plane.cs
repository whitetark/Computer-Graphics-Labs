using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Materials;

namespace GraphicLabs.Figures
{
    public class Plane : Figure
    {
        public Vector Normal { get; set; }
        public Point Center { get; set; }
        
        public IMaterial material { get; set; }

        public Plane(Vector normal, Point center)
        {
            Normal = normal.Normalize();
            this.Center = center;
        }

        public override Vector GetNormal(Point point)
        {
            return Normal;
        }

        public override IMaterial GetMaterial()
        {
            return material;
        }

        public override bool IsIntersects(Ray ray)
        {
            double result = -(Vector.Dot(ray.Direction,Normal));
            if (result > 0)
            {
                Vector k = Center - ray.Origin;
                double scale = -(Vector.Dot(k,Normal))/result;
                return scale >= 0;
            }

            return false;

            // if ray*normal = 0, direction&plane are parallel
            // if (p0-ray.Origin)*normal = 0, direction is the part of plane
            // if ray*normal != 0, it's intersects
        }

        public override Point IntersectionPoint(Ray ray)
        {
            Vector k = Center - ray.Origin;
            double scale = -(Vector.Dot(k,Normal) / -Vector.Dot(ray.Direction,Normal));

            double X = ray.Origin.X + scale * ray.Direction.X;
            double Y = ray.Origin.Y + scale * ray.Direction.Y;
            double Z = ray.Origin.Z + scale * ray.Direction.Z;

            return new Point(X, Y, Z);

            // (p-p0)*normal = 0 ; plane formula
            // p = scale*ray+start ; direction formula

            // (scale*ray+start - p0)*normal = 0
            // scale*ray*normal + (start - p0)*normal = 0 ; start - p0 = k
            // scale*ray*normal + k*normal = 0
            // scale = -k*normal/ray*normal
        }
        public override double GetMaxX()
        {
            return 100;
        }

        public override double GetMaxY()
        {
            return 100;
        }

        public override double GetMaxZ()
        {
            return 100;
        }

        public override double GetMinX()
        {
            return -100;
        }

        public override double GetMinY()
        {
            return -100;
        }

        public override double GetMinZ()
        {
            return -100;
        }
        
        public override Point GetCenter()
        {
            return Center;
        }
        public override Double[] Bari(Point p){
            return null;
        }
    }
}
