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
        int[] winSize = [800,600];

        Vector2 oldMousePos;
        Vector2 currentMousePos;

        int extraLines = 20;

        int spacingThreshold = 10;
        int spacingThresholdForward = 100;
        float xSpacing = 30;
        float ySpacing = 30;

        int angleThreshold = 200;
        float xAngle = 0;
        float yAngle = 0;

        int sideThreshold =50;
        float sideOffset = 0;

        Vector2 horizonPoint = new Vector2(400, 300); // Fix this

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 

        void DrawGrid(float x, float y, float xAngle, float yAngle, float sideOffset)
        {
            // Make horizon line
            Draw.LineColor = Color.Black;
            Draw.Line(0, horizonPoint.Y, winSize[0], horizonPoint.Y);
            Draw.Circle(horizonPoint, 3);

            // Draw lines from horizon line

            Draw.LineColor = Color.Black;
            for (float i = 0; i < winSize[0]*3/x; i++)
            {
                Draw.Line(horizonPoint.X, horizonPoint.Y, i * x - winSize[0], winSize[1]);
            }


            // Draw Cartesian Grid
            Draw.LineColor = Color.Blue;
            for (float i = 0 - (x * extraLines)/x; i < winSize[0] + x / x; i++)
            {
                Draw.Line(new Vector2(i*x+sideOffset, 0), new Vector2(i*x+xAngle+sideOffset, winSize[1])); // Draw y lines every {x} pixels
            }
            Draw.LineColor = Color.Red;
            for (float i = 0 - (y * extraLines)/y; i < winSize[0] + y / y; i++)
            {
                Draw.Line(new Vector2(0, i*y), new Vector2(winSize[0], i*y+yAngle)); // Draw x lines every {y} pixels
            }
         

        }

        public void Setup()
        {
            Window.SetSize(winSize[0], winSize[1]);
            Window.TargetFPS = 60;
            Window.SetTitle("2D Drawing - Christopher Lawrick-McKinnon");

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White); // Clear screen

            currentMousePos = Input.GetMousePosition(); // Refresh mouse pos from previous frame

            if (Input.IsMouseButtonDown(0) == true)
            {
                xAngle += currentMousePos.X - oldMousePos.X;
                if (xAngle < -angleThreshold) {  xAngle = -angleThreshold; }
                if (xAngle > angleThreshold) {  xAngle = angleThreshold; }
                yAngle += currentMousePos.Y - oldMousePos.Y;
                if (yAngle < -angleThreshold) { yAngle = -angleThreshold; }
                if (yAngle > angleThreshold) { yAngle = angleThreshold; }
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.W) == true)
            {
                xSpacing++; // Update change in grid spacing
                ySpacing++; // Update change in grid spacing
                if (xSpacing > spacingThresholdForward) { xSpacing = spacingThresholdForward; } // x Threshold
                if (ySpacing > spacingThresholdForward) { ySpacing = spacingThresholdForward; } // y Threshold
                Console.WriteLine($"xSpacing: {xSpacing}\nySpacing: {ySpacing}");
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S) == true)
            {
                xSpacing--;// Update change in grid spacing
                ySpacing--;// Update change in grid spacing
                if (xSpacing < spacingThreshold) { xSpacing = spacingThreshold; } // x Threshold
                if (ySpacing < spacingThreshold) { ySpacing = spacingThreshold; } // y Threshold
                Console.WriteLine($"xSpacing: {xSpacing}\nySpacing: {ySpacing}");
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) == true)
            {
                sideOffset++;// Update change in left movement
                if (sideOffset < -sideThreshold) { sideOffset = -sideThreshold; } // left Threshold
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) == true)
            {
                sideOffset--;// Update change in right movement
                if (sideOffset > sideThreshold) { sideOffset = sideThreshold; } // right Threshold
            }

            DrawGrid(xSpacing, ySpacing, xAngle, yAngle, sideOffset);

            oldMousePos = currentMousePos; // Remember mouse pos from current frame
        }
    }

}
