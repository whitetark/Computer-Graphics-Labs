using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Materials
{
    public interface IMaterial
    {
        public float isMirror();
        public Ray reflectedRay(Vector direction, Vector normal, Point intersectionPoint);
    }
}
