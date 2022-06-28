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
        
        public bool isLeft { get; set; }

        public Node()
        {
            parent = null;
            isLeft = false;
        }
        
        public Node(Box b, Node p, bool l)
        {
            box = b;
            parent = p;
            left = null;
            right = null;
            isLeft = l;
        }

        public bool IsLeaf()
        {
            if ((left == null) && (right == null))
                return true;
            return false;
        }

        public Node EscapeNode()
        {
            if (isLeft)
            {
                
                return parent.right;
            }
            else
            {
                if (parent == null) return right;
                return parent.EscapeNode();
            }
        }
        
    }
}