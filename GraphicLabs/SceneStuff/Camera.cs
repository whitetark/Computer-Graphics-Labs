using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff
{
    public class Camera
    {
        public Point cameraOrigin { get; set; }
        
        private Vector vectorDirection;
        private Point screenOrigin;

        private double fov = 60;
        

        public int height { get; set; }
        public int width { get; set; }
        private double imageAspectRatio;
        

        public Camera(double x, double y, double z, double X, double Y, double Z, int screenHeight, int screenWidth)
        {
            cameraOrigin = new Point(x, y, z);
            vectorDirection = new Vector(X, Y, Z);

            screenOrigin = vectorDirection.Normalize() + cameraOrigin;

            height = screenHeight;
            width = screenWidth;
            
        }
        

        private Point PixelPosition(int x, int y)
        {
            double xPos = (2 * ((x + 0.5) / (double)width) - 1) * Math.Tan(fov / 2 * Math.PI / 180);
            double yPos = 1 - 2 * ((y + 0.5) / (double)height) * Math.Tan(fov / 2 * Math.PI / 180);
            if (width > height)
            {
                imageAspectRatio = (double)width / (double)height;
                xPos *= imageAspectRatio;
            }
            else if (height > width)
            {
                imageAspectRatio = (double)height / (double)width;
                yPos *= imageAspectRatio;
            }
            return new Point(xPos, yPos, vectorDirection.Z);
        }

        public Ray ray(int x, int y)
        {
            return new Ray(cameraOrigin, new Vector(cameraOrigin, PixelPosition(x, y)).Normalize());
        }
    }   


    
}
