using System;

namespace UnitTesting_Structures_Patterns.Patterns.Structural
{
    public interface IDrawer
    {
        void DrawFigure();
    }

    public class FiguresShapes
    {
        public class Circle : IDrawer
        {
            public void DrawFigure()
            {
                Console.WriteLine("drawing circle");
            }
        }

        public class Triangle : IDrawer
        {
            public void DrawFigure()
            {
                Console.WriteLine("drawing triangle");
            }
        }
    }

    public abstract class FiguresFilling
    {
        protected IDrawer drawer;

        public FiguresFilling(IDrawer drawer)
        {
            this.drawer = drawer ?? throw new ArgumentNullException(nameof(drawer));
        }

        public abstract void Draw();

    }

    public class CharFilling : FiguresFilling
    {
        public CharFilling(IDrawer drawer) : base(drawer)
        {
        }

        public override void Draw()
        {
            drawer.DrawFigure(); Console.WriteLine(" using CHARS");
        }
    }

    public class NumFilling : FiguresFilling
    {
        public NumFilling(IDrawer drawer) : base(drawer)
        {

        }

        public override void Draw()
        {
            drawer.DrawFigure(); Console.WriteLine(" using NUMS");
        }
    }


    //var drawer = new Triangle();
    //var filling = new CharFilling(drawer);
    //var filling1 = new NumFilling(drawer);
    //filling.Draw();
    //        filling1.Draw();
}
