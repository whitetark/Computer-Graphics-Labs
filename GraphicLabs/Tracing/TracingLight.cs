using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs;

namespace GraphicLabs.Tracing
{
    public class TracingLight
    {
        

        public void Trace(Scene scene)
        {
           



            char[,] screenDrawer = new char[scene.cameraOnScene.width, scene.cameraOnScene.height];

            Vector lightReverseVector = new Vector(0, 0, 0) - scene.dirLight.Direction;

            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 20; j++)
            //    {
            //        if (testSphere.IsIntersects(camera.ray(i, j)))
            //        {
            //            Vector norm = testSphere.GetNormal(testSphere.IntersectionPoint(camera.ray(i, j)));
            //            if ((Vector.Dot(norm, lightSource.Direction)) < 0) screenDrawer[i, j] = ' ';
            //            if (((Vector.Dot(norm, lightSource.Direction)) >= 0) && ((Vector.Dot(norm, lightSource.Direction)) < 0.2)) screenDrawer[i, j] = '.';
            //            if (((Vector.Dot(norm, lightSource.Direction)) >= 0.2) && ((Vector.Dot(norm, lightSource.Direction)) < 0.5)) screenDrawer[i, j] = '*';
            //            if (((Vector.Dot(norm, lightSource.Direction)) >= 0.5) && ((Vector.Dot(norm, lightSource.Direction)) < 0.8)) screenDrawer[i, j] = '0';
            //            if ((Vector.Dot(norm, lightSource.Direction)) >= 0.8) screenDrawer[i, j] = '#';
            //        }
            //        else screenDrawer[i, j] = ' ';
            //    }
            //}


            //
            for (int i = 0; i < scene.cameraOnScene.width; i++)
            {
                for (int j = 0; j < scene.cameraOnScene.height; j++)
                {
                    double distance = Double.PositiveInfinity;
                    Figure nearestFigure = scene.figuresOnScene[0];
                    for (int k = 0; k < scene.figuresOnScene.Count; k++)
                    {
                        if (scene.figuresOnScene[k].IsIntersects(scene.cameraOnScene.ray(i, j)))
                        {
                            Vector distanceVector = new Vector(scene.cameraOnScene.cameraOrigin, scene.figuresOnScene[k].IntersectionPoint(scene.cameraOnScene.ray(i, j)));

                            if (distanceVector.Length() < distance)
                            {
                                nearestFigure = scene.figuresOnScene[k];
                                distance = distanceVector.Length();
                            }
                        }
                    }

                    if (nearestFigure.IsIntersects(scene.cameraOnScene.ray(i, j)))
                    {
                        Vector norm = nearestFigure.GetNormal(nearestFigure.IntersectionPoint(scene.cameraOnScene.ray(i, j)));
                        double lightDot = Vector.Dot(norm, lightReverseVector);
                        if (lightDot < 0) screenDrawer[i, j] = ' ';
                        else if ((lightDot >= 0) &&
                            (lightDot < 0.2)) screenDrawer[i, j] = '.';
                        else if ((lightDot >= 0.2) &&
                            (lightDot < 0.5)) screenDrawer[i, j] = '*';
                        else if ((lightDot >= 0.5) &&
                            (lightDot < 0.8)) screenDrawer[i, j] = '0';
                        else if (lightDot >= 0.8) screenDrawer[i, j] = '#';
                    }

                }
            }

            for (int i = 0; i < scene.cameraOnScene.width; i++)
            {
                for (int j = 0; j < scene.cameraOnScene.height; j++)
                {
                    Console.Write(screenDrawer[i, j]);
                    Console.Write("  "); //for better picture
                }
                Console.WriteLine();
            }
        }

        
    }
}
