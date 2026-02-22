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
        static int[] canvasSize = [600,800];
        static int scale;
        static float highlightIntensity = 1f;
        static float blue;
        static Vector2 lightSource = new Vector2(0, 0);



        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 
        
        
        public void Setup()
        {
            Window.SetSize(canvasSize[0], canvasSize[1]);
            Window.TargetFPS = 60;
            Window.SetTitle("2D Drawing - Christopher Lawrick-McKinnon");
            

        }

        // Turn objects from -1 ... 1 cartesian plane object space into screen space
        static public Vector2 TransformVerticies(Vector2 v)
        {

            scale = (int)MathF.Min(canvasSize[0], canvasSize[1]) / 2;


            // Math is x*(w/2)+w/2  >  (x+1)(w/2)

            v.X = (v.X + 1.0f) * scale;
            v.Y = (-v.Y + 1.0f) * scale;

            return v;
        }

        // Custom quad with indentifiable direction functionality
        public void DrawQuad(Vector2 a, Vector2 b, Vector2 c, Vector2 d, int faceUp, int faceRight) 
        {
            int valueUp = 128;
            int valueSide = 128;
            int totalValue;

            Draw.LineSize = 0;          // No outlines
            if (faceUp == 1)            // True
            {
                valueUp = (int)MathF.Floor((lightSource.Y + 1) * 64);
                if (faceRight == 3) { valueSide = valueUp; } // Add proportional side lighting (forward facing sides wont be altered by lighting from Y axis)

            }
            else if(faceUp == 2)        // False
            {
                valueUp = (int)MathF.Floor((lightSource.Y - 1) * -64);
                if (faceRight == 3) { valueSide = valueUp; } // Add proportional side lighting (forward facing sides wont be altered by lighting from Y axis)

            }


            if (faceRight == 1)         // True
            {
                valueSide = (int)MathF.Floor((lightSource.X + 1) * 64);
                if (faceUp == 3) { valueUp = valueSide; } // Add proportional side lighting (sideways facing sides wont be altered by lighting from X axis)

            } else if (faceRight == 2)  // False
            {
                valueSide = (int)MathF.Floor((lightSource.X - 1) * -64);
                if (faceUp == 3) { valueUp = valueSide; } // Add proportional side lighting (sideways facing sides wont be altered by lighting from X axis)

            }

            // Handle shadow & highlight colour
            totalValue = valueUp + valueSide;

            if (totalValue <= 128)      // Shadows
            {
                blue = (128 - totalValue) * highlightIntensity;
                Draw.FillColor = new Color(totalValue, totalValue, totalValue + (int)blue); // Change value (grayscale) + change in blue/yellow

            }
            else                      // Highlights
            {
                blue = (totalValue - 128) * highlightIntensity;
                Draw.FillColor = new Color(totalValue, totalValue, totalValue - (int)blue); // Change value (grayscale) + change in blue/yellow

            }
            Draw.Quad(TransformVerticies(a), TransformVerticies(b), TransformVerticies(c), TransformVerticies(d));
        }

        // Every face shape
        Vector2[][] faceQuads = [
            [new Vector2(0.5f, 0.3f), new Vector2(0f, 0.3f), new Vector2(0f, -0.3f), new Vector2(0.3f, -0.3f), new Vector2(2, 1),], // Middle Face Plate Right
            [new Vector2(-0.5f, 0.3f), new Vector2(0f, 0.3f), new Vector2(0f, -0.3f), new Vector2(-0.3f, -0.3f), new Vector2(2, 2),], // Middle Face Plate Left

            [new Vector2(0.3f, -0.3f), new Vector2(0f, -0.3f), new Vector2(0f, -0.46f), new Vector2(0.1f, -0.46f), new Vector2(2, 1),], // Lower Face Plate Right
            [new Vector2(-0.3f, -0.3f), new Vector2(0f, -0.3f), new Vector2(0f, -0.46f), new Vector2(-0.1f, -0.46f), new Vector2(2, 2),], // Lower Face Plate Right

            [new Vector2(-0.25f, 0.5f), new Vector2(0.25f, 0.5f), new Vector2(0.25f, 0.75f), new Vector2(-0.25f, 0.75f), new Vector2(1, 3),], // Upper Face Plate Middle
            [new Vector2(0.25f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.7f), new Vector2(0.25f, 0.75f), new Vector2(1, 1),], // Upper Face Plate Right
            [new Vector2(-0.25f, 0.5f), new Vector2(-0.5f, 0.5f), new Vector2(-0.5f, 0.7f), new Vector2(-0.25f, 0.75f), new Vector2(1, 2),], // Upper Face Plate Left
            
            [new Vector2(-0.1f, 0f), new Vector2(0.1f, 0f), new Vector2(0.1f, 0.4f), new Vector2(-0.1f, 0.4f), new Vector2(1, 3),], // Nose Bridge
            [new Vector2(0.1f, 0f), new Vector2(0.2f, 0.1f), new Vector2(0.2f, 0.3f), new Vector2(0.1f, 0.4f), new Vector2(3, 1),], // Nose Bridge Right
            [new Vector2(-0.1f, 0f), new Vector2(-0.2f, 0.1f), new Vector2(-0.2f, 0.3f), new Vector2(-0.1f, 0.4f), new Vector2(3, 2),], // Nose Bridge Left
            [new Vector2(0.1f, 0f), new Vector2(0.2f, -0.1f), new Vector2(0.225f,0f), new Vector2(0.2f, 0.1f), new Vector2(3, 1),], // Nose Ala Right
            [new Vector2(-0.1f, 0f), new Vector2(-0.2f, -0.1f), new Vector2(-0.225f,0f), new Vector2(-0.2f, 0.1f), new Vector2(3, 2),], // Nose Ala Left
            [new Vector2(-0.2f, -0.1f), new Vector2(0.2f,-0.1f), new Vector2(0.1f, 0f), new Vector2(-0.1f, 0f), new Vector2(2,3),], // Nose Underside
            [new Vector2(-0.05f, -0.15f), new Vector2(0f, -0.15f), new Vector2(0, -0.1f), new Vector2(-0.05f, -0.1f), new Vector2(3,1),], // Philtrum Right
            [new Vector2(0.05f, -0.15f), new Vector2(0f, -0.15f), new Vector2(0, -0.1f), new Vector2(0.05f, -0.1f), new Vector2(3,2),], // Philtrum Left

            [new Vector2(-0.1f, -0.4f), new Vector2(0.1f, -0.4f), new Vector2(0.06f, -0.36f), new Vector2(-0.06f, -0.36f), new Vector2(1,3),], // Top of Chin
            [new Vector2(-0.2f, -0.2f), new Vector2(0.2f, -0.2f), new Vector2(0.1f, -0.15f), new Vector2(-0.1f, -0.15f), new Vector2(2, 3),], // Top Lip
            [new Vector2(-0.2f, -0.2f), new Vector2(0.2f, -0.2f), new Vector2(0.1f, -0.3f), new Vector2(-0.1f, -0.3f), new Vector2(1, 3),], // Bottom Lip

            [new Vector2(0.2f, 0.1f), new Vector2(0.3f, 0.1f), new Vector2(0.5f, 0.3f), new Vector2(0.2f, 0.3f), new Vector2(1, 1),], // Cheek Right
            [new Vector2(-0.2f, 0.1f), new Vector2(-0.3f, 0.1f), new Vector2(-0.5f, 0.3f), new Vector2(-0.2f, 0.3f), new Vector2(1, 2),], // Cheek Right
            [new Vector2(-0.1f, 0.4f), new Vector2(0.1f, 0.4f), new Vector2(0.25f, 0.5f), new Vector2(-0.25f, 0.5f), new Vector2(1, 3),], // Brow Ridge Middle
            [new Vector2(0.05f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.4f, 0.55f), new Vector2(0.15f, 0.55f), new Vector2(1, 1),], // Brow Ridge Right
            [new Vector2(-0.05f, 0.5f), new Vector2(-0.5f, 0.5f), new Vector2(-0.4f, 0.55f), new Vector2(-0.15f, 0.55f), new Vector2(1, 2),], // Brow Ridge Left

            [new Vector2(0.1f, 0.4f), new Vector2(0.5f, 0.4f), new Vector2(0.5f, 0.5f), new Vector2(0.25f, 0.5f), new Vector2(2,1),], // Lacrimal Gland Right
            [new Vector2(-0.1f, 0.4f), new Vector2(-0.5f, 0.4f), new Vector2(-0.5f, 0.5f), new Vector2(-0.25f, 0.5f), new Vector2(2,2),], // Lacrimal Gland left

        ];
        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White); // Clear screen

            // Keyboard Input
            if (Input.IsKeyboardKeyDown(KeyboardInput.W) == true)
            {
                lightSource.Y += (float)0.01;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S) == true)
            {
                lightSource.Y -= (float)0.01;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) == true)
            {
                lightSource.X -= (float)0.01;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) == true)
            {
                lightSource.X += (float)0.01;
            }
            

            // Draw every face shape
            for (int i = 0; i < faceQuads.Length; i++)
            {
                DrawQuad(faceQuads[i][0], faceQuads[i][1], faceQuads[i][2], faceQuads[i][3], (int)faceQuads[i][4].X, (int)faceQuads[i][4].Y);
            }

            // Set lightSource circle
            Draw.LineColor = Color.Blue;
            Draw.LineSize = 5;
            Draw.FillColor = Color.Yellow;
            Draw.Circle(TransformVerticies(lightSource), 5);
            
            
        }
    }

}
