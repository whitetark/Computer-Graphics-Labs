using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Basic
{
    public class Ray
    {
        public Point Origin { get; set; }
        public Vector Direction { get; set; }

        public Ray(Point origin, Vector direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Ray(Point origin, Point end)
        {
            Origin = origin;
            Direction = new Vector(origin, end);
        }

    }
}
