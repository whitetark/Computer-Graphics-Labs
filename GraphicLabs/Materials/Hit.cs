using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.SceneStuff;
using GraphicLabs.Basic;

namespace GraphicLabs.Materials
{
    public class Hit
    {
        public Point point { get; }
        public Vector normal { get; }
        public IMaterial? material { get; }
        public float T { get; }

        public Hit(Point point, Vector normal, IMaterial material, float t)
        {
            this.point = point;
            this.normal = normal;
            this.material = material;
            T = t;
        }
    }
}
