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
            Camera camera = new Camera(20, 20, 0, 0, -5);
            
            Sphere testSphere = new Sphere(new Point(0, 0, 10), 7);
            
            char[,] screenDrawer = new char[20, 20];

            DirectionalLight lightSource = new DirectionalLight() {Direction = new Vector(0, 1, 1)};
            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (testSphere.IsIntersects(camera.ray(i, j)))
                    {
                        if((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) < 0) screenDrawer[i, j] = ' ';
                        if(((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) >= 0) && ((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) < 0.2)) screenDrawer[i, j] = '.';
                        if(((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) >= 0.2) && ((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) < 0.5)) screenDrawer[i, j] = '*';
                        if(((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) >= 0.5) && ((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) < 0.8)) screenDrawer[i, j] = '0';
                        if((Vector.Dot(camera.ray(i, j).Direction, lightSource.Direction)) >= 0.8) screenDrawer[i, j] = '#';
                    }
                    else screenDrawer[i, j] = ' ';
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