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
        static int[] canvasSize = [900,600];
        static int[][] myList = [[12],[34]];
        int scale;
        int screenDiffX = 0;
        int screenDiffY = 0;
        

        

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 
        
        public Vector2 TransformVerticies(Vector2 v)
        {
            // Not sure if i can use Math.Min() here, so I made my own check
            if (canvasSize[0] < canvasSize[1])
            {
                scale = canvasSize[0]/2;
                screenDiffY = (canvasSize[1] - canvasSize[0])/2;
            } else
            {
                scale = canvasSize[1]/2;
                screenDiffX = (canvasSize[0] - canvasSize[1])/2;
            }

            // Math is x*(w/2)+w/2  >   (x+1)(w/2)

            v.X = (v.X + 1.0f) * (scale + screenDiffX);
            v.Y = (v.Y + 1.0f) * (scale + screenDiffY);

            return v;
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

            Draw.Polygon(TransformVerticies(new Vector2(0, 0)), 25, 5, 0, 0);
            int[] list = [100,200];
            int[] list2 = [400,800];
            Draw.PolyLine(list, list2);
            // Convert every verticy to screenspace
            
        }
    }

}
