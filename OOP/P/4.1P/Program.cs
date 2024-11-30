using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shapedrawerV3;
using SplashKitSDK;



namespace shapedrawerV3
{
    public class Program //this program.cs main job is to draw the canvas and display the varibles
    {
        

        private enum Shapekind 
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            Shapekind kindToAdd = Shapekind.Rectangle;  

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.KeyTyped(KeyCode.RKey)) // for  rectangle shape
                {
                    kindToAdd = Shapekind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))// for Circle shape
                {
                    kindToAdd = Shapekind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey)) // for Line
                {
                    kindToAdd = Shapekind.Line;
                }


                if (SplashKit.MouseClicked(MouseButton.LeftButton)) //the left click to add the shapes according to what we set previously 
                {
                    Shape newShape;

                    switch (kindToAdd) // intiliazing the switch case
                    {
                        case Shapekind.Circle: // the shapekind will help determind what key are we on 
                            newShape = new MyCircles(Color.Blue, 20, 20, 50); //case switch to Circles
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            newShape.Color = SplashKit.RandomRGBColor(255);
                            break;

                        case Shapekind.Line: // Shapekind will help determine what key are we on 
                            newShape = new MyLine(Color.Black, 165, 165, 200, 200); // if switch is in Line then executed
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            newShape.Color = SplashKit.RandomRGBColor(255);
                            break;

                        default:
                            newShape = new MyRectangle(Color.Red, 456, 234, 150, 80); //set default to rectangle so that the first thing is the rectangle
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            newShape.Color = SplashKit.RandomRGBColor(255);
                            break;

                            // Add the new shape to the Drawing object


                    }
                    myDrawing.AddShape(newShape); //call addShape function from drawing.cs
                    Console.WriteLine("added shape");


                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) //spacekey to change different background color
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);

                }
                if (SplashKit.MouseClicked(MouseButton.RightButton)) //right click to highlight outline of the shape 
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());

                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))//to delete shapes drawn
                {
                        Console.WriteLine("Deleted shape");
                    
                    myDrawing.RemoveShape(); //call the remove shape function frim drawing.cs
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
//when declare a new function do NOT place it in the same function as prev or else the function wouldnt as its not the main father function
