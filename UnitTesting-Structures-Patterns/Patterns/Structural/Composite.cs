using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Structural
{
    //Basically a mechanism for treating individual objects and compositions of the objects universally

    public class GraphicFigures
    {
        public string Color;
        public virtual string Name { get; set; } = "default";

        Lazy<List<GraphicFigures>> children = new Lazy<List<GraphicFigures>>();
        public List<GraphicFigures> Children => children.Value;

        public void Print(StringBuilder sb, int depth)
        {
            sb.Append(new String('*', depth))
                .Append(string.IsNullOrEmpty(Color) ? string.Empty : Color + " ")
                .AppendLine(Name);
            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class Circle : GraphicFigures
    {
        public Circle(string color)
        {
            Color = color;
            Name = "Circle";
        }
    }

    public class Triangle : GraphicFigures
    {
        public Triangle(string color)
        {
            Color = color;
            Name = "Triangle";
        }
    }


    //var oneObject = new GraphicFigures();
    //oneObject.Children.Add(new Circle("black"));
    //        oneObject.Children.Add(new Circle("White"));


    //        var group = new GraphicFigures();
    //group.Children.Add(new Triangle("purple"));
    //        group.Children.Add(new Triangle("red"));

    //        oneObject.Children.Add(group);

    //        System.Console.WriteLine(oneObject);


    //Composite var 2

    public static class NodeExtension
    {
        public static void ConnectTo(this IEnumerable<Node> first, IEnumerable<Node> second)
        {
            if (ReferenceEquals(first, second)) return;

            foreach (var from in first)
            {
                foreach (var to in second)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }

    public class Node : IEnumerable<Node>
    {
        public string value;
        public object[] data;

        public List<Node> In, Out;

        public Node()
        {
            In = new List<Node>();
            Out = new List<Node>();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NodeGroup : Collection<Node>
    {

    }




    //var nod1 = new Node();
    //var nod2 = new Node();

    //nod1.ConnectTo(nod2);

    //        var nodgr1 = new NodeGroup();
    //var nodgr2 = new NodeGroup();
    //nodgr2.Add(nod2);


    //        nodgr1.Add(new Node());
    //        nod1.ConnectTo(nodgr1);

    //        nodgr1.ConnectTo(nodgr2);



    //composite var 3

    public interface GraphicShapes
    {
        public void Add(GraphicShapes shape);

        public string GetShapes();
    }

    public class AlmostSquare : GraphicShapes
    {
        public void Add(GraphicShapes shape)
        {
            
        }

        public string GetShapes()
        {
            return "Almostsquare";
        }
    }

    public class NotSquare : GraphicShapes
    {
        public void Add(GraphicShapes shape)
        {

        }

        public string GetShapes()
        {
            return "Notsquare";
        }
    }

    public class CompositeShape : GraphicShapes
    {
        private Lazy<List<GraphicShapes>> childrenShapes = new Lazy<List<GraphicShapes>>();
        public List<GraphicShapes> children => childrenShapes.Value;
        public void Add(GraphicShapes shape)
        {
            childrenShapes.Value.Add(shape);
        }

        public string GetShapes()
        {
            int i = 0;
            var sb = new StringBuilder().Append("Branch(");
            foreach (var element in children)
            {
                sb.Append(element.GetShapes());
                if (i != childrenShapes.Value.Count)
                {
                    sb.Append("+");
                }
                i++;
            }
            return sb.Append(")").ToString();
        }
    }

}
