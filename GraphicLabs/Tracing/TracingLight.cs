using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs.TreeStuff;
using GraphicLabs.Tracing;
using GraphicLabs;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Tracing
{
    public class TracingLight
    {
        /*public Figure FindNearest(Scene scene, int i, int j)
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
        }*/
        
        public Figure FindNearest(Scene scene, List<Figure> figures, int i, int j)
        {
            Figure nearestFigure = figures[0];
            double distance = Double.PositiveInfinity;
            for (int k = 0; k < figures.Count; k++)
            {
                if (figures[k].IsIntersects(scene.cameraOnScene.ray(i, j)))
                {
                    Vector distanceVector = new Vector(scene.cameraOnScene.cameraOrigin, figures[k].IntersectionPoint(scene.cameraOnScene.ray(i, j)));

                    if (distanceVector.Length() < distance)
                    {
                        nearestFigure = figures[k];
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
            Camera camera = new Camera(0, 0, -11, 0, 5, -2, 200, 200);
            //ILight lightSource = new DirectionalLight(new Vector(0, 1, 1));
            ILight lightSource = new PointLight(new Point(0, 1, 1));
            //ILight lightSource = new EnviromentLight();
            Scene scene = new Scene(camera, lightSource);
            Triangle platform = new Triangle(new Point(5, 0.31989, 5), new Point(-5, 0.31989, 0), new Point(5, 0.31989, -5));

            OBJReader objreader = new OBJReader(source);
            List<Point> initialPoints = objreader.getPointsAndNormals();
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
            //platform.Transform(transMatrix);
            List<Triangle> objects = objreader.getTriangles(points);
            
            foreach (var o in objects)
            {
                scene.addFigure(o);
            }

            //scene.addFigure(platform);
            return scene;
        }

        public double[,] Trace(Scene scene)
        {
            double[,] screenDrawer = new double[scene.cameraOnScene.width, scene.cameraOnScene.height];

            List<double> Xlist = new List<double>();
            List<double> Ylist = new List<double>();
            List<double> Zlist = new List<double>();
            
            double minX = Double.MaxValue;
            double maxX = Double.MinValue;
            double minY = Double.MaxValue;
            double maxY = Double.MinValue;
            double minZ = Double.MaxValue;
            double maxZ = Double.MinValue;

           // List<Box> boxes = new List<Box>();
            
            foreach (Figure o in scene.figuresOnScene)
            {
                /*double currentMinX = Math.Min(o.C.X, Math.Min(o.A.X, o.B.X));
                double currentMaxX = Math.Max(o.C.X, Math.Max(o.A.X, o.B.X));
                
                double currentMinY = Math.Min(o.C.Y, Math.Min(o.A.Y, o.B.Y));
                double currentMaxY = Math.Max(o.C.Y, Math.Max(o.A.Y, o.B.Y));
                
                double currentMinZ = Math.Min(o.C.Z, Math.Min(o.A.Z, o.B.Z));
                double currentMaxZ = Math.Max(o.C.Z, Math.Max(o.A.Z, o.B.Z));
                */
                //boxes.Add(new Box(o.GetMaxX(), o.GetMaxY(), o.GetMaxZ(), o.GetMinX(), o.GetMinY(), o.GetMinZ()));

                if (o.GetMaxX() > maxX) maxX = o.GetMaxX();
                if (o.GetMaxY() > maxY) maxY = o.GetMaxY();
                if (o.GetMaxZ() > maxZ) maxZ = o.GetMaxZ();
                if (o.GetMinX() < minX) minX = o.GetMinX();
                if (o.GetMinY() < minY) minY = o.GetMinY();
                if (o.GetMinZ() < minZ) minZ = o.GetMinZ();
            }
            
            
            Console.WriteLine("MIN X: " + minX);
            Console.WriteLine("MAX X: " + maxX);
            Console.WriteLine("MIN Y: " + minY);
            Console.WriteLine("MAX Y: " + maxY);
            Console.WriteLine("MIN Z: " + minZ);
            Console.WriteLine("MAX Z: " + maxZ);

            Box box = new Box(maxX, maxY, maxZ, minX, minY, minZ);
            box.figures = scene.figuresOnScene;

            Tree BVH = new Tree(box);
            
            
            for (int i = 0; i < scene.cameraOnScene.width; i++)
            {
                for (int j = 0; j < scene.cameraOnScene.height; j++)
                {
                    if (BVH.root.box.IsIntersects(scene.cameraOnScene.ray(i, j)))
                    {
                        //double t = 0;
                        
                        if (BVH.root.left.box.IsIntersects(scene.cameraOnScene.ray(i, j)))
                        {
                            Figure nearestFigure = FindNearest(scene, BVH.root.left.box.figures, i, j);

                            if (nearestFigure.IsIntersects(scene.cameraOnScene.ray(i, j)))
                            {
                                Vector norm =
                                    nearestFigure.GetNormal(
                                        nearestFigure.IntersectionPoint(scene.cameraOnScene.ray(i, j)));
                                double lightDot = Vector.Dot(norm, lightReverseVector);
                                Ray newDirRay =
                                    new Ray(
                                        (norm * 0.1) + (nearestFigure.IntersectionPoint(scene.cameraOnScene.ray(i, j))),
                                        lightReverseVector);

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
                        
                        if (BVH.root.right.box.IsIntersects(scene.cameraOnScene.ray(i, j)))
                        {
                            Figure nearestFigure = FindNearest(scene, BVH.root.right.box.figures, i, j);

                        if (nearestFigure.IsIntersects(scene.cameraOnScene.ray(i, j)))
                        {
                            var intersectionPoint = nearestFigure.IntersectionPoint(scene.cameraOnScene.ray(i,j));
                            var normals = nearestFigure.GetNormal(intersectionPoint);
                            foreach (var norm in normals)
                            {
                                var lightReverseVector = scene.light.generateDirection(norm, intersectionPoint);
                                double lightDot = Vector.Dot(norm, lightReverseVector);
                                var newDirRay = new Ray(norm * 0.001 + intersectionPoint, lightReverseVector);
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
                        }
                        else screenDrawer[i, j] = -10;
                    }
                    else screenDrawer[i, j] = -10;
                }
                
            }
            return screenDrawer;
        }
    }
}
