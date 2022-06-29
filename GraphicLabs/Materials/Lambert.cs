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
    public class Lambert : IMaterial
    {

        private Vector color;
        private int[,] texture;


        public Lambert(Vector colorish, int[,] texture)
        {
            color = colorish;
            this.texture = texture;
        }



        public static float RandomF()
        {
            Random rnd = new Random();
            return (float)rnd.NextDouble();

        }
        public static Vector RandomUnitedVectors(Vector norm)
        {
            Vector vec;
            do
            {
                vec = new Vector(2 * RandomF() - 1, 2 * RandomF() - 1, 2 * RandomF() - 1);

            } while (Vector.Dot(norm, vec) <= 0);
            return vec;
        }

        public float isMirror()
        {
            return 0;
        }

        public Vector biDirScat(Vector wo, Vector wi, Figure f, Point p)
        {
            if (texture == null) {
                return (color * (1/(2*Math.PI)));
            }
            else{
                Double[] xy = f.Bari(p);
                Color color = new Color(texture[(int) (xy[0]*texture.Length), (int) (xy[1]*texture.Length)]);
                return new Vector(color.r,color.g, color.b);
            }
        }

        public Ray reflectedRay(Vector direction, Vector normal, Point intersectionPoint)
        {
            Ray reflected_ray=new Ray(intersectionPoint, (direction - (normal * (2 * Vector.Dot(normal, direction)))).Normalize());

            return reflected_ray;
        }

    }
}
