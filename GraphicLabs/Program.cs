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
            Camera camera = new Camera(100, 20, 0, 0, -5);
            
            Sphere testSphere = new Sphere(new Point(1, 0, 10), 7);
            Sphere testSphere2 = new Sphere(new Point(2, 3, 10), 20);
            
            List<Sphere> figures = new List<Sphere>(); //rewrite to figures
            figures.Add(testSphere);
            figures.Add(testSphere2);
            
            char[,] screenDrawer = new char[20, 20];

            DirectionalLight lightSource = new DirectionalLight() {Direction = new Vector(0, 1, 1)};
            
           /* for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (testSphere.IsIntersects(camera.ray(i, j)))
                    {
                        Vector norm = new Vector(testSphere.Center, testSphere.IntersectionPoint(camera.ray(i, j)));
                        if((Vector.Dot(norm, lightSource.Direction)) < 0) screenDrawer[i, j] = ' ';
                        if(((Vector.Dot(norm, lightSource.Direction)) >= 0) && ((Vector.Dot(norm, lightSource.Direction)) < 0.2)) screenDrawer[i, j] = '.';
                        if(((Vector.Dot(norm, lightSource.Direction)) >= 0.2) && ((Vector.Dot(norm, lightSource.Direction)) < 0.5)) screenDrawer[i, j] = '*';
                        if(((Vector.Dot(norm, lightSource.Direction)) >= 0.5) && ((Vector.Dot(norm, lightSource.Direction)) < 0.8)) screenDrawer[i, j] = '0';
                        if((Vector.Dot(norm, lightSource.Direction)) >= 0.8) screenDrawer[i, j] = '#';
                    }
                    else screenDrawer[i, j] = ' ';
                }
            } */
           
           for (int i = 0; i < 20; i++)
           {
               for (int j = 0; j < 20; j++)
               {
                   double distance = 0;
                   Sphere nearestFigure = figures[0]; //rewrite to figures
                   for (int k = 0; k < figures.Count; k++)
                   {
                       if (figures[k].IsIntersects(camera.ray(i, j)))
                       {
                           Vector distanceVector = new Vector(camera.startPoint, figures[k].IntersectionPoint(camera.ray(i, j)));
                           if (distanceVector.Length() > distance)
                           {
                               nearestFigure = figures[k];
                               distance = distanceVector.Length();
                           }
                       }
                   }

                   if (nearestFigure.IsIntersects(camera.ray(i, j)))
                   {
                       Vector norm = new Vector(nearestFigure.Center,
                           nearestFigure.IntersectionPoint(camera.ray(i, j)));
                       if ((Vector.Dot(norm, lightSource.Direction)) < 0) screenDrawer[i, j] = ' ';
                       if (((Vector.Dot(norm, lightSource.Direction)) >= 0) &&
                           ((Vector.Dot(norm, lightSource.Direction)) < 0.2)) screenDrawer[i, j] = '.';
                       if (((Vector.Dot(norm, lightSource.Direction)) >= 0.2) &&
                           ((Vector.Dot(norm, lightSource.Direction)) < 0.5)) screenDrawer[i, j] = '*';
                       if (((Vector.Dot(norm, lightSource.Direction)) >= 0.5) &&
                           ((Vector.Dot(norm, lightSource.Direction)) < 0.8)) screenDrawer[i, j] = '0';
                       if ((Vector.Dot(norm, lightSource.Direction)) >= 0.8) screenDrawer[i, j] = '#';
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