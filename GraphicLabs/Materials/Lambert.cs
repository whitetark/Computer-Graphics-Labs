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

        public float IsMirror()
        {
            return 0;
        }

        public Ray reflectedRay(Vector direction, Vector normal, Point intersectionPoint)
        {
            Ray reflected_ray=new Ray(intersectionPoint, direction.sub(normal.multiply(direction.anotherDot(normal)*2)).Normalize());

            return reflected_ray;
        }

    }


}
