using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Structural
{

    public interface ITea
    {
        public void DrinkTea();
    }

    public class TeaCup : ITea
    {
        public void DrinkTea()
        {
            Console.WriteLine("drinking tea using cup");
        }
    }

    public class Customer
    {
        public void DrinkTea(ITea tea)
        {
            tea.DrinkTea();
        }
    }


    public interface IBottle
    {
        public void DrinkTeaFromBottle();
    }

    public class Bottle : IBottle
    {
        public void DrinkTeaFromBottle()
        {
            Console.WriteLine("drinking tea from bottle");
        }
    }

    public class CupToBottleAdapter : ITea
    {
        IBottle bottle;

        public CupToBottleAdapter(IBottle bottle)
        {
            this.bottle = bottle;
        }

        public void DrinkTea()
        {
            bottle.DrinkTeaFromBottle();
        }

    }


    //var customer = new Customer();

    //TeaCup cup = new TeaCup();

    //customer.DrinkTea(cup);

    //        Bottle bottle = new Bottle();

    //CupToBottleAdapter cupToBottle = new CupToBottleAdapter(bottle);

    //customer.DrinkTea(cupToBottle);



    ////Adapter 2

    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

    public class Drawer
    {
        public void Draw(Point point)
        {
            Console.SetCursorPosition(point.x, point.y); Console.Write(".");
        }
    }



    public class Line
    {
        public Point start, end;

        public Line(Point start, Point end)
        {
            this.start = start ?? throw new ArgumentNullException(nameof(start));
            this.end = end ?? throw new ArgumentNullException(nameof(end));
        }

    }

    public class Figures : Collection<Line>
    {

    }

    public class Square : Figures
    {
        public Square(int x,int y, int size)
        {
            Add(new Line(new Point(x, y), new Point(x + size, y)));
            Add(new Line(new Point(x+size, y), new Point(x+size, y+size)));
            Add(new Line(new Point(x, y), new Point(x, y+size)));
            Add(new Line(new Point(x, y+size), new Point(x + size, y+size)));
        }
    }


    public class LineToPointAdapter : Collection<Point>
    {
        public LineToPointAdapter(Line line)
        {
            int left = Math.Min(line.start.x, line.end.x);
            int right = Math.Max(line.start.x, line.end.x);
            int top = Math.Min(line.start.y, line.end.y);
            int bottom = Math.Max(line.start.y, line.end.y);

            int dx = right - left;
            int dy = line.end.y - line.start.y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x<= right; ++x)
                { 
                    Add(new Point(x, top));
                }
            }
           
        }
    }

    //List<Figures> figures = new List<Figures>() { new Square(1, 1, 4) };

    //        foreach (var f in figures)
    //        {
    //            var drawer = new Drawer();
    //            foreach (var line in f)
    //            {
    //                var adapter = new LineToPointAdapter(line);
    //                foreach (var item in adapter)
    //                {
    //                    drawer.Draw(item);
    //                }
    //            }
    //        }


}

