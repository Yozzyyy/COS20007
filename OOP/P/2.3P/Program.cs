using System;
using SplashKitSDK;

namespace shapedrawer
{
    public class Program
    {
        

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600); // window size by dimension 
            shape myShape = new shape //this is for the red box which has a dimension of 200x150 at (100,100)
            { //also move myShape into a new var which is shape
                Color = Color.Green, // color green of the shape 
                X = 0.0f, // coordinates x for the shape 
                Y = 0.0f, // cooord Y for the shape
                Width = 100, // the total pixel of width of the shape 
                Height = 100 // the total pixel of height of the shape 
            }; // since we are declaring both dimensions is the same then the shape would be a square

            do
            {
                SplashKit.ProcessEvents(); // proceed with the drawing
                SplashKit.ClearScreen(); // clear screen make sure its on the blank canvas

                myShape.Draw();

                if (SplashKit.MouseClicked(MouseButton.LeftButton)) // the mouse button LEFT when clicked
                {


                    Point2D pt = SplashKit.MousePosition(); //mouse hover position 

                    if (myShape.IsAt(pt)) //call back the function which 
                    { //IF the mouse clicked is ON the shape then display as given
                        Console.WriteLine($"Mouse is over the shape ({pt.X}, {pt.Y})!"); //if hover over the shape then show text as displayed
                    } //use $ to call a variable to display
                    else //IF the mouse clicked is not within the shape dimension then Display as given
                    {
                        Console.WriteLine($"Mouse is outside the shape ({pt.X}, {pt.Y})"); // display the unit on coords of the are outside with set coords
                    }
                    //placing the it under the mouseleft so when clicked will find a new coords and move object
                    myShape.X = (float)pt.X; //(float) for coords and find the new height Y coords
                    myShape.Y = (float)pt.Y;//(float) for coords and find the new height Y coords
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) //space key
                {
                    Point2D mousePos = SplashKit.MousePosition(); // the cursor position in the canvas
                    if (myShape.IsAt(mousePos)) //identify box position
                    {
                        myShape.Color = SplashKit.RandomColor(); //if cursor is on the box then when clicked spacebar it will change color to a random one 
                    }
                }
                myShape.Draw(); //initiate drawing of shapes 

                SplashKit.RefreshScreen(); //per movement refreshes the shapes 
            } while (!window.CloseRequested); 
        }
    }
}
//when declare a new function do NOT place it in the same function as prev or else the function wouldnt as its not the main father function
