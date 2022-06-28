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

namespace GraphicLabs.Tree
{
    public class Node
    {
        public List<Box> boxes { get; set; }
        public Box box { get; set; }
        
        public Node left { get; set; }
        public Node right { get; set; }
        public Node parent { get; set; }

        public Node(List<Box> b)
        {
            boxes = b;
            parent = null;
        }
        
        public Node(List<Box> b, Node p)
        {
            boxes = b;
            parent = p;
        }
        
    }
}