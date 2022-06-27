using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Basic
{
    public class Color
    {
        public int r;
        public int g;
        public int b;

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public Color(int value)
        {
            r = value;
            g = value;
            b = value;
        }
        public Color()
        {
            r = 255;
            g = 255;
            b = 255;
        }
        public static Color operator *(Color color, double intensity)
        { 
            Color newColor = new Color((int)(color.r * intensity), (int)(color.g * intensity), (int)(color.b * intensity));
            return newColor;
        }
     
        public static Color operator /(Color color, double intensity)
        { 
            Color newColor = new Color((int)(color.r / intensity), (int)(color.g / intensity), (int)(color.b / intensity));
            return newColor;
        }

        public override string ToString()
        {
            return $"RGB: {r}, {g}, {b}";
        }
    }
}
