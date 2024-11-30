﻿using SplashKitSDK;
using static SplashKitSDK.SplashKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapedrawerV3
{
    public abstract class Shape
    {
        // Private fields
        private Color _color;
        private float _x, _y;
        private float _width, _height;
        private bool _selected;
        private int x_pos;
        private int y_pos;
        private Color clr;

        public Shape(int x_pos, int y_pos)
        {
            this.x_pos = x_pos;
            this.y_pos = y_pos;
        }

        public Shape(Color clr)
        {
            _color = clr;
        }



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
        public abstract void Draw();


        // Method to check if a point is within the shape's area
        public abstract bool IsAt(Point2D point);
       // {
           // return (point.X >= _x && point.X <= _x + _width) &&
                   //(point.Y >= _y && point.Y <= _y + _height); // to find the coord after or below a specify point
        //}//if x is more than equal to x and x is less than equal to x + width is to find the whole width dimension of the box

        public bool Selected //determine selected shapes value and return
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public abstract void DrawOutline(); //draw outline to show that its highlighted 
        //{
           // SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        //}
    }
}
