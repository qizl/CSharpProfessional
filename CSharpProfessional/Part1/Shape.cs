using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProfessional.Part1
{
    public class BaseDemo
    { }

    public class ChildDemo : BaseDemo
    {
        public BaseDemo Get(BaseDemo demo)
        {
            return demo;
        }
    }

    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            return string.Format("Width: {0}, Height: {1}", Width, Height);
        }
    }

    public class Rectangle : Shape
    { }

    public interface IIndex<out T>
    {
        T this[int index] { get; }
        int Count { get; }
    }

    public class RectangleCollection : IIndex<Rectangle>
    {
        private Rectangle[] data = new Rectangle[3]
        {
            new Rectangle { Height=2, Width=5 },
            new Rectangle { Height=3, Width=7 },
            new Rectangle { Height=4.5, Width=2.9 }
        };

        private static RectangleCollection coll;
        public static RectangleCollection GetRectangles()
        {
            return coll ?? (coll = new RectangleCollection());
        }

        public Rectangle this[int index]
        {
            get
            {
                if (index < 0 || index > data.Length)
                    throw new ArgumentOutOfRangeException("index");
                return data[index];
            }
        }

        public int Count
        {
            get
            {
                return data.Length;
            }
        }
    }

    public interface IDisplay<in T>
    {
        string Show(T shape);
    }

    public class ShapeDisplay : IDisplay<Shape>
    {
        public string Show(Shape s)
        {
            return s.GetType().Name + "," + s.Width + "," + s.Height;
        }
    }
}
