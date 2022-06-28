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
    public class Tree
    {
        public Node root { get; set; }


        public Tree(List<Box> b)
        {
            root = new Node(b);
        }
    }
}