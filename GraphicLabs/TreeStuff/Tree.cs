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
    public class Tree
    {
        public Node root { get; set; }
        public int nodeCount { get; set; }

        public Tree(Box b)
        {
            root = AddNode(null, b);
        }

        private Node AddNode(Node node, Box b0)
        {
            if (b0.figures.Count < 50) return new Node(b0, node);
            
            nodeCount++;
            Console.WriteLine(nodeCount);
            Node newNode = new Node(b0, node);
            Box boxLeft;
            Box boxRight;

            Console.WriteLine("num: " + newNode.box.figures.Count);
            List<Figure> figuresLeft = new List<Figure>();
            List<Figure> figuresRight = new List<Figure>();

            double extX = newNode.box.MaxX - newNode.box.MinX;
            double extY = newNode.box.MaxY - newNode.box.MinY;
            double extZ = newNode.box.MaxZ - newNode.box.MinZ;
            
            double leftMinX = Double.MaxValue;
            double leftMaxX = Double.MinValue;
            double leftMinY = Double.MaxValue;
            double leftMaxY = Double.MinValue;
            double leftMinZ = Double.MaxValue;
            double leftMaxZ = Double.MinValue;
                    
            double rightMinX = Double.MaxValue;
            double rightMaxX = Double.MinValue;
            double rightMinY = Double.MaxValue;
            double rightMaxY = Double.MinValue;
            double rightMinZ = Double.MaxValue;
            double rightMaxZ = Double.MinValue;

            if (extX > extY)
            {
                if (extX > extZ)
                {
                    double middleX = (newNode.box.MinX + newNode.box.MaxX) / 2;
                    
                    foreach (var b in newNode.box.figures)
                    {
                        if (b.GetCenter().X < middleX)
                        {
                            figuresLeft.Add(b);
                            if (b.GetMaxX() > leftMaxX) leftMaxX = b.GetMaxX();
                            if (b.GetMaxY() > leftMaxY) leftMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > leftMaxZ) leftMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < leftMinX) leftMinX = b.GetMinX();
                            if (b.GetMinY() < leftMinY) leftMinY = b.GetMinY();
                            if (b.GetMinZ() < leftMinZ) leftMinZ = b.GetMinZ();
                        }
                        else
                        {
                            figuresRight.Add(b);
                            if (b.GetMaxX() > rightMaxX) rightMaxX = b.GetMaxX();
                            if (b.GetMaxY() > rightMaxY) rightMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > rightMaxZ) rightMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < rightMinX) rightMinX = b.GetMinX();
                            if (b.GetMinY() < rightMinY) rightMinY = b.GetMinY();
                            if (b.GetMinZ() < rightMinZ) rightMinZ = b.GetMinZ();
                        }
                    }
                }
                else
                {
                    double middleZ = (newNode.box.MinZ + newNode.box.MaxZ) / 2;
                    
                    foreach (var b in newNode.box.figures)
                    {
                        if (b.GetCenter().Z < middleZ)
                        {
                            figuresLeft.Add(b);
                            if (b.GetMaxX() > leftMaxX) leftMaxX = b.GetMaxX();
                            if (b.GetMaxY() > leftMaxY) leftMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > leftMaxZ) leftMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < leftMinX) leftMinX = b.GetMinX();
                            if (b.GetMinY() < leftMinY) leftMinY = b.GetMinY();
                            if (b.GetMinZ() < leftMinZ) leftMinZ = b.GetMinZ();
                        }
                        else
                        {
                            figuresRight.Add(b);
                            if (b.GetMaxX() > rightMaxX) rightMaxX = b.GetMaxX();
                            if (b.GetMaxY() > rightMaxY) rightMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > rightMaxZ) rightMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < rightMinX) rightMinX = b.GetMinX();
                            if (b.GetMinY() < rightMinY) rightMinY = b.GetMinY();
                            if (b.GetMinZ() < rightMinZ) rightMinZ = b.GetMinZ();
                        }
                    }
                }
            }
            else
            {
                if (extY > extZ)
                {
                    double middleY = (newNode.box.MinY + newNode.box.MaxY) / 2;
                    
                    foreach (var b in newNode.box.figures)
                    {
                        if (b.GetCenter().Y < middleY)
                        {
                            figuresLeft.Add(b);
                            if (b.GetMaxX() > leftMaxX) leftMaxX = b.GetMaxX();
                            if (b.GetMaxY() > leftMaxY) leftMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > leftMaxZ) leftMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < leftMinX) leftMinX = b.GetMinX();
                            if (b.GetMinY() < leftMinY) leftMinY = b.GetMinY();
                            if (b.GetMinZ() < leftMinZ) leftMinZ = b.GetMinZ();
                        }
                        else
                        {
                            figuresRight.Add(b);
                            if (b.GetMaxX() > rightMaxX) rightMaxX = b.GetMaxX();
                            if (b.GetMaxY() > rightMaxY) rightMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > rightMaxZ) rightMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < rightMinX) rightMinX = b.GetMinX();
                            if (b.GetMinY() < rightMinY) rightMinY = b.GetMinY();
                            if (b.GetMinZ() < rightMinZ) rightMinZ = b.GetMinZ();
                        }
                    }
                }
                else
                {
                    double middleZ = (newNode.box.MinZ + newNode.box.MaxZ) / 2;
                    
                    foreach (var b in newNode.box.figures)
                    {
                        if (b.GetCenter().Z < middleZ)
                        {
                            figuresLeft.Add(b);
                            if (b.GetMaxX() > leftMaxX) leftMaxX = b.GetMaxX();
                            if (b.GetMaxY() > leftMaxY) leftMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > leftMaxZ) leftMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < leftMinX) leftMinX = b.GetMinX();
                            if (b.GetMinY() < leftMinY) leftMinY = b.GetMinY();
                            if (b.GetMinZ() < leftMinZ) leftMinZ = b.GetMinZ();
                        }
                        else
                        {
                            figuresRight.Add(b);
                            if (b.GetMaxX() > rightMaxX) rightMaxX = b.GetMaxX();
                            if (b.GetMaxY() > rightMaxY) rightMaxY = b.GetMaxY();
                            if (b.GetMaxZ() > rightMaxZ) rightMaxZ = b.GetMaxZ();
                            if (b.GetMinX() < rightMinX) rightMinX = b.GetMinX();
                            if (b.GetMinY() < rightMinY) rightMinY = b.GetMinY();
                            if (b.GetMinZ() < rightMinZ) rightMinZ = b.GetMinZ();
                        }
                    }
                }
            }
            
            boxLeft = new Box(leftMaxX, leftMaxY, leftMaxZ, leftMinX, leftMinY, leftMinZ);
            boxLeft.figures = figuresLeft;
            Console.WriteLine(leftMinX+ " " + leftMaxX + " " + leftMinY + " " + leftMaxY +  " " +  leftMinZ + " " + leftMaxZ);
            boxRight = new Box(rightMaxX, rightMaxY, rightMaxZ, rightMinX, rightMinY, rightMinZ);
            boxRight.figures = figuresRight;

            newNode.left = AddNode(newNode, boxLeft);
            newNode.right = AddNode(newNode, boxRight);

            return newNode;
        }
    }
}