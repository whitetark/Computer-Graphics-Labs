using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs.Tracing;
using GraphicLabs;

namespace GraphicLabs.TreeStuff
{
    public class Node
    {
        public Box box { get; set; }
        
        public Node left { get; set; }
        public Node right { get; set; }
        public Node parent { get; set; }

        public Node()
        {
            parent = null;
        }
        
        public Node(Box b, Node p)
        {
            box = b;
            parent = p;
            left = null;
            right = null;
        }
        
    }
}