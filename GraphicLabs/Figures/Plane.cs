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
    }
}
