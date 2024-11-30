using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame;
using shapedrawerV3;
using SplashKitSDK;
using static SplashKitSDK.SplashKit;

namespace shapedrawerV3
{ 
    public class MyCircles : Shape
    {
        private int _radius;

        public MyCircles(Color clr, float x, float y, int radius) : base(clr)
        {
            X = x;
            Y = y;
            _radius = radius;

        }
        public MyCircles() : this(Color.Blue, 20, 20, 15)
        {
            _radius = 20;   
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            FillCircle(Color, X, Y, Radius );

        }

        public override void DrawOutline()
        {
            FillCircle(SplashKitSDK.Color.Black, X - 2, Y - 2, Radius + 4); // No need for SplashKit prefix
        }

        public override bool IsAt(Point2D point)
        {

            double a = (double)(point.X - X);
            double b = (double)(point.Y - Y);

            if (Math.Sqrt(a * a + b * b) < _radius)
            {
                return true;
            }
            return false;

        }
        public override void SaveTo(StreamWriter _writer)// overriding from SaveTo in shape.cs
        {
            _writer.WriteLine("Circle");
            base.SaveTo(_writer);
            _writer.WriteLine(Radius);
            _writer.WriteLine($"{(int)(Color.R * 255)},{(int)(Color.G * 255)},{(int)(Color.B * 255)}");

        }
        public override void LoadFrom(StreamReader _reader) // overriding from LoadFrom in shape.cs
        {
            base.LoadFrom(_reader);
            Radius = _reader.ReadInteger();
            
        }



    }
}
