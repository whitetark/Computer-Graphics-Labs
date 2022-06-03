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
        private Point startPoint { get; set; }
        private Vector vectorDirection = new Vector(-1.0, 0, 0);
        
        /*public Camera Direction()
        {
            get=>vectorDirection;
            set
            {
                vectorDirection=value.Normalize();
            }
        }*/

        public Vector Direction
        {
            get { return vectorDirection; }
            set { vectorDirection = value.Normalize(); }
        }

        private double distance {get; set;}
        private double height = 20.0;
        private double width = 20.0;
        private double xChange;
        private double yChange;

        private Point leftTop;
        private Point rightTop;
        private Point leftBottom;
        
        private Vector xIncrease => new Vector(leftTop, rightTop) * (1.0/xChange);
        private Vector yIncrease => new Vector(leftTop, leftBottom) * (1.0/yChange);

        public Camera(double xChanges, double yChanges)
        {   
            xChange=xChanges;
            yChange=yChanges;

            leftTop = new Point(0, height/2.0, width/2.0);
            rightTop = new Point(0, height/2.0, -width/2.0);
            leftBottom = new Point(0, -height/2.0, width/2.0);
        }

        private Point PixelPosition(int x, int y)
        {
            return (xIncrease * x) + (yIncrease * y) + leftTop;
        }
/*
        private Ray ray()
        {
            return new Ray()
            {
                start = startPoint, dir = (PixelPosition(x,y)-startPoint).Normalize()
            };
        }


        private Ray ray(int x, int y)
        {
            return new Ray() {Origin = startPoint, Direction = (PixelPosition(x,y)-startPoint).Normalize();}
        }   */

    }
}
