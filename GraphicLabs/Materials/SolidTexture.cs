using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.Materials
{
    public class SolidTexture : ITexture
    {
        private readonly Vector colorish;
        public SolidTexture(Vector Color)
        {
            colorish = Color;
        }

        public Vector GetColor(float u, float v, Vector vec)
        {
            return colorish;
        }
    }
}
