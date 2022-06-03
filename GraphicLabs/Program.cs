using GraphicLabs.Figures;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;

namespace CompGraphics
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(10, 10);
            
            Sphere testSphere = new Sphere(new Point(0, 0, 0), 10);
            
            int[,] screenDrawer = new int[20, 20];
            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    
                    // If we find an intersection of the ray with our triangle, we draw "pixel"
                    if (testSphere.IsIntersects(camera.ray(i, j)))
                    {
                        screenDrawer[i, j] = 1;
                    }
                }
            }

                
            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(screenDrawer[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

//plane intersection test

/*
Plane plane = new Plane(new Vector(new Point(2,3,3),new Point(2,2,3)), new Point(2,3,3));
Ray ray = new Ray(new Point(1, 0, 1), new Point(1, 2, 2));
var truth = plane.IsIntersects(ray);
Console.WriteLine(truth);
var point = plane.IntersectionPoint(ray);
Console.WriteLine(point.ToString());
*/

//sphere intersection test

/*
Sphere sphere = new Sphere(new Point(3,2,2), 1);
Ray ray = new Ray(new Point(1, 0, 1), new Point(1.5, 0.5, 1.5));
var truth = sphere.IsIntersects(ray);
Console.WriteLine(truth);
var point = sphere.IntersectionPoint(ray);
Console.WriteLine(point.ToString());
*/

//triangle intersection test

/*
Triangle triangle = new Triangle(new Point(1, 0, 0), new Point(0, 1, 0), new Point(0, 0, 1));
Ray ray = new Ray(new Point(5, 0.5, 3), new Point(4, 0.5, 2.4));
var truth = triangle.IsIntersects(ray);
Console.WriteLine(truth);
var point = triangle.IntersectionPoint(ray);
Console.WriteLine(point.ToString());
*/