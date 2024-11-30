using System;
using System.ComponentModel.Design;
using SplashKitSDK;

namespace shapedrawer
{
    public class Program //this program.cs main job is to draw the canvas and display the varibles
    {


        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();  

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    int x_pos = (int)SplashKit.MouseX();
                    int y_pos = (int)SplashKit.MouseY();

                    Shape newShape = new Shape();
                    newShape.X = x_pos;
                    newShape.Y = y_pos;
                    newShape.Width = 100; // Set default width
                    newShape.Height = 100; // Set default height
                    newShape.Color = SplashKit.RandomRGBColor(255);

                    // Add the new shape to the Drawing object
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
                    if (SplashKit.KeyTyped(KeyCode.BackspaceKey)) //backspce key to delete
                    {
                        Console.WriteLine("Deleted shape");
                    }
                    if (SplashKit.KeyTyped(KeyCode.DeleteKey)) //delete key to delete
                    {
                        Console.WriteLine("Deleted shape");
                    }
                    myDrawing.RemoveShape(); //call the remove shape function frim drawing.cs
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
//when declare a new function do NOT place it in the same function as prev or else the function wouldnt as its not the main father function
