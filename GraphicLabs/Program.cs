using GraphicLabs.Figures;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;
using GraphicLabs.Tests;

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