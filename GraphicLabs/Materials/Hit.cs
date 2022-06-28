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
        public float dist;
        public float u;
        public float v;
        public Point point { get; set; }
        public Vector vector;
        public Vector Normal;
        public IMaterial material;
    }
}
