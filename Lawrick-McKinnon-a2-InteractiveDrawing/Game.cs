// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Vector2 origin = new Vector2(50,50);
        Vector2 end = new Vector2(500,500);
        int[] canvasSize = [800,600];

        Vector2 oldMousePos;
        Vector2 currentMousePos;

        float xSpacing = 30;
        float ySpacing = 30;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 

        void DrawGrid(float x, float y)
        {
            for (int i = 0; i < canvasSize[0]+x / x; i++)
            {
                Draw.Line(new Vector2(i*x, 0), new Vector2(i*x, canvasSize[1])); // Draw y lines every {x} pixels
            }
            for (int i = 0; i < canvasSize[0] + y / y; i++)
            {
                Draw.Line(new Vector2(0, i*y), new Vector2(canvasSize[0], i*y)); // Draw x lines every {y} pixels
            }
        }

        public void Setup()
        {
            Window.SetSize(canvasSize[0], canvasSize[1]);
            Window.TargetFPS = 60;
            Window.SetTitle("2D Drawing - Christopher Lawrick-McKinnon");

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White); // Clear screen

            currentMousePos = Input.GetMousePosition();

            if (Input.IsMouseButtonDown(0) == true)
            {
                xSpacing += currentMousePos.X - oldMousePos.X; // Update change in grid spacing
                if (xSpacing < 10) { xSpacing = 10; } // x Threshold
                ySpacing += currentMousePos.Y - oldMousePos.Y;// Update change in grid spacing
                if (ySpacing < 10) { ySpacing = 10; } // y Threshold

                Console.WriteLine($"xSpacing: {xSpacing}\nySpacing: {ySpacing}");
            }

            DrawGrid(xSpacing, ySpacing);

            oldMousePos = currentMousePos;
        }
    }

}
