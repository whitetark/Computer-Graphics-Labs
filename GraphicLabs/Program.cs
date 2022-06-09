using GraphicLabs.Figures;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;

namespace CompGraphics
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(0, 0, 0, 0,0, -1, 40, 40);
            
            Sphere testSphere = new Sphere(new Point(1, 1, -10), 2);
            Sphere testSphere2 = new Sphere(new Point(0, 3, -12), 4);
            Triangle testTriangle = new Triangle(   new Point(1, 1, -15), new Point(5, 5, -11), new Point(0, 3, -2));
            Plane testPlane = new Plane(new Vector(0, 0, 1), new Point(0, 0, -20));
            
            List<Figure> figures = new List<Figure>(); 
            figures.Add(testSphere);
            //figures.Add(testSphere2);
            figures.Add(testTriangle);
            //figures.Add(testPlane);
            
            char[,] screenDrawer = new char[camera.width, camera.height];

            DirectionalLight lightSource = new DirectionalLight() {Direction = new Vector(0, 0, -1)};
            Vector lightReverseVector = new Vector(0, 0, 0) - lightSource.Direction;
            
            /*for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (testSphere.IsIntersects(camera.ray(i, j)))
                    {
                        Vector norm = testSphere.GetNormal(testSphere.IntersectionPoint(camera.ray(i, j)));
                        if((Vector.Dot(norm, lightSource.Direction)) < 0) screenDrawer[i, j] = ' ';
                        if(((Vector.Dot(norm, lightSource.Direction)) >= 0) && ((Vector.Dot(norm, lightSource.Direction)) < 0.2)) screenDrawer[i, j] = '.';
                        if(((Vector.Dot(norm, lightSource.Direction)) >= 0.2) && ((Vector.Dot(norm, lightSource.Direction)) < 0.5)) screenDrawer[i, j] = '*';
                        if(((Vector.Dot(norm, lightSource.Direction)) >= 0.5) && ((Vector.Dot(norm, lightSource.Direction)) < 0.8)) screenDrawer[i, j] = '0';
                        if((Vector.Dot(norm, lightSource.Direction)) >= 0.8) screenDrawer[i, j] = '#';
                    }
                    else screenDrawer[i, j] = ' ';
                }
            } 
           */
           for (int i = 0; i < camera.width; i++)
           {
               for (int j = 0; j < camera.height; j++)
               {
                   double distance = Double.PositiveInfinity;
                   Figure nearestFigure = figures[0]; 
                   for (int k = 0; k < figures.Count; k++)
                   {
                       if (figures[k].IsIntersects(camera.ray(i, j)))
                       {
                           Vector distanceVector = new Vector(camera.cameraOrigin, figures[k].IntersectionPoint(camera.ray(i, j)));
                           
                           if (distanceVector.Length() < distance)
                           {
                               nearestFigure = figures[k];
                               distance = distanceVector.Length();
                           }
                       }
                   }

                   if (nearestFigure.IsIntersects(camera.ray(i, j)))
                   {
                       Vector norm = nearestFigure.GetNormal(nearestFigure.IntersectionPoint(camera.ray(i, j)));
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

            for (int i = 0; i < camera.width; i++)
            {
                for (int j = 0; j < camera.height; j++)
                {
                    Console.Write(screenDrawer[i, j]);
                    Console.Write("  "); //for better picture
                }
                Console.WriteLine();
            }
        }
    }
}