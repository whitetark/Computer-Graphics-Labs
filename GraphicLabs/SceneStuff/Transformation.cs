using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff
{
    public class Transformation
    {
        public static Matrix CreateTransformationMatrix(double transX, double transY, double transZ, double kx, double ky, double kz, double angleX, double angleY, double angleZ)
        {
            if (kx == 0 || ky == 0 || kz == 0)
            {
                throw new ArgumentException("Scale can't be 0");
            }

            var trans = CreateTranslationMatrix(transX, transY, transZ);
            var scale = CreateScaleMatrix(kx, ky, kz);
            var rotate = CreateRotationMatrix(angleX, angleY, angleZ);

            return trans * (scale * rotate);
        }

        private static Matrix CreateTranslationMatrix(double x, double y, double z)
        {
            Matrix transM = new Matrix();
            transM.body = new double[4, 4]
            {
                { 1, 0, 0, x },
                { 0, 1, 0, y },
                { 0, 0, 1, z },
                { 0, 0, 0, 1 }
            };
            return transM;
        }
        private static Matrix CreateScaleMatrix(double kx, double ky, double kz)
        {
            Matrix scaleM = new Matrix();
            scaleM.body = new double[4, 4]
            {
                { kx, 0, 0, 0 },
                { 0, ky, 0, 0 },
                { 0, 0, kz, 0 },
                { 0, 0, 0, 1 }
            };
            return scaleM;
        }
        private static Matrix CreateRotationMatrix(double xa, double ya, double za)
        {
            Matrix x = new Matrix();
            Matrix y = new Matrix();
            Matrix z = new Matrix();

            double radCoef = Math.PI / 180;

            x = x.RotateAroundX(radCoef * xa);
            y = y.RotateAroundY(radCoef * ya);
            z = z.RotateAroundZ(radCoef * za);

            return (x * y) * z;
        }
    }
}
