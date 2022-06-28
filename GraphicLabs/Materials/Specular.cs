using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;


namespace GraphicLabs.Materials
{


    public class Specular : IMaterial
    {
        private readonly ITexture albedo;
        private readonly float refraction;
        public Specular(ITexture albedo, float refraction)
        {
            this.albedo = albedo;
            this.refraction = refraction;
        }

        public Specular(float refraction, Vector albedo)
        {
            this.albedo = new SolidTexture(albedo);
            this.refraction=refraction;
        }

        public bool Scatter(Ray ray, Hit hit, ref Vector vec, ref Ray scattered)
        {
            vec = albedo.GetColor(hit.u, hit.v, hit.vector);
            var refracted = vec.X;
            return true;
        }
    }
}
