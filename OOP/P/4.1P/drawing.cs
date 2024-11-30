using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace shapedrawerV3
{
    public class Drawing
    {
        private readonly List<Shape> _shapes; //readonly list to store all shapes
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>(); //list for the _shapes
            _background = background;
        }
        public Drawing() : this(Color.White) //"this" to avoid duplication
        {

        }

        public int ShapeCount //property to class Drawing that returns the Count from the _shapes list collection object 
        {
            get { return _shapes.Count; } //get and return from _shapes = new List<shape> 
        }

        public void AddShape(Shape s) //adds shape into the list from shape
        {
            _shapes.Add(s);
        }
        public void RemoveShape()
        {
            foreach (Shape s in _shapes.ToList())//each shape s is from AddShape
            {
                if (s.Selected) //if shape is selected 
                {
                    _shapes.Remove(s); //remove the shape
                }

            }
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }
        public Color Background
        {
            get
            {
                return _background;

            }
            set
            {
                _background = value;
            }


        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes) // if selected is true "on shape" 
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else //else false
                {
                    s.Selected = false;
                }
            }
        }

        public List<Shape> SelectedShapes()
        {
            List<Shape> _Selectedshapes = new List<Shape>();
            foreach (Shape s in _Selectedshapes)
            {
                if (s.Selected)
                {
                    _Selectedshapes.Add(s);
                }
            }
            return _Selectedshapes;
        }
    }
}

