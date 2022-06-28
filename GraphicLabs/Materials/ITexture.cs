using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.Materials
{
    public interface ITexture
    {
        Vector GetColor(float u, float v, Vector vec);
    }   
}
