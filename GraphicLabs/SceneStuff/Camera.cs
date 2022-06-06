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
        public Point startPoint;
        private Vector vectorDirection = new Vector(0, 1, 1);

        public Vector Direction
        {
            get => vectorDirection;
            set => vectorDirection=value.Normalize();
        }

        private double distance;
        private double height = 20.0;
        private double width = 20.0;
        private double xChange;
        private double yChange;

        private Point leftTop;
        private Point rightTop;
        private Point leftBottom;

        public Camera(double xChanges, double yChanges, double x, double y, double z)
        {
            startPoint = new Point(x, y, z);
            xChange=xChanges;
            yChange=yChanges;

            leftTop = new Point(0, height/2.0, width/2.0);
            rightTop = new Point(0, height/2.0, -width/2.0);
            leftBottom = new Point(0, -height/2.0, width/2.0);
        }
        
        private Vector xIncrease => new Vector(leftTop, rightTop) * (1.0/xChange);
        private Vector yIncrease => new Vector(leftTop, leftBottom) * (1.0/yChange);

        private Point PixelPosition(int x, int y)
        {
            return (xIncrease * x) + (yIncrease * y) + leftTop;
        }

        public Ray ray(int x, int y)
        {
            Direction = new Vector(startPoint, PixelPosition(x, y)).Normalize();
            return new Ray(startPoint, Direction);
        }
    }   


    
}
