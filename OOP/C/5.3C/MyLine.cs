using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame;
using SplashKitSDK;

namespace shapedrawerV3
{
    public class MyLine : Shape
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
        public MyLine() : this(Color.Black, 165, 165, 200, 200) { }


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
            SplashKit.DrawRectangle(SplashKitSDK.Color.Black, X - 2, Y - 2, EndY + 4, EndX + 4); // No need for SplashKit prefix
        }

        public override bool IsAt(Point2D point)
        {
            return SplashKit.PointOnLine(point, SplashKit.LineFrom(X, Y, EndY, EndX));
        }
        public override void SaveTo(StreamWriter _writer)
        {
            _writer.WriteLine("Line");
            base.SaveTo(_writer);
            _writer.WriteLine(EndY);
            _writer.WriteLine(EndX);
            _writer.WriteLine($"{(int)(Color.R * 255)},{(int)(Color.G * 255)},{(int)(Color.B * 255)}");
        }
        public override void LoadFrom(StreamReader _reader)
        {
            base.LoadFrom(_reader);
            EndX = _reader.ReadInteger();
            EndY = _reader.ReadInteger();
        }




    }
}
