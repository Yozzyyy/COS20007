using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapedrawer
{
    internal class shape
    {
        // Private fields
        private Color _color;
        private float _x, _y;
        private float _width, _height;

        // Properties
        public Color Color //call and intialize the variable
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X //call and intialize the variable
        {
            get { return _x; } //get and store the x value
            set { _x = value; }
        }

        public float Y //call and intialize the variable
        {
            get { return _y; } //get and store the y value
            set { _y = value; }
        }

        public float Width //call and intialize the variable
        {
            get { return _width; } //get and store the width 
            set { _width = value; }
        }

        public float Height //call and intialize the variable
        {
            get { return _height; } //get and store the height 
            set { _height = value; }
        }

        // Method to draw the shape
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // Method to check if a point is within the shape's area
        public bool IsAt(Point2D point)
        {
            return (point.X >= _x && point.X <= _x + _width) &&
                   (point.Y >= _y && point.Y <= _y + _height); // to find the coord after or below a specify point
        }//if x is more than equal to x and x is less than equal to x + width is to find the whole width dimension of the box
    }
}

