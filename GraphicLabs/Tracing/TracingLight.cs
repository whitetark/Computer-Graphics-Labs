﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Tree;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs.Tracing;
using GraphicLabs;
using GraphicLabs.SceneStuff.Light;

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
        
        public Scene createTestingScene()
        {
            Camera camera = new Camera(0, 0, 0, 0, 0, -1, 200, 100);
            ILight lightSource = new DirectionalLight(new Vector(2, 1, -1));
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
        
        public Scene createTestingSceneFromFile(string source)
        {
            Camera camera = new Camera(0, 0, -11, 0, 0, -1, 100, 100);
            //ILight lightSource = new DirectionalLight(new Vector(0, -1, 1));
            //ILight lightSource = new PointLight(new Point(0, -1, 1));
            ILight lightSource = new AmbientLight();
            Scene scene = new Scene(camera, lightSource);
            Plane plane = new Plane(new Vector(0, 1, 0), new Point(-0.38, -0.32, -0.38));
            OBJReader objreader = new OBJReader(source);
            List<Point> initialPoints = objreader.getPoints();
            List<Point> points = new List<Point>();

            // Transformation Process
            // First Row - t       x      y      z
            // Secon Row - s      kx     ky     kz
            // Third Row - r  angleX angleY angleZ
            var transMatrix = Transformation.CreateTransformationMatrix(0, 0, 0,
                                                                        1, 1, 1,
                                                                        270, 0, 135);
            
            foreach (var p in initialPoints)
            {
                points.Add(p.Transform(transMatrix));
            }
            List<Triangle> objects = objreader.getTriangles(points);
            
            foreach (var o in objects)
            {
                scene.addFigure(o);
            }

            scene.addFigure(plane);
            return scene;
        }

        public double[,] Trace(Scene scene)
        {
            double[,] screenDrawer = new double[scene.cameraOnScene.width, scene.cameraOnScene.height];

            List<double> Xlist = new List<double>();
            List<double> Ylist = new List<double>();
            List<double> Zlist = new List<double>();
            
            var triangles = new List<Triangle>();
            foreach(Figure o in scene.figuresOnScene)
            {
                if (o.Type == "Triangle")
                {
                    triangles.Add(o);
                }
            }

            foreach (Triangle o in triangles)
            {
                Xlist.Add(o.A.X);
                Xlist.Add(o.B.X);
                Xlist.Add(o.C.X);
                
                Ylist.Add(o.A.Y);
                Ylist.Add(o.B.Y);
                Ylist.Add(o.C.Y);
                
                Zlist.Add(o.A.Z);
                Zlist.Add(o.B.Z);
                Zlist.Add(o.C.Z);
            }
            
            double minX = Xlist.Min();
            double maxX = Xlist.Max();
            double minY = Ylist.Min();
            double maxY = Ylist.Max();
            double minZ = Zlist.Min();
            double maxZ = Zlist.Max();
            
            Console.WriteLine("MIN X: " + minX);
            Console.WriteLine("MAX X: " + maxX);
            Console.WriteLine("MIN Y: " + minY);
            Console.WriteLine("MAX Y: " + maxY);
            Console.WriteLine("MIN Z: " + minZ);
            Console.WriteLine("MAX Z: " + maxZ);

            Box box = new Box(maxX, maxY, maxZ, minX, minY, minZ);
            
            for (int i = 0; i < scene.cameraOnScene.width; i++)
            {
                for (int j = 0; j < scene.cameraOnScene.height; j++)
                {
                    if (box.IsIntersects(scene.cameraOnScene.ray(i, j)))
                    {
                        Figure nearestFigure = FindNearest(scene, i, j);

                        if (nearestFigure.IsIntersects(scene.cameraOnScene.ray(i, j)))
                        {
                            var intersectionPoint = nearestFigure.IntersectionPoint(scene.cameraOnScene.ray(i,j));
                            Vector norm = nearestFigure.GetNormal(intersectionPoint);
                            var lightReverseVector = scene.light.generateDirection(norm, intersectionPoint);
                            double lightDot = Vector.Dot(norm, lightReverseVector);
                            Ray newDirRay = new Ray((norm * 0.001 + intersectionPoint), lightReverseVector);

                            screenDrawer[i, j] = lightDot;

                            foreach (var obj in scene.figuresOnScene)
                            {
                                if (obj.IsIntersects(newDirRay))
                                {
                                    screenDrawer[i, j] = 0;
                                    break;
                                }
                            }
                        }
                        else screenDrawer[i, j] = -10;
                    }
                    else
                    {
                        screenDrawer[i, j] = -10;
                    }
                }
            }
            return screenDrawer;
        }
    }
}
