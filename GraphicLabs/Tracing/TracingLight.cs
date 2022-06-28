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
        
        public double FindShortestDistance(Scene scene, List<Figure> figures, int i, int j)
        {
            double distance = Double.PositiveInfinity;
            for (int k = 0; k < figures.Count; k++)
            {
                if (figures[k].IsIntersects(scene.cameraOnScene.ray(i, j)))
                {
                    Vector distanceVector = new Vector(scene.cameraOnScene.cameraOrigin, figures[k].IntersectionPoint(scene.cameraOnScene.ray(i, j)));

                    if (distanceVector.Length() < distance)
                    {
                        distance = distanceVector.Length();
                    }
                }
            }

            return distance;
        }
        
        public Scene createTestingScene()
        {
            Camera camera = new Camera(0, 0, 0, 0, 0, -1, 200, 100);
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
        
        public Scene createTestingSceneFromFile(string source)
        {
            Camera camera = new Camera(0, 0, -11, 0, 0, -3, 100, 100);
            DirectionalLight lightSource = new DirectionalLight() { Direction = new Vector(0, -1, 1) };
            Scene scene = new Scene(camera, lightSource);

            OBJReader objreader = new OBJReader(source);
            List<Point> initialPoints = objreader.getPoints();
            List<Point> points = new List<Point>();

            // Transformation Process
            // First Row - t       x      y      z
            // Secon Row - s      kx     ky     kzS
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

            return scene;
        }

        public double[,] Trace(Scene scene)
        {
            double[,] screenDrawer = new double[scene.cameraOnScene.width, scene.cameraOnScene.height];

            Vector lightReverseVector = new Vector(0, 0, 0) - scene.dirLight.Direction;
            
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
            Console.WriteLine("num : " + BVH.root.box.figures.Count);
            Console.WriteLine("num left: " + BVH.root.left.box.figures.Count);
            Console.WriteLine("num right: " + BVH.root.right.box.figures.Count);

            for (int i = 0; i < scene.cameraOnScene.width; i++)
            {
                for (int j = 0; j < scene.cameraOnScene.height; j++)
                {
                    Node curr_node = BVH.root;
                    double minT = double.MaxValue;

                    Figure nearestFigure = null;

                    while (curr_node != null)
                    {

                        if (!curr_node.IsLeaf())
                        {
                            double t = FindShortestDistance(scene, curr_node.box.figures, i, j);
                            Figure hit = FindNearest(scene, curr_node.box.figures, i, j);

                            if (t < minT)
                            {
                                minT = t;
                                nearestFigure = hit;

                            }

                            if (curr_node == BVH.root)
                                curr_node = curr_node.left; 
                            else curr_node = curr_node.EscapeNode();

                        }

                        else
                        {
                            if (curr_node.box.IsIntersects(scene.cameraOnScene.ray(i, j)))
                                curr_node = curr_node.left;

                            else
                                curr_node = curr_node.EscapeNode();
                        }

                    }

                    if (nearestFigure != null)
                    {
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

                }
            }
            
            return screenDrawer;

        }
    }
}
