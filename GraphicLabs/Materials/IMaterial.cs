using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Materials
{
    public interface IMaterial
    {
        public float isMirror();
        public Vector biDirScat(Vector wo, Vector wi, Figure f, Point p);
        public Ray reflectedRay(Vector direction, Vector normal, Point intersectionPoint);

        public Vector GetColor();
        public int[,] GetTexture();
    }
}
