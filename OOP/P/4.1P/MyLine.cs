using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace shapedrawerV3
{
    public class MyLine : Shape //inheritances from shape.cs
    {
        private float _endY;
        private float _endX;

        public MyLine(Color clr, float startX, float startY, float endY, float endX) : base(clr)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }
       

        public float EndX
        {
            get
            {
                return _endX;

            }
            set
            {
                _endX = value;
            }
        }
        public float EndY
        {
            get
            {
                return _endY;

            }
            set
            {
                _endY = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, EndY, EndX);

        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(SplashKit.ColorBlack(), X, Y, 3);
            SplashKit.FillCircle(SplashKit.ColorBlack(), EndX, EndY, 3);
        }

        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointOnLine(point, SplashKit.LineFrom(X, Y, EndY + 1, EndX + 1));
        }




    }
}
