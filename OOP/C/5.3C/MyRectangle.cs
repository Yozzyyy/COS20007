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
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;



        public MyRectangle(SplashKitSDK.Color clr, float x, float y, int width, int height) : base(clr)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;

        }
        public MyRectangle() : this(Color.RandomRGB(255), 0, 0, 100, 100) { }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }


        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            FillRectangle(Color, X, Y, _width, _height);

        }

        public override void DrawOutline()
        {
            FillRectangle(SplashKitSDK.Color.Black, X - 2, Y - 2, _width + 4, _height + 4); // No need for SplashKit prefix
        }

        public override bool IsAt(Point2D point)
        {
            return (point.X >= X && point.X <= X + _width) &&
           (point.Y >= Y && point.Y <= Y + _height);
        }
        public override void SaveTo(StreamWriter _writer)
        {
            _writer.WriteLine("Rectangle");
            base.SaveTo(_writer);
            _writer.WriteLine(Width);
            _writer.WriteLine(Height);
            
        }
        public override void LoadFrom(StreamReader _reader)
        {
            base.LoadFrom(_reader);
            Width = _reader.ReadInteger();
            Height = _reader.ReadInteger();
        }






    }
}
