using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shapedrawerV3;
using SplashKitSDK;
using static SplashKitSDK.SplashKit;

namespace shapedrawerV3
{
    public class MyCircles : Shape //inherintance from shape.cs
    {
        private int _radius;

        public MyCircles(SplashKitSDK.Color clr, float x, float y, int radius) : base(clr)
        {
            X = x;
            Y = y;
            _radius = radius;

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



    }
}
