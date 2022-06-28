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
    public class Lambert : IMaterial
    {
        private readonly ITexture albedo;

        public Lambert (Vector colorish)
        {
            albedo = new SolidTexture(colorish);
        }

        public Lambert (ITexture texture)
        {
            this.albedo = texture;
        }


        public static float RandomF()
        {
            Random rnd=new Random();
            return (float)rnd.NextDouble();

        }
        public static  Vector RandomUnitedVectors(Vector norm)
        {
            Vector vec;
            do
            {
                vec = new Vector(2 * RandomF() - 1, 2 * RandomF() - 1, 2*RandomF()-1);

            } while (Vector.Dot(norm, vec) <= 0);   
            return vec;
        }
        public bool Scatter(Ray ray, Hit hit, ref Vector vec, ref Ray scattered)
        {
            var reflected = hit.Normal + hit.vector + RandomUnitedVectors(hit.Normal);
            vec = albedo.GetColor(hit.u, hit.v, hit.vector);
            scattered = new Ray(hit.point, reflected-hit.vector);
            return true;
        }

    }
}
