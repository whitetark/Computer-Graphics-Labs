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


        public Lambert(Vector color, int[,] texture)
        {
            this.color = color;
            this.texture = texture;
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
