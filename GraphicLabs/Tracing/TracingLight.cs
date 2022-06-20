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
        public Figure FindNearest(Scene scene, int i, int j)
        {
            Figure nearestFigure = scene.figuresOnScene[0];
            double distance = Double.PositiveInfinity;
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

            return nearestFigure;
        }

        private void ScreenDrawer(Camera camera, char[,] screenDrawer)
        {
            for(int i = 0; i < camera.width; i++)
            {
                for (int j = 0; j < camera.height; j++)
                {
                    Console.Write(screenDrawer[i, j]);
                }
                Console.WriteLine();
            }
        }
        public Scene createTestingScene()
        {
            Camera camera = new Camera(0, 0, 0, 0, 0, -1, 80, 80);
            DirectionalLight lightSource = new DirectionalLight() { Direction = new Vector(2, 1, -1) };
            Scene scene = new Scene(camera, lightSource);

            Sphere testSphere = new Sphere(new Point(0, 0, -8), 1);
            Sphere testSphere2 = new Sphere(new Point(0, 3, -12), 4);
            Triangle testTriangle = new Triangle(new Point(0, 0, -15), new Point(2, -1, -5), new Point(-1, 2, -5));
            Plane testPlane = new Plane(new Vector(0, 1, 1), new Point(0, 0, -7));

            // Transformation Process
            // First Row - t       x      y      z
            // Secon Row - s      kx     ky     kz
            // Third Row - r  angleX angleY angleZ
            var transMatrix = Transformation.CreateTransformationMatrix(0, 0, 0,
                                                                        1, 1, 1,
                                                                        0, 0, 0);
            testTriangle = testTriangle.Transform(transMatrix);

            scene.addFigure(testSphere);
            scene.addFigure(testTriangle);
            return scene;
        }
        public void Trace(Scene scene)
        {
            char[,] screenDrawer = new char[scene.cameraOnScene.width, scene.cameraOnScene.height];

            Vector lightReverseVector = new Vector(0, 0, 0) - scene.dirLight.Direction;

            for (int i = 0; i < scene.cameraOnScene.width; i++)
            {
                for (int j = 0; j < scene.cameraOnScene.height; j++)
                {

                    Figure nearestFigure = FindNearest(scene, i, j);

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
           ScreenDrawer(scene.cameraOnScene, screenDrawer);
        }
    }
}
