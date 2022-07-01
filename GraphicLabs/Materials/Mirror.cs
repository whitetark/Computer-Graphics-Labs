using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Materials;

public class Mirror : IMaterial
{
    public Vector biDirScat(Vector wo, Vector wi, Figure f, Point p) {
        return new Vector(1,1,1);
    }
    public float isMirror(){
        return 1f;
    }
    

    public Ray reflectedRay(Vector dir, Vector normalAtPoint, Point intersectionPoint) {
        Ray reflectRay = new Ray(intersectionPoint, dir - (normalAtPoint * (Vector.Dot(dir, normalAtPoint) * 2)).Normalize());
        return reflectRay;
    }

    public Vector GetColor()
    {
        return null;
    }

    public int[,] GetTexture()
    {
        return null;
    }
}