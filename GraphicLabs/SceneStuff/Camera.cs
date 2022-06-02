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

        public Camera Direction()
        {
            get=>vectorDirection;
            set
            {
                vectorDirection=value.Normalize();
            }
        }

        private double distance {get; set;}
        private double height = 15.0;
        private double width = 15.0;
        private double xChange;
        private double yChange;

        private Point leftTop;
        private Point rightTop;
        private Point leftBottom;

        public Camera(double xChanges, double yChanges)
        {   
            xChange=xChanges;
            yChange=yChanges;

            leftTop = new Point(0, height/2.0, width/2.0);
            rightTop = new Point(0, height/2.0, -width/2.0);
            leftBottom = new Point(0, -height/2.0, width/2.0);
        }

        private Vector xIncrease => (rightTop-leftTop).Scale(1.0/xChange);
        private Vector yIncrease => (leftBottom-leftTop).Scale(1.0/yChange);

        private Point pixelPosition(int x, int y)
        {
            return leftTop + xIncrease.Scale(x) + yIncrease.Scale(y);
        }

        private Ray ray()
        {
            return new Ray()
            {
                start = startPoint, dir = (pixelPosition(x,y)-startPoint).Normalize()
            };
        }


    }
}
