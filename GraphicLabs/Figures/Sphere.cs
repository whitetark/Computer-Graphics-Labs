using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Figures
{
    public class Sphere
    {
        public Point center { get; set; }
        public double radius { get; set; }

        public Sphere(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public Vector GetNormal(Point point)
        {
            Vector normal = new Vector(center, point).Normalize();
            return normal;
        }
    }
}
